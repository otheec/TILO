using Airport.Algorithms;
using System.Globalization;

namespace Airport.Services;
internal class SolutionProvider
{
    public static void ShowSolution()
    {
        var airports = AirportProvider.GetAirports();

        var random = new Random();

        var airportCoordinates = CoordinatesProvider.GetAirportCoordinates();

        Func<string, string, double> heuristic = (startCode, endCode) =>
        {
            if (!airportCoordinates.ContainsKey(startCode) || !airportCoordinates.ContainsKey(endCode))
                throw new Exception("Invalid airport code");

            var (lat1, lon1) = airportCoordinates[startCode];
            var (lat2, lon2) = airportCoordinates[endCode];

            double R = 6371; // Radius of Earth in km
            double dLat = (lat2 - lat1) * Math.PI / 180;
            double dLon = (lon2 - lon1) * Math.PI / 180;
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(lat1 * Math.PI / 180) * Math.Cos(lat2 * Math.PI / 180) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        };

        List<(string Start, string End)> routes = new()
        {
            ("PRG", "DEL"),
            ("BRE", "FNJ"),
            ("JFK", "CAI"),
            ("DUB", "DME"),
            ("OKA", "EVX")
        };

        List<(string Start, string End, List<Model.Airport> Path)> solutionAstar = routes
            .Select(route => (route.Start, route.End, AStar.Solve(airports, route.Start, route.End, heuristic)))
            .ToList();

        List<(string Start, string End, List<Model.Airport> Path)> solutionDijkstra = routes
            .Select(route => (route.Start, route.End, Dijkstra.Solve(airports, route.Start, route.End)))
            .ToList();

        Console.WriteLine("=== A* Algorithm Solutions ===");
        foreach (var (start, end, path) in solutionAstar)
        {
            Console.WriteLine(FormatPath(start, end, path));
        }

        Console.WriteLine("\n=== Dijkstra Algorithm Solutions ===");
        foreach (var (start, end, path) in solutionDijkstra)
        {
            Console.WriteLine(FormatPath(start, end, path));
        }
    }

    private static string FormatPath(string start, string end, List<Model.Airport> path)
    {
        if (path == null || path.Count == 0)
            return $"{start} -> No path found -> {end}";

        double totalDistance = 0;
        var result = $"{start}";

        for (int i = 1; i < path.Count; i++)
        {
            var from = path[i - 1];
            var to = path[i];
            var connection = from.Connections.FirstOrDefault(c => c.Code == to.Code);

            if (connection != null)
            {
                double distance = connection.Distance.Value;
                totalDistance += distance;

                result += $" -> " +
                    $"{to.Code}({totalDistance.ToString("0.0", CultureInfo.InvariantCulture)}," +
                    $"{distance.ToString("0.0", CultureInfo.InvariantCulture)})";
            }
        }

        return result;
    }
}
