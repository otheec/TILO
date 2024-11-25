namespace Airport.Algorithms;
public class Dijkstra
{
    public static List<Model.Airport> Solve(List<Model.Airport> airports, string startCode, string endCode)
    {
        var distances = new Dictionary<string, double>();
        var previous = new Dictionary<string, string>();
        var priorityQueue = new SortedSet<(double, string)>();
        var visited = new HashSet<string>();

        // Initialize distances and previous
        foreach (var airport in airports)
        {
            distances[airport.Code] = double.MaxValue;
            previous[airport.Code] = null;
        }

        if (!distances.ContainsKey(startCode) || !distances.ContainsKey(endCode))
        {
            Console.WriteLine("Start or end airport not found in the dataset.");
            return new List<Model.Airport>();
        }

        distances[startCode] = 0;
        priorityQueue.Add((0, startCode));

        while (priorityQueue.Any())
        {
            var (currentDistance, currentCode) = priorityQueue.First();
            priorityQueue.Remove(priorityQueue.First());

            if (currentCode == endCode)
                break;

            if (visited.Contains(currentCode))
                continue;

            visited.Add(currentCode);

            var currentAirport = airports.FirstOrDefault(a => a.Code == currentCode);
            if (currentAirport == null)
            {
                Console.WriteLine($"Warning: Airport with code {currentCode} not found.");
                continue;
            }

            foreach (var connection in currentAirport.Connections)
            {
                if (visited.Contains(connection.Code))
                    continue;

                if (!distances.ContainsKey(connection.Code))
                {
                    Console.WriteLine($"Warning: Connection to airport with code {connection.Code} not found in the dataset.");
                    continue;
                }

                double distance = connection.Distance.Value;

                if (distances[currentCode] + distance < distances[connection.Code])
                {
                    distances[connection.Code] = distances[currentCode] + distance;
                    previous[connection.Code] = currentCode;

                    priorityQueue.Add((distances[connection.Code], connection.Code));
                }
            }
        }

        return ReconstructPath(airports, previous, endCode);
    }

    private static List<Model.Airport> ReconstructPath(List<Model.Airport> airports, Dictionary<string, string> previous, string endCode)
    {
        var path = new List<Model.Airport>();

        var currentCode = endCode;
        while (currentCode != null)
        {
            var airport = airports.FirstOrDefault(a => a.Code == currentCode);
            if (airport == null)
            {
                Console.WriteLine($"Warning: Failed to find airport with code {currentCode} in the dataset.");
                break;
            }

            path.Add(airport);
            currentCode = previous.GetValueOrDefault(currentCode);
        }

        path.Reverse();
        return path;
    }
}
