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

        string[] asciiArt = new string[]
        {
            @" .___/\                                             _____                __  .__            ",
            @" |   )/_____     ________________________ ___.__. _/ ____\___________  _/  |_|  |__   ____  ",
            @" |   |/     \   /  ___/  _ \_  __ \_  __ <   |  | \   __\/  _ \_  __ \ \   __\  |  \_/ __ \ ",
            @" |   |  Y Y  \  \___ (  <_> )  | \/|  | \/\___  |  |  | (  <_> )  | \/  |  | |   Y  \  ___/ ",
            @" |___|__|_|  / /____  >____/|__|   |__|   / ____|  |__|  \____/|__|     |__| |___|  /\___  >",
            @"           \/       \/                    \/                                      \/     \/ "
        };

        foreach (var line in asciiArt)
        {
            Console.WriteLine(line);
        }

        asciiArt = new string[]
        {
            @" .__          __                       ___.           .__              .__                    ",
            @"|  | _____ _/  |_  ____     ________ _\_ |__   _____ |__| ______ _____|__| ____   ____      ",
            @"|  | \__  \\   __\/ __ \   /  ___/  |  \ __ \ /     \|  |/  ___//  ___/  |/  _ \ /    \     ",
            @"|  |__/ __ \|  | \  ___/   \___ \|  |  / \_\ \  Y Y  \  |\___ \ \___ \|  (  <_> )   |  \    ",
            @"|____(____  /__|  \___  > /____  >____/|___  /__|_|  /__/____  >____  >__|\____/|___|  / /\ ",
            @"          \/          \/       \/          \/      \/        \/     \/               \/  \/ "
        };

        foreach (var line in asciiArt)
        {
            Console.WriteLine(line);
        }
    }

    private static void SolveAlgorithm(IAlgorithm algorithm)
    {
        var output = algorithm.Solve();
        int totalKm = 0;
        int dayCounter = 1;
        int dailyUnits = 8;
        int remainingUnitsToday = dailyUnits;

        HashSet<Node> alreadyVisited = new() { output[0].Source, output[0].Destination };

        foreach (var edge in output)
        {
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

        Console.WriteLine($"result: {dayCounter} days, {totalKm} km");
    }
}
