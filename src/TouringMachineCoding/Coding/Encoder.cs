using TouringMachineCoding.Models;

namespace TouringMachineCoding.Coding;

internal class Encoder
{
    public static string Encode(List<TransitionRule> transitions)
    {
        var statesMap = GetStatesMap(transitions);

        var transLines = new List<string>();

        for ( var i = 0; i < transitions.Count; i++)
        {
            var transition = transitions[i];

            string state = statesMap[transition.State];
            string read = Symbols.EncodeSymbol(transition.Read);
            string write = Symbols.EncodeSymbol(transition.Write);
            string move = HeadMovement.EncodeHeadMovement(transition.Move);
            string nextState = statesMap[transition.NextState];

            var newLine = state + read + nextState + write + move;
            transLines.Add(newLine);
        }

        var encodedLines = string.Join("", transLines);

        return encodedLines;
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

        for (int i = 0; i < statesCombined.Count; i++)
        {
            string binaryRepresentation = "1" + new string('0', i);

            StatesMap[statesCombined[i]] = binaryRepresentation;
        }

        return StatesMap;
    }
}
