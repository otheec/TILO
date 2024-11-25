namespace Airport.Services;
internal class AirportProvider
{
    public static List<Model.Airport> GetAirports()
    {
        string filePath = Path.Combine(AppContext.BaseDirectory, "Res", "airport_feed.json");
        string json = File.ReadAllText(filePath);


        var airports = AirportParser.ParseAirports(json);
        AirportParser.NormalizeDistances(airports);

        return airports;
    }
}
