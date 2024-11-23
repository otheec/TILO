using SkeletonOfTheChart.Model;

namespace SkeletonOfTheChart.Algorithms;
internal class Kruskal(List<Edge> edges)
{
    public List<Edge> Solve()
    {
        var nodes = edges.SelectMany(e => e.Nodes).Distinct().ToList();

        var parent = new Dictionary<Node, Node>();
        foreach (var node in nodes)
        {
            parent[node] = node;
        }

        Node Find(Node node)
        {
            if (parent[node] != node)
            {
                parent[node] = Find(parent[node]);
            }
            return parent[node];
        }

        void Union(Node node1, Node node2)
        {
            var root1 = Find(node1);
            var root2 = Find(node2);
            if (root1 != root2)
            {
                parent[root1] = root2;
            }
        }

        var mstEdges = new List<Edge>();
        foreach (var edge in edges.OrderBy(e => e.Value))
        {
            var node1 = edge.Nodes[0];
            var node2 = edge.Nodes[1];

            if (Find(node1) != Find(node2))
            {
                mstEdges.Add(edge);
                Union(node1, node2);
            }
        }

        return mstEdges;
    }
}
