using TouringMachineCoding.Models;

namespace TouringMachineCoding.Coding;

internal class Encoder
{
    private const char _nullChar = 'N'; //cannot use null as key for dictionary, therefor using contant as substitutute

    public static string Encode(List<TransitionRule> transitions)
    {
        var symbolsMap = GetSymbolsMap(transitions);
        var statesMap = GetStatesMap(transitions);
        var headMap = HeadMovement.GetHeadMovementMap();

        var transLines = new List<string>();

        for ( var i = 0; i < transitions.Count; i++)
        {
            var transition = transitions[i];

            string state = statesMap[transition.State];
            string read = symbolsMap[GetNotNullSymbol(transition.Read)];
            string write = symbolsMap[GetNotNullSymbol(transition.Write)];
            string move = headMap[transition.Move];
            string nextState = statesMap[transition.NextState];

            var newLine = state + read + nextState + write + move;
            transLines.Add(newLine);
        }

        string statesSizeIndicator = new string('1', statesMap.Count);
        string symbolsSizeIndicator = new string('1', symbolsMap.Count);

        var encodedLines = statesSizeIndicator + "0" + symbolsSizeIndicator + "0" + string.Join("", transLines);

        return encodedLines;
    }

    private static char GetNotNullSymbol(char? symbol)
    {
        if (symbol == null)
        {
            return _nullChar;
        } else
        {
            return (char)symbol;
        }
    }

    private static Dictionary<int, string> GetStatesMap(List<TransitionRule> transitions)
    {
        var states = transitions
            .Select(t => t.State)
            .Distinct()
            .ToList();

        var nextStates = transitions
            .Select(t => t.NextState)
            .Distinct()
            .ToList();

        var statesCombined = states
            .Union(nextStates)
            .ToList();

        var StatesMap = new Dictionary<int, string>();

        int bitLength = (int)Math.Ceiling(Math.Log2(statesCombined.Count));

        for (int i = 0; i < statesCombined.Count; i++)
        {
            string binaryRepresentation = Convert.ToString(i, 2).PadLeft(bitLength, '0');

            StatesMap[statesCombined[i]] = binaryRepresentation;
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
