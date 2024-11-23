using SkeletonOfTheChart.Model;

namespace SkeletonOfTheChart.Algorithms;
internal class Boruvka(List<Edge> edges)
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
        var components = nodes.ToDictionary(node => node, node => Find(node));

        while (components.Values.Distinct().Count() > 1)
        {
            // Find the cheapest edge for each component
            var cheapestEdge = new Dictionary<Node, Edge>();
            foreach (var edge in edges)
            {
                var node1 = Find(edge.Nodes[0]);
                var node2 = Find(edge.Nodes[1]);

                if (node1 != node2)
                {
                    if (!cheapestEdge.ContainsKey(node1) || cheapestEdge[node1].Value > edge.Value)
                    {
                        cheapestEdge[node1] = edge;
                    }

                    if (!cheapestEdge.ContainsKey(node2) || cheapestEdge[node2].Value > edge.Value)
                    {
                        cheapestEdge[node2] = edge;
                    }
                }
            }

            // Add the selected edges to the MST and union the components
            foreach (var edge in cheapestEdge.Values.Distinct())
            {
                var node1 = edge.Nodes[0];
                var node2 = edge.Nodes[1];

                if (Find(node1) != Find(node2))
                {
                    mstEdges.Add(edge);
                    Union(node1, node2);
                }
            }

            // Update components
            components = nodes.ToDictionary(node => node, node => Find(node));
        }

        return mstEdges;
    }
}
