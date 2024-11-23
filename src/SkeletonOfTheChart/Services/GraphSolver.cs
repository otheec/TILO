using SkeletonOfTheChart.Algorithms;
using SkeletonOfTheChart.Model;

namespace SkeletonOfTheChart.Services;
internal class GraphSolver
{
    public static void Solve(List<Edge> edges)
    {
        Kruskal kruskal = new(edges);
        var kruskalOutput = kruskal.Solve();
        int kruskalCounter = 0;

        for (int i = 0; i < kruskalOutput.Count; i++)
        {
            var e = kruskalOutput[i];
            Console.WriteLine($"{e.Value} {e.Nodes[0].Name} {e.Nodes[1].Name}");
        }

        Console.WriteLine("----------------------------------");

        Boruvka boruvka = new(edges);
        var boruvkaOutput = boruvka.Solve();
        int boruvkaCounter = 0;

        for (int i = 0; i < boruvkaOutput.Count; i++)
        {
            var e = boruvkaOutput[i];
            Console.WriteLine($"{e.Value} {e.Nodes[0].Name} {e.Nodes[1].Name}");
        }

        Console.WriteLine("----------------------------------");

        Jarnik jarnik = new(edges);
        var jarnikOutput = jarnik.Solve();
        int jarnikCounter = 0;

        for (int i = 0; i < jarnikOutput.Count; i++)
        {
            var e = jarnikOutput[i];
            Console.WriteLine($"{e.Value} {e.Nodes[0].Name} {e.Nodes[1].Name}");
        }
    }
}
