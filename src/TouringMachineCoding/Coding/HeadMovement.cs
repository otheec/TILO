namespace TouringMachineCoding.Coding;

internal class HeadMovement
{
    public static Dictionary<char, string> GetHeadMovementMap()
    {
        return  new Dictionary<char, string>
        { 
            { 'L', "00" },
            { 'R', "01" },
            { 'S', "10" }
        };
    }
}
