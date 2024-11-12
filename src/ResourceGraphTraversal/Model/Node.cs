namespace GraphFund.Model;
internal class Node
{
    public int ConnectionValue {  get; set; }
    public int NodeValue { get; set; }
    public List<Node>? Childrens { get; set; } = null;

    public Node(int connectionValue, int nodeValue, List<Node> childrens)
    {
        ConnectionValue = connectionValue;
        NodeValue = nodeValue;
        Childrens = childrens;
    }

    public Node(int connectionValue, int nodeValue)
    {
        ConnectionValue = connectionValue;
        NodeValue = nodeValue;
        Childrens = null;
    }
}
