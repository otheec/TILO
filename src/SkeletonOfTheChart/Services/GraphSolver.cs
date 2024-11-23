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

        Console.WriteLine("----------------------------------");

        Console.WriteLine("Boruvka Algorithm:");
        SolveAlgorithm(new Boruvka(edges));

        Console.WriteLine("----------------------------------");

        Console.WriteLine("Jarnik Algorithm:");
        SolveAlgorithm(new Jarnik(edges));
    }

    private static void SolveAlgorithm(IAlgorithm algorithm)
    {
        var output = algorithm.Solve();
        int totalKm = 0;

        int dayCounter = 1;
        int dailyHours = 8;
        int hoursSpentToday = 0;

        foreach (var edge in output)
        {
            int workHours = edge.Value + (hoursSpentToday > 0 ? 1 : 0);
            int workKm = Math.Min(edge.Value, dailyHours - hoursSpentToday);
            hoursSpentToday += workKm;

            if (hoursSpentToday > dailyHours)
            {
                hoursSpentToday = 0;
                dayCounter++;
                hoursSpentToday = workKm;
            }

            totalKm += workKm;

            Console.WriteLine($"[Day {dayCounter}] {edge.Nodes[0].Name} -> {edge.Nodes[1].Name}: {workHours} hours, {workKm} km");

            if (hoursSpentToday == dailyHours)
            {
                hoursSpentToday = 0;
                dayCounter++;
            }
        }

        Console.WriteLine($"result: {dayCounter} days, {totalKm} km");
    }
}
