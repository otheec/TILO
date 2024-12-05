using RamMachine;

// Implementation of RAM machine
// https://github.com/Sviatik123/RAM-Machine

Console.WriteLine("Task 1\n");
Machine m1 = new Machine();
string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Commands\task1.txt");
m1.ParseCommands(filePath);
m1.Run("1 5 8 9 0");
m1.PrintResult();

Console.WriteLine("Task 2\n");
Machine m2 = new Machine();
string filePath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Commands\task2.txt");
m2.ParseCommands(filePath2);
m2.Run("1 2 3 1 2 3 0");
m2.PrintResult();