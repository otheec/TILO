using ResourceGraphTraversal.Model;

namespace ResourceGraphTraversal.Services;
internal class GraphSolver
{
    public static void Solve(List<Node> nodes)
    {
        int rozpocet = 485;
        int zdroje = 0;

        Solution sol = new(rozpocet, zdroje, [nodes[0]]);

        var result = sol.Run();
        var bestResult = result.OrderByDescending(r => r.zdroje).First();

        bestResult.visitedNodes
            .ForEach(n => Console.WriteLine(
                $"[t_{bestResult.visitedNodes.IndexOf(n) + 1}] " +
                $"{n.ConnectionValue}, " +
                $"{n.NodeValue} => " +
                $"r={rozpocet -= n.ConnectionValue}, " +
                $"z={zdroje += n.NodeValue}"));

        Console.WriteLine("\nCollected zdroje: " + zdroje); 
    }
}
