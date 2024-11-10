using TouringMachineCoding.Models;

namespace TouringMachineCoding.Coding;

internal class Decoder
{
    public static List<TransitionRule> Decode(string inputCode)
    {
        var decodedTransitions = new List<TransitionRule>();

        int index = 0;
        while (index < inputCode.Length)
        {
            int state = CountInitialZerosAndCrop(ref inputCode);

            var readCode = GetParsedCode(ref inputCode);
            char? read = Symbols.DecodeSymbol(readCode);

            int nextState = CountInitialZerosAndCrop(ref inputCode);

            var writeCode = GetParsedCode(ref inputCode);
            char? write = Symbols.DecodeSymbol(writeCode);

            var moveCode = GetParsedCode(ref inputCode);
            char move = HeadMovement.DecodeHeadMovement(moveCode);

            decodedTransitions.Add(new TransitionRule
            {
                State = state,
                Read = read,
                Write = write,
                Move = move,
                NextState = nextState
            });
        }

        return decodedTransitions;
    }

    private static int CountInitialZerosAndCrop(ref string input)
    {
        int zeroCount = 0;
        int index = 1;

        while (index < input.Length && input[index] == '0')
        {
            zeroCount++;
            index++;
        }

        input = input.Substring(index);

        return zeroCount - 1;
    }

    private static string GetParsedCode(ref string input)
    {
        int zeroCount = 0;
        int index = 1;

        while (index < input.Length && input[index] == '0')
        {
            zeroCount++;
            index++;
        }

        var remainingPart = input.Substring(0, index);
        input = input.Substring(index);

        return remainingPart;
    }
}