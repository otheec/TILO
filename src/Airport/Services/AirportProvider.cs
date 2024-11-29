namespace Airport.Services;
internal class AirportProvider
{
    public static List<Model.Airport> GetAirports()
    {
        string filePath = Path.Combine(AppContext.BaseDirectory, "Resources", "airport_feed.json");
        string json = File.ReadAllText(filePath);

        var airports = AirportParser.ParseAirports(json) 
            ?? throw new NullReferenceException("No airport parsed");
        AirportParser.NormalizeDistances(airports);

        return airports;
    }
}
