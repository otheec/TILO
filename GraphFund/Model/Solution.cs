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

        var allChildrens = GetAllUnvisited();

        for (int i = 0; i < allChildrens.Count; i++)
        {
            if (allChildrens[i].ConnectionValue < rozpocet)
            {
                var newPath = new List<Node>(path);
                newPath.Add(allChildrens[i]);

                var newRozpocet = rozpocet - allChildrens[i].ConnectionValue;
                var newZdroje = zdroje + allChildrens[i].NodeValue;

                var nextSol = new Solution(newRozpocet, newZdroje, newPath);
                ret.AddRange(nextSol.Run());
            }
        }

        return ret;
    }
}
