namespace TouringMachineCoding.Coding;

internal static class Symbols
{
    public static string EncodeSymbol(char? symbol)
    {
        return symbol switch
        {
            '0' => "1000",
            '1' => "100",
            '+' => "10000",
            '_' => "10",
            null => "100000",
            _ => throw new ArgumentException("Invalid symbol to encode")
        };
    }

    public static char? DecodeSymbol(string symbol)
    {
        return symbol switch
        {
            "1000" => '0',
            "100" => '1',
            "10000" => '+',
            "10" => '_',
            "100000" => null,
            _ => throw new ArgumentException("Invalid symbol to decode")
        };
    }
}
