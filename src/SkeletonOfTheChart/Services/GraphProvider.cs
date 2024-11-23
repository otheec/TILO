using SkeletonOfTheChart.Model;

namespace SkeletonOfTheChart.Services;
internal class GraphProvider
{
    public static List<Edge> GetGraph()
    {
        Node Tristram = new Node("Tristram");
        Node Loard = new Node("Loard");
        Node Arraken = new Node("Arraken");
        Node Lanisport = new Node("Lanisport");
        Node Ankh = new Node("Ankh");
        Node Most = new Node("Most");
        Node LV = new Node("LV");
        Node Godric = new Node("Godric");
        Node Mordeihm = new Node("Mordeihm");
        Node Gondolin = new Node("Gondolin");
        Node MinasTirth = new Node("Minas Tirth");
        Node Rivie = new Node("Rivie");
        Node Solitude = new Node("Solitude");

        Edge e2 = new Edge(2, [Tristram, Loard]);
        Edge e9 = new Edge(9, [Arraken, Loard]);
        Edge e7 = new Edge(7, [Arraken, Tristram]);
        Edge e16 = new Edge(16, [Arraken, Lanisport]);
        Edge e24 = new Edge(24, [Arraken, Ankh]);
        Edge e10 = new Edge(10, [Lanisport, Ankh]);
        Edge e4 = new Edge(4, [Most, Ankh]);
        Edge e5 = new Edge(5, [Gondolin, Ankh]);
        Edge e20 = new Edge(20, [Gondolin, Most]);
        Edge e15 = new Edge(15, [Gondolin, Godric]);
        Edge e7_2 = new Edge(7, [LV, Most]);
        Edge e3 = new Edge(3, [LV, Godric]);
        Edge e5_2 = new Edge(5, [Gondolin, Mordeihm]);
        Edge e9_2 = new Edge(9, [Gondolin, MinasTirth]);
        Edge e8 = new Edge(8, [Mordeihm, MinasTirth]);
        Edge e4_2 = new Edge(8, [Tristram, MinasTirth]);
        Edge e3_2 = new Edge(3, [Rivie, MinasTirth]);
        Edge e1 = new Edge(1, [Godric, Mordeihm]);
        Edge e12 = new Edge(12, [Tristram, Rivie]);
        Edge e8_2 = new Edge(8, [Solitude, Rivie]);

        return
        [
            e2, e9, e7, e16, e24, e10, e4, e5, e20, e15, e7_2, e3, e5_2,
            e9_2, e8, e4_2, e3_2, e1, e12, e8_2
        ];
    }
}
