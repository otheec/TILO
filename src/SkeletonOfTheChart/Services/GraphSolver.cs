using SkeletonOfTheChart.Algorithms;
using SkeletonOfTheChart.Interfaces;
using SkeletonOfTheChart.Model;

namespace SkeletonOfTheChart.Services;
internal class GraphSolver
{
    public static void Solve(List<Edge> edges)
    {
        Console.WriteLine("Kruskal Algorithm:");
        SolveAlgorithm(new Kruskal(edges));

        Console.WriteLine("----------------------------------\n");

        Console.WriteLine("Boruvka Algorithm:");
        SolveAlgorithm(new Boruvka(edges));

        Console.WriteLine("----------------------------------\n");

        Console.WriteLine("Jarnik Algorithm:");
        SolveAlgorithm(new Jarnik(edges));
    }

    private static void SolveAlgorithm(IAlgorithm algorithm)
    {
        var output = algorithm.Solve();
        int totalKm = 0;
        int dayCounter = 1;
        int dailyUnits = 8;
        int remainingUnitsToday = dailyUnits;

        int asdsad = 0;

        HashSet<Node> alreadyVisited = new() { output[0].Source, output[0].Destination };

        foreach (var edge in output)
        {
            asdsad += edge.Value;
            int workUnits = edge.Value + ((alreadyVisited.Contains(edge.Source) || alreadyVisited.Contains(edge.Destination)) ? 0 : 1);

            alreadyVisited.Add(edge.Source);
            alreadyVisited.Add(edge.Destination);

            while (workUnits > 0)
            {
                int workToday = Math.Min(workUnits, remainingUnitsToday);
                totalKm += workToday;
                remainingUnitsToday -= workToday;
                workUnits -= workToday;

                if(workToday != 0)
                    Console.WriteLine($"[Day {dayCounter}] {edge.Source.Name} -> {edge.Destination.Name}: {workToday} hours, {workToday} km");

                if (remainingUnitsToday == 0 && workUnits > 0)
                {
                    dayCounter++;
                    remainingUnitsToday = dailyUnits;
                }
            }

        }

        Console.WriteLine(asdsad);
        Console.WriteLine($"result: {dayCounter} days, {totalKm} km");
    }
}
