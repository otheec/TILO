using RamMachine;
using RamMachineTests.Utils;

namespace RamMachineTests.Tests;
[TestClass]
public class RamMachineMultiplicationTests
{
    private Machine m = null!;

    [TestInitialize]
    public void Setup()
    {
        m = new Machine();
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Commands\task1.txt");
        m.ParseCommands(filePath);
    }

    [TestMethod]
    public void TestCase_Multiply_1_5_8_9()
    {
        RunAndAssert("1 5 8 9 0", "360");
    }

    [TestMethod]
    public void TestCase_Multiply_2_3()
    {
        RunAndAssert("2 3 0", "6");
    }

    [TestMethod]
    public void TestCase_Multiply_10()
    {
        RunAndAssert("10 0", "10");
    }

    [TestMethod]
    public void TestCase_Multiply_3_3_3()
    {
        RunAndAssert("3 3 3 0", "27");
    }

    private void RunAndAssert(string input, string expected)
    {
        using (var consoleOutput = new ConsoleOutput())
        {
            m.Run(input);
            m.PrintResult();

            string output = consoleOutput.GetOuput();
            Assert.IsTrue(output.Contains(expected), $"Failed for input: {input}. Expected: {expected}, Actual: {output}");
        }
    }
}

