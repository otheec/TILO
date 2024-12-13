const int stepsPerFloor = 5;
const int goal = (25 * stepsPerFloor) + 4;

Dictionary<int, ulong> cache = new Dictionary<int, ulong>();

for (int i = goal; i <= goal; i++)
{
    Console.Write("Possible combinations to reach the " + i + "th stair: ");
    Console.WriteLine(ComputeTotal(i));
}

ulong ComputeTotal(int n)
{
    ulong result = GetOrCompute(n);

    var mod = n % stepsPerFloor;
    var combinations = (n - mod) / stepsPerFloor;
    int combinationsPow = (int)Math.Pow(2, combinations);

    for (int i = 1; i < combinationsPow; i++)
    {
        var binArray = GetConsecutiveZeros(i, combinations);
        ulong midResult = 1;
        foreach (int number in binArray)
            midResult *= GetOrCompute(number * stepsPerFloor);

        result += (midResult * GetOrCompute(mod));
    }

    return result;
}

ulong GetOrCompute(int n)
{
    if (cache.TryGetValue(n, out ulong value))
    {
        return value;
    }

    ulong result = Compute123(n);
    cache[n] = result;
    return result;
}

ulong Compute123(int n)
{
    if (n == 0)
        return 1;

    if (n < 0)
        return 0;

    return GetOrCompute(n - 1) + GetOrCompute(n - 2) + GetOrCompute(n - 3);
}

int[] GetConsecutiveZeros(int decimalNumber, int length)
{
    string binary = ConvertToBinary(decimalNumber).PadLeft(length, '0');

    List<int> zeroLengths = new List<int>();
    int currentZeroCount = 0;

    foreach (char c in binary)
    {
        if (c == '0')
        {
            currentZeroCount++;
        }
        else
        {
            if (currentZeroCount > 0)
            {
                zeroLengths.Add(currentZeroCount);
                currentZeroCount = 0;
            }
        }
    }

    if (currentZeroCount > 0)
    {
        zeroLengths.Add(currentZeroCount);
    }

    return zeroLengths.ToArray();

    static string ConvertToBinary(int decimalNumber)
    {
        if (decimalNumber == 0) return "0";

        string binary = string.Empty;

        while (decimalNumber > 0)
        {
            int remainder = decimalNumber % 2;
            binary = remainder + binary;
            decimalNumber /= 2;
        }

        return binary;
    }
}

