using RamMachine;
using RamMachineTests.Utils;

namespace RamMachineTests.Tests;
[TestClass]
public class RamMachineNumbersCounterComparatorTests
{
    private Machine m = null!;

    [TestInitialize]
    public void Setup()
    {
        m = new Machine();
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Commands\task2.txt");
        m.ParseCommands(filePath);
    }

    [TestMethod]
    public void TestCase_EqualCounts_1_2_3()
    {
        RunAndAssert("1 2 3 1 2 3 0", "1"); // Equal counts of 1s, 2s, 3s
    }

    [TestMethod]
    public void TestCase_UnequalCounts()
    {
        RunAndAssert("1 1 1 2 2 2 3 0", "0"); // Unequal counts of 1s, 2s, 3s
    }

    [TestMethod]
    public void TestCase_Only1s()
    {
        RunAndAssert("1 1 1 0", "0"); // Only 1s, others are zero
    }

    [TestMethod]
    public void TestCase_Only2s()
    {
        RunAndAssert("2 2 2 0", "0"); // Only 2s, others are zero
    }

    [TestMethod]
    public void TestCase_Only3s()
    {
        RunAndAssert("3 3 3 0", "0"); // Only 3s, others are zero
    }

    [TestMethod]
    public void TestCase_NoInput()
    {
        RunAndAssert("0", "1"); // No input means all counts are effectively equal at 0
    }

    [TestMethod]
    public void TestCase_SingleNumberEach()
    {
        RunAndAssert("1 2 3 0", "1"); // Single 1, 2, and 3; counts are equal
    }

    [TestMethod]
    public void TestCase_MixOfNUmbersEqual()
    {
        RunAndAssert("1 1 2 1 3 2 3 3 2 0", "1"); // Equal counts of 1s, 2s, 3s, mixed
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
