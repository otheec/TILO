namespace GraphFund.Model;

internal class Graph
{
    public void Run()
    {
        //top left
        Node n15 = new(21, 15);
        Node n10 = new(48, 10);
        Node n14 = new(132, 14, [n10, n15]);

        //bottom
        Node n1 = new(4, 1);
        Node n3 = new(30, 3);
        Node n20 = new(30, 20);
        Node n19 = new(57, 19);

        Node n4 = new(78, 4, [n19, n20]);

        Node n40 = new(145, 40, [n1, n3, n4]);

        //top left
        Node n5 = new(12, 5);
        Node n43 = new(23, 43);
        Node n36 = new(27, 36);

        Node n12 = new(150, 12, [n36, n43]);

        Node n1_2 = new(193, 1, [n5, n12]);
        //head
        Node head = new(0, 5, [n40, n14, n1_2]);

        int rozpocet = 485;
        int zdroje = 0;
        Solution sol = new(rozpocet, zdroje, [head]);
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
