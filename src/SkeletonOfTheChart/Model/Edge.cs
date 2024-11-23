namespace SkeletonOfTheChart.Model;

internal class Edge(int value, List<Node> nodes)
{
    public int Value { get; set; } = value;
    public List<Node> Nodes { get; set; } = nodes;
}
