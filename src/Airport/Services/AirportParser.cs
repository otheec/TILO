using Newtonsoft.Json;

namespace Airport.Services;
public static class AirportParser
{
    public static List<Model.Airport>? ParseAirports(string json)
    {
        return JsonConvert.DeserializeObject<List<Model.Airport>>(json);
    }

    public static void NormalizeDistances(List<Model.Airport> airports)
    {
        foreach (var airport in airports)
        {
            foreach (var connection in airport.Connections)
            {
                if (connection.Distance.Unit == "mi")
                {
                    connection.Distance.Value *= 1.60934;
                    connection.Distance.Unit = "km";
                }
            }
        }
    }
}

