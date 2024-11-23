using SkeletonOfTheChart.Model;

namespace SkeletonOfTheChart.Algorithms;
internal class Jarnik(List<Edge> edges)
{
    public List<Edge> Solve()
    {
        var nodes = edges.SelectMany(e => e.Nodes).Distinct().ToList();

        // Create a dictionary to track the adjacency list for the graph
        var adjacencyList = nodes.ToDictionary(node => node, _ => new List<Edge>());
        foreach (var edge in edges)
        {
            adjacencyList[edge.Nodes[0]].Add(edge);
            adjacencyList[edge.Nodes[1]].Add(edge);
        }

        var mstEdges = new List<Edge>();
        var visited = new HashSet<Node>();

        // Use a priority queue to select the minimum-weight edge efficiently
        var priorityQueue = new SortedSet<Edge>(Comparer<Edge>.Create((e1, e2) =>
        {
            if (e1.Value != e2.Value) return e1.Value.CompareTo(e2.Value);
            return e1.GetHashCode().CompareTo(e2.GetHashCode()); // Tie-breaking
        }));

        // Start from an arbitrary node (e.g., the first node in the list)
        var startNode = nodes.First();
        visited.Add(startNode);
        priorityQueue.UnionWith(adjacencyList[startNode]);

        while (priorityQueue.Count > 0)
        {
            // Extract the edge with the smallest weight
            var edge = priorityQueue.First();
            priorityQueue.Remove(edge);

            var node1 = edge.Nodes[0];
            var node2 = edge.Nodes[1];

            // Determine the next node to add to the MST
            var nextNode = visited.Contains(node1) ? node2 : node1;

            if (!visited.Contains(nextNode))
            {
                mstEdges.Add(edge);
                visited.Add(nextNode);

                // Add all edges from the new node to the priority queue
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
