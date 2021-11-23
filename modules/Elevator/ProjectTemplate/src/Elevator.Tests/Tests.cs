using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Elevator.Tests
{
    [TestFixture]
    public class Tests
    {
        private readonly string _resourcePrefix;

        public Tests()
        {
            var assembly = Assembly.GetExecutingAssembly();
            _resourcePrefix = $"{assembly.GetName().Name}.Scenarios.";
        }


        [Test]
        public void TestScenario()
        {
            var scenarioResources = GetAllScenarioResources();
            foreach (var scenarioResource in scenarioResources)
            {
                var scenario = LoadScenario(scenarioResource);
                var scenarioName = scenarioResource.Substring(_resourcePrefix.Length);

                var process = StartConsoleApplication("");

                try
                {
                    AssertScenario(process, scenarioName, scenario);
                }
                finally
                {
                    FinalizeConsoleApplication(process);
                }
            }
        }

        private IEnumerable<string> GetAllScenarioResources()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string[] resourceNames = assembly.GetManifestResourceNames();

            return resourceNames.Where(x => x.StartsWith(_resourcePrefix))
                .OrderBy(x => x);
        }

        private void AssertScenario(Process process, string scenarioName, string scenario)
        {
            var output = process.StandardOutput;
            var input = process.StandardInput;
            var error = process.StandardError;

            var echo = new StringBuilder();
            var lineNumber = 0;

            try
            {
                using (var scenarioReader = new StringReader(scenario))
                {
                    string line;
                    while ((line = scenarioReader.ReadLine()) is not null)
                    {
                        lineNumber++;

                        if (string.IsNullOrWhiteSpace(line))
                        {
                            continue;
                        }

                        if (line.StartsWith(">>"))
                        {
                            var text = line.Substring(2);
                            AssertOutput(output, text, echo);
                            continue;
                        }

                        if (line.StartsWith("<<"))
                        {
                            var text = line.Substring(2);
                            AssertInput(process, input, text, echo);
                            continue;
                        }

                        AssertInput(process, input, line, echo);
                    }
                }

                AssertEndOfOutput(output);
                AssertEndOfProgram(process);
            }
            catch (AssertionException ex)
            {
                echo.AppendLine();
                echo.AppendLine($"Error executing scenario {scenarioName}");
                echo.AppendLine($"   file name: {scenarioName}");
                echo.AppendLine($"   line: {lineNumber}");
                echo.AppendLine();
                echo.AppendLine(ex.Message);

                Console.WriteLine(echo.ToString());

                throw;
            }
        }

        private void AssertEndOfProgram(Process process)
        {
            Assert.IsTrue(process.HasExited, "Has the program exited?");
        }

        private static void AssertEndOfOutput(StreamReader output)
        {
            Assert.IsTrue(output.EndOfStream, $"Expected end of output, but was:\n{output.ReadToEnd()}");
        }

        private void AssertInput(Process process, StreamWriter input, string text, StringBuilder echo)
        {
            Assert.IsFalse(process.HasExited, "Expected input, but the program has exited");

            echo.AppendLine($"{text}");

            input.WriteLine(text);
        }

        private void AssertOutput(StreamReader output, string text, StringBuilder echo)
        {
            var read = output.ReadLineAsync();
            read.Wait(100);
            if (read.IsCompleted)
            {
                var outputLine = read.Result;

                echo.AppendLine($">>{outputLine}");

                Assert.IsNotNull(outputLine, $"Expected output line '{text}' but was nothing");
                StringAssert.AreEqualIgnoringCase(text, outputLine);
            }
            else
            {
                throw new AssertionException($"Awaiting for expected output '{text}' has timed out");
            }
        }

        private static string LoadScenario(string scenarioResource)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(scenarioResource))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private Process StartConsoleApplication(string arguments)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "Elevator.exe";

            proc.StartInfo.Arguments = arguments;

            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;

            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardInput = true;

            proc.StartInfo.WorkingDirectory = Environment.CurrentDirectory;

            proc.Start();

            return proc;
        }

        private static int FinalizeConsoleApplication(Process proc)
        {
            if (!proc.HasExited)
            {
                proc.WaitForExit(100);
            }

            if (!proc.HasExited)
            {
                proc.Kill();
            }

            return proc.ExitCode;
        }
    }
}