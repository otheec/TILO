namespace TouringMachineCoding.Coding;

internal static class HeadMovement
{
    public static string EncodeHeadMovement(char move)
    {
        return move switch
        {
            'L' => "1000",
            'R' => "100",
            'S' => "10",
            _ => throw new ArgumentException("Invalid head movement character")
        };
    }

    private static char DecodeHeadMovement(string binaryMove)
    {
        return binaryMove switch
        {
            "1000" => 'L',
            "100" => 'R',
            "10" => 'S',
            _ => throw new ArgumentException("Invalid head movement code")
        };
    }
}

