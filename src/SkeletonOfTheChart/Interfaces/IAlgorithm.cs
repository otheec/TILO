using SkeletonOfTheChart.Model;

namespace SkeletonOfTheChart.Interfaces;

internal interface IAlgorithm
{
    List<Edge> Solve();
}
