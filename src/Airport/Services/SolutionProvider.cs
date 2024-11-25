using Airport.Algorithms;
using System.Globalization;

namespace Airport.Services;
internal class SolutionProvider
{
    public static void ShowSolution()
    {
        var airports = AirportProvider.GetAirports();

        var random = new Random();
        Func<string, string, double> heuristic = (startCode, endCode) =>
        {
            return random.NextDouble();
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
