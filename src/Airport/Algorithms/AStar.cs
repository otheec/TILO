namespace Airport.Algorithms;
internal class AStar
{
    public static List<Model.Airport> Solve(List<Model.Airport> airports, string startCode, string endCode, Func<string, string, double> heuristic)
    {
        var openSet = new SortedSet<(double, string)>();
        var gScore = new Dictionary<string, double>();
        var fScore = new Dictionary<string, double>();
        var cameFrom = new Dictionary<string, string>();

        foreach (var airport in airports)
        {
            gScore[airport.Code] = double.MaxValue;
            fScore[airport.Code] = double.MaxValue;
        }

        gScore[startCode] = 0;
        fScore[startCode] = heuristic(startCode, endCode);

        openSet.Add((fScore[startCode], startCode));

        while (openSet.Any())
        {
            var (currentFScore, currentCode) = openSet.First();
            openSet.Remove(openSet.First());

            if (currentCode == endCode)
                break;

            var currentAirport = airports.First(a => a.Code == currentCode);

            foreach (var connection in currentAirport.Connections)
            {
                double tentativeGScore = gScore[currentCode] + connection.Distance.Value;

                if (tentativeGScore < gScore[connection.Code])
                {
                    gScore[connection.Code] = tentativeGScore;
                    fScore[connection.Code] = gScore[connection.Code] + heuristic(connection.Code, endCode);
                    cameFrom[connection.Code] = currentCode;

                    openSet.Add((fScore[connection.Code], connection.Code));
                }
            }
        }

        return ReconstructPath(airports, cameFrom, endCode);
    }

    private static List<Model.Airport> ReconstructPath(List<Model.Airport> airports, Dictionary<string, string> cameFrom, string endCode)
    {
        var path = new List<Model.Airport>();
        for (var at = endCode; at != null; at = cameFrom.GetValueOrDefault(at))
        {
            path.Add(airports.First(a => a.Code == at));
        }
        path.Reverse();
        return path;
    }

}
