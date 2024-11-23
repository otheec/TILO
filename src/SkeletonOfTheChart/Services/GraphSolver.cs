using SkeletonOfTheChart.Algorithms;
using SkeletonOfTheChart.ASCII;
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

        AsciiProvider.IAmSorry();
    }

    private static void SolveAlgorithm(IAlgorithm algorithm)
    {
        var output = algorithm.Solve();
        int totalKm = 0;
        int dayCounter = 1;
        int dailyLimit = 8;
        int remainingHoursToday = dailyLimit;

        HashSet<Node> alreadyVisited = new() { output[0].Source, output[0].Destination };

        foreach (var edge in output)
        {
            int workHours = edge.Value + ((alreadyVisited.Contains(edge.Source) || alreadyVisited.Contains(edge.Destination)) ? 0 : 1);
            int workKm = edge.Value;
            totalKm += workKm;

            alreadyVisited.Add(edge.Source);
            alreadyVisited.Add(edge.Destination);

            while (workHours > 0)
            {
                int workHoursToday = Math.Min(workHours, remainingHoursToday);
                int workKmToday = Math.Min(workKm, remainingHoursToday);

                remainingHoursToday -= workHoursToday;
                workHours -= workHoursToday;
                workKm -= workKmToday;

                if(workHoursToday != 0)
                    Console.WriteLine($"[Day {dayCounter}] {edge.Source.Name} -> {edge.Destination.Name}: {workHoursToday} hours, {workKmToday} km");

                if (remainingHoursToday == 0 && workHours > 0)
                {
                    dayCounter++;
                    remainingHoursToday = dailyLimit;
                }
            }
        }

        Console.WriteLine($"result: {dayCounter} days, {totalKm} km");
    }
}
