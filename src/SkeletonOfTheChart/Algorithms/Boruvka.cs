using SkeletonOfTheChart.Interfaces;
using SkeletonOfTheChart.Model;

namespace SkeletonOfTheChart.Algorithms;
internal class Boruvka(List<Edge> edges) : IAlgorithm
{
    public List<Edge> Solve()
    {
        var nodeToId = edges
            .SelectMany(e => e.Nodes)
            .Distinct()
            .Select((node, index) => new { node, index })
            .ToDictionary(x => x.node, x => x.index);

        int vertices = nodeToId.Count;

        var subsets = new Subset[vertices];
        var cheapest = new Edge[vertices];
        var mstEdges = new List<Edge>();

        for (int v = 0; v < vertices; v++)
        {
            subsets[v] = new Subset { Root = v, Weight = 0 };
            cheapest[v] = null;
        }

        int numTrees = vertices;

        while (numTrees > 1)
        {
            for (int v = 0; v < vertices; v++)
                cheapest[v] = null;

            foreach (var edge in edges)
            {
                int set1 = Find(subsets, nodeToId[edge.Source]);
                int set2 = Find(subsets, nodeToId[edge.Destination]);

                if (set1 == set2)
                    continue;

                if (cheapest[set1] == null || cheapest[set1].Value > edge.Value)
                    cheapest[set1] = edge;

                if (cheapest[set2] == null || cheapest[set2].Value > edge.Value)
                    cheapest[set2] = edge;
            }

            for (int i = 0; i < vertices; i++)
            {
                Edge edge = cheapest[i];

                if (edge != null)
                {
                    int set1 = Find(subsets, nodeToId[edge.Source]);
                    int set2 = Find(subsets, nodeToId[edge.Destination]);

                    if (set1 != set2)
                    {
                        mstEdges.Add(edge);
                        Union(subsets, set1, set2);
                        numTrees--;
                    }
                }
            }
        }

        return mstEdges;
    }

    private static int Find(Subset[] subsets, int i)
    {
        if (subsets[i].Root != i)
            subsets[i].Root = Find(subsets, subsets[i].Root);

        return subsets[i].Root;
    }

    private static void Union(Subset[] subsets, int x, int y)
    {
        int xroot = Find(subsets, x);
        int yroot = Find(subsets, y);

        if (subsets[xroot].Weight < subsets[yroot].Weight)
            subsets[xroot].Root = yroot;
        else if (subsets[xroot].Weight > subsets[yroot].Weight)
            subsets[yroot].Root = xroot;
        else
        {
            subsets[yroot].Root = xroot;
            subsets[xroot].Weight++;
        }
    }

    private class Subset
    {
        public int Root { get; set; }
        public int Weight { get; set; }
    }
}
