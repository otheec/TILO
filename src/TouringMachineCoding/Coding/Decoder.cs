using System.Text.RegularExpressions;

namespace TouringMachineCoding.Coding;

internal class Decoder
{
    public static void Decode(string inputCode, string inputSymbols)
    {
        (var statesCount, var symbolsCountm, inputCode) = GetTheCounts(inputCode);

        throw new NotImplementedException();
    }

    private static (int statesCount, int symbolsCount, string updatedCode) GetTheCounts(string code)
    {
        string binaryString = "1110111110101";

        var matches = Regex.Matches(binaryString, "1+");

        int statesIndicatorStart = matches[0].Index;
        int statesIndicatorLength = matches[0].Value.Length;

        int symbolsIndicatorStart = matches[1].Index;
        int symbolsIndicatorLength = matches[1].Value.Length;

        int statesZeroIndex = statesIndicatorStart + statesIndicatorLength;
        int symbolsZeroIndex = symbolsIndicatorStart + symbolsIndicatorLength;

        var updatedString = binaryString.Remove(symbolsZeroIndex, 1)
                                        .Remove(symbolsIndicatorStart, symbolsIndicatorLength)
                                        .Remove(statesZeroIndex, 1)
                                        .Remove(statesIndicatorStart, statesIndicatorLength);

        Console.WriteLine($"Original string: {binaryString}");
        Console.WriteLine($"Updated string: {updatedString}");
        

        return (statesIndicatorLength, symbolsIndicatorLength, updatedString);
    }
}
