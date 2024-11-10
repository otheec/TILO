using TouringMachineCoding.Models;

namespace TouringMachineCoding.Coding;

internal class Encoder
{
    private const char _nullChar = 'N'; //cannot use null as key for dictionary, therefor using contant as substitutute

    public static string Encode(List<TransitionRule> transitions)
    {
        var symbolsMap = GetSymbolsMap(transitions);
        var statesMap = GetStatesMap(transitions);

        throw new NotImplementedException();
    }

    private static Dictionary<int, string> GetStatesMap(List<TransitionRule> transitions)
    {
        var states = transitions
            .Select(t => t.State)
            .Distinct()
            .ToList();

        var StatesMap = new Dictionary<int, string>();

        int bitLength = (int)Math.Ceiling(Math.Log2(StatesMap.Count));

        for (int i = 0; i < states.Count; i++)
        {
            string binaryRepresentation = Convert.ToString(i, 2).PadLeft(bitLength, '0');

            StatesMap[states[i]] = binaryRepresentation;
        }

        return StatesMap;
    }

    private static Dictionary<char, string> GetSymbolsMap(List<TransitionRule> transitions)
    {
        var symbolsRead = transitions
            .Select(t => t.Read)
            .Distinct()
            .ToList();

        var symbolsWrite = transitions
            .Select(t => t.Write)
            .Distinct()
            .ToList();

        var symbolsCombined = symbolsRead
            .Union(symbolsWrite)
            .ToList();

        var symbolsMap = new Dictionary<char, string>();

        int bitLength = (int)Math.Ceiling(Math.Log2(symbolsCombined.Count));

        for (int i = 0; i < symbolsCombined.Count; i++)
        {
            string binaryRepresentation = Convert.ToString(i, 2).PadLeft(bitLength, '0');

            var currentSymbol = symbolsCombined[i];
            char outputsymbol;

            if (currentSymbol == null)
            {
                outputsymbol = _nullChar;
            }
            else
            {
                outputsymbol = (char)currentSymbol;
            }

            symbolsMap[outputsymbol] = binaryRepresentation;
        }

        return symbolsMap;
    }
}
