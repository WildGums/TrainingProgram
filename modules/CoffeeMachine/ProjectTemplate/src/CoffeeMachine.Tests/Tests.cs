using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace CoffeeMachine.Tests
{
    [TestFixture]
    public class Tests
    {
        private Process _process;

        [SetUp]
        public void SetUp()
        {
            _process = StartConsoleApplication("");
        }

        [TearDown]
        public void TearDown()
        {
            FinalizeConsoleApplication(_process);
        }

        [TestCase("")]
        public void TestScenario(string scenarioName)
        {
            var scenario = LoadScenario(scenarioName);
            AssertScenario(_process, scenario);
        }

        private void AssertScenario(Process process, string scenario)
        {
            var output = process.StandardOutput;
            var input = process.StandardInput;
            var error = process.StandardError;

            using (var scenarioReader = new StringReader(scenario))
            {
                string line;
                while ((line = scenarioReader.ReadLine()) is not null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }

                    if(line.StartsWith(">>"))
                    {
                        var text = line.Substring(2);
                        AssertOutput(output, text);
                        continue;
                    }

                    if (line.StartsWith("<<"))
                    {
                        var text = line.Substring(2);
                        AssertInput(input, text);
                        continue;
                    }

                    AssertInput(input, line);

                    // TODO: handle error
                }
            }

            AssertEndOfOutput(output);
            AssertEndOfProgramm();
        }

        private void AssertEndOfProgramm()
        {
            Assert.IsTrue(_process.HasExited, "Has the program exited?");
        }

        private static void AssertEndOfOutput(StreamReader output)
        {
            Assert.IsTrue(output.EndOfStream, $"Expected end of output, but was:\n{output.ReadToEnd()}");
        }

        private void AssertInput(StreamWriter input, string text)
        {
            Assert.IsFalse(_process.HasExited, "Expected input, but the program has exited");

            Console.WriteLine($"<<{text}");

            input.WriteLine(text);
        }

        private void AssertOutput(StreamReader output, string text)
        {
            var read = output.ReadLineAsync();
            read.Wait(100);
            if (read.IsCompleted)
            {
                var outputLine = read.Result;

                Console.WriteLine($">>{outputLine}");

                Assert.IsNotNull(outputLine, $"Expected output line '{text}' but was nothing");
                StringAssert.AreEqualIgnoringCase(text, outputLine);
            }
            else
            {
                throw new AssertionException($"Awaiting for expected output '{text}' has timed out");
            }
        }

        private static string LoadScenario(string scenarioName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"CoffeeMachine.Tests.Scenarios.{scenarioName}.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private Process StartConsoleApplication(string arguments)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "CoffeeMachine.exe";

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