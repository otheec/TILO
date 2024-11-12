using GraphFund.Model;

namespace GraphFund.Services;
internal class GraphSolver
{
    public static void Solve(List<Node> nodes)
    {
        int rozpocet = 485;
        int zdroje = 0;

        Solution sol = new(rozpocet, zdroje, [nodes[0]]);

        var result = sol.Run();
        var bestResult = result.OrderByDescending(r => r.zdroje).First();

        bestResult.path
            .ForEach(n => Console.WriteLine(
                $"[t_{bestResult.path.IndexOf(n) + 1}] " +
                $"h_i ({n.ConnectionValue}), " +
                $"u_i ({n.NodeValue}) => " +
                $"{rozpocet -= n.ConnectionValue}, " +
                $"{zdroje += n.NodeValue}"));
    }
}
