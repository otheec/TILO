using ResourceGraphTraversal.Services;

var graph = GraphProvider.GetGraph();
GraphSolver.Solve(graph);