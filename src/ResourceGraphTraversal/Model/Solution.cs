namespace GraphFund.Model;
internal class Solution(int rozpocet, int zdroje, List<Node> visitedNodes)
{
    public int rozpocet = rozpocet;
    public int zdroje = zdroje;
    public List<Node> visitedNodes = visitedNodes;

    private List<Node> GetUnvisitedChildrens()
    {
        return visitedNodes
            .Where(n => n.Childrens != null)
            .SelectMany(n => n.Childrens!)
            .Where(n => n != null && !visitedNodes.Contains(n))
            .ToList();
    }

    public List<Solution> Run()
    {
        List<Solution> ret = [this];
        var allChildren = GetUnvisitedChildrens();

        foreach (var child in allChildren)
        {
            if (child.ConnectionValue < rozpocet || child.ConnectionValue < rozpocet + zdroje)
            {
                var newVisitedNodes = new List<Node>(visitedNodes) { child };
                int newRozpocet, newZdroje;

                if (child.ConnectionValue < rozpocet)
                {
                    newRozpocet = rozpocet - child.ConnectionValue;
                    newZdroje = zdroje + child.NodeValue;
                }
                else
                {
                    newRozpocet = 0;
                    newZdroje = zdroje + (rozpocet - child.ConnectionValue);
                }

                var nextSol = new Solution(newRozpocet, newZdroje, newVisitedNodes);
                ret.AddRange(nextSol.Run());
            }
        }

        return ret;
    }
}
