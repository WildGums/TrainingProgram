# Coffee Machine

Simple interact with user for making 1 type of coffee using existing components.

Make sure Visual Studio 2019, .Net Framework 5.0 is installed before starting.

Install Microsoft.NET.Test.Sdk, NUnit, NUnit3TestAdapter packages using NuGet.

Clone the repository to your computer.

Run TrainingProgram / modules / CoffeeMachine / ProjectTemplate / src / CoffeeMachine.sln

In the SolutionExplorer window, select the Scenarios folder,
right-click -> Add existing items -> TrainingProgram/modules/CoffeeMachine/Stage 1/Scenarios -> select all files

In the SolutionExplorer window, select Exit.txt, right-click -> Properties -> Build action -> Embedded resource.
Do the same for files MakeCoffee.txt, WrongChoice.txt.

Open TestExplorer Window. Press Run All Tests.

Open Program.cs, in the Main() method write Console.WriteLine("====="); Build project.

Press Run All Tests.
You can see that the message in the TestExplorer Window has changed, but the test still fails.

Make changes to the Program.cs until the output in the console window matches the text of the Exit.txt(except "<<" and ">>").

A stage is considered successful when all tests are succeeded at the same time.(Use the Run All Tests button.)


To complete this stage the links below might be helpful:

[The structure of the program. Main() method](https://metanit.com/sharp/tutorial/1.5.php)

[Create a simple C# console app in Visual Studio](https://docs.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-console?view=vs-2019)

[Branches and loops](https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/tutorials/branches-and-loops-local)  

[Statement Keywords](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/continue)
  
[C# programming guide](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/) (look at types, type conversions, methods)