using SkeletonOfTheChart.Interfaces;
using SkeletonOfTheChart.Model;

namespace SkeletonOfTheChart.Algorithms;
internal class Jarnik(List<Edge> edges) : IAlgorithm
{
    public List<Edge> Solve()
    {
        var nodes = edges.SelectMany(e => e.Nodes).Distinct().ToList();

        var adjacencyList = nodes.ToDictionary(node => node, _ => new List<Edge>());
        foreach (var edge in edges)
        {
            adjacencyList[edge.Nodes[0]].Add(edge);
            adjacencyList[edge.Nodes[1]].Add(edge);
        }

        var mstEdges = new List<Edge>();
        var visited = new HashSet<Node>();

        var priorityQueue = new SortedSet<Edge>(Comparer<Edge>.Create((e1, e2) =>
        {
            if (e1.Value != e2.Value) return e1.Value.CompareTo(e2.Value);
            return e1.GetHashCode().CompareTo(e2.GetHashCode()); 
        }));

        var startNode = nodes.First();
        visited.Add(startNode);
        priorityQueue.UnionWith(adjacencyList[startNode]);

        while (priorityQueue.Count > 0)
        {
            var edge = priorityQueue.First();
            priorityQueue.Remove(edge);

            var node1 = edge.Nodes[0];
            var node2 = edge.Nodes[1];

            var nextNode = visited.Contains(node1) ? node2 : node1;

            if (!visited.Contains(nextNode))
            {
                mstEdges.Add(edge);
                visited.Add(nextNode);

                foreach (var adjacentEdge in adjacencyList[nextNode])
                {
                    if (!visited.Contains(adjacentEdge.Nodes[0]) || !visited.Contains(adjacentEdge.Nodes[1]))
                    {
                        priorityQueue.Add(adjacentEdge);
                    }
                }
            }
        }

        return mstEdges;
    }
}
