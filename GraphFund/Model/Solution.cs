namespace GraphFund.Model;

internal class Solution(int rozpocet, int zdroje, List<Node> path)
{
    public int rozpocet = rozpocet;
    public int zdroje = zdroje;
    public List<Node> path = path;

    private List<Node> GetAllUnvisited()
    {
        return path
            .Where(n => n.Childrens != null)
            .SelectMany(n => n.Childrens!)
            .Where(n => n != null && !path.Contains(n))
            .ToList();
    }

    public List<Solution> Run()
    {
        List<Solution> ret = [this];
        var allChildren = GetAllUnvisited();

        foreach (var child in allChildren)
        {
            if (child.ConnectionValue < rozpocet || child.ConnectionValue < rozpocet + zdroje)
            {
                var newPath = new List<Node>(path) { child };
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

                var nextSol = new Solution(newRozpocet, newZdroje, newPath);
                ret.AddRange(nextSol.Run());
            }
        }

        return ret;
    }
}
