using System.Text.RegularExpressions;
using TouringMachineCoding.Models;

namespace TouringMachineCoding.Coding;

internal class Decoder
{
    public static void Decode(string inputCode, string inputSymbols)
    {
        (int statesCount, int symbolsCount, string remainingCode) = GetTheCounts(inputCode);

        Console.WriteLine($"States Count: {statesCount}");
        Console.WriteLine($"Symbols Count: {symbolsCount}");

        List<TransitionRule> transitions = ParseTransitions(remainingCode, statesCount, symbolsCount);

        foreach (var transition in transitions)
        {
            Console.WriteLine($"State: {transition.State}, Read: {transition.Read}, Write: {transition.Write}, Move: {transition.Move}, Next State: {transition.NextState}");
        }
    }

    private static (int statesCount, int symbolsCount, string updatedCode) GetTheCounts(string code)
    {
        var matches = Regex.Matches(code, "1+");

        int statesIndicatorStart = matches[0].Index;
        int statesIndicatorLength = matches[0].Value.Length;

        int symbolsIndicatorStart = matches[1].Index;
        int symbolsIndicatorLength = matches[1].Value.Length;

        int statesZeroIndex = statesIndicatorStart + statesIndicatorLength;
        int symbolsZeroIndex = symbolsIndicatorStart + symbolsIndicatorLength;

        var updatedString = code.Remove(symbolsZeroIndex, 1)
                                .Remove(symbolsIndicatorStart, symbolsIndicatorLength)
                                .Remove(statesZeroIndex, 1)
                                .Remove(statesIndicatorStart, statesIndicatorLength);

        return (statesIndicatorLength, symbolsIndicatorLength, updatedString);
    }

    private static List<TransitionRule> ParseTransitions(string code, int statesCount, int symbolsCount)
    {
        var transitions = new List<TransitionRule>();

        int stateLength = (int)Math.Ceiling(Math.Log2(statesCount));
        int symbolLength = (int)Math.Ceiling(Math.Log2(symbolsCount));
        int headMovementLength = 2;

        int transitionLength = stateLength + symbolLength + stateLength + symbolLength + headMovementLength;

        for (int i = 0; i < code.Length; i += transitionLength)
        {
            if (i + transitionLength > code.Length)
                break;

            string transitionCode = code.Substring(i, transitionLength);

            string stateCode = transitionCode.Substring(0, stateLength);
            string readCode = transitionCode.Substring(stateLength, symbolLength);
            string nextStateCode = transitionCode.Substring(stateLength + symbolLength, stateLength);
            string writeCode = transitionCode.Substring(stateLength + symbolLength + stateLength, symbolLength);
            string moveCode = transitionCode.Substring(stateLength + symbolLength + stateLength + symbolLength, headMovementLength);

            int state = Convert.ToInt32(stateCode, 2);
            int read = Convert.ToInt32(readCode, 2);
            int write = Convert.ToInt32(writeCode, 2);
            int nextState = Convert.ToInt32(nextStateCode, 2);
            char move = DecodeHeadMovement(moveCode);

            transitions.Add(new TransitionRule(state, read, write, move, nextState));
        }

        return transitions;
    }

    private static char DecodeHeadMovement(string binaryMove)
    {
        return binaryMove switch
        {
            "00" => 'L',
            "01" => 'R',
            "10" => 'S',
            _ => throw new ArgumentException("Invalid head movement code")
        };
    }
}
