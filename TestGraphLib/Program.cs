// See https://aka.ms/new-console-template for more information
using ClassDemoGraphs;
using System.Reflection.Metadata;

Console.WriteLine("Hello, World!");


Graph graph = new Graph();
AstarNode u = new AstarNode("u", 0, 0);
AstarNode v = new AstarNode("v", 10, 0);
AstarNode x = new AstarNode("x", 10, 10);
AstarNode y = new AstarNode("y", 20, 10);
AstarNode w = new AstarNode("w", 20, 20);
AstarNode z = new AstarNode("z", 30, 30);

graph.AddNode(u);
graph.AddNode(v);
graph.AddNode(x);
graph.AddNode(y);
graph.AddNode(z);
graph.AddNode(w);



graph.AddEdge("u", "v", 2);
graph.AddEdge("u", "x", 1);
graph.AddEdge("u", "w", 5);

graph.AddEdge("v", "x", 2);
graph.AddEdge("v", "w", 3);

graph.AddEdge("x", "w", 3);
graph.AddEdge("x", "y", 1);

graph.AddEdge("w", "y", 1);
graph.AddEdge("w", "z", 5);

graph.AddEdge("y", "z", 2);

graph.PrintGraph(u.Name);

//PathAlgorithm alg = new PathAlgorithm(graph);

//Console.WriteLine();
//Console.WriteLine(">>>>>>>>  OSPF   <<<<<<<<<<<<");
//Console.WriteLine();
//Graph resultGraph = alg.LinkStatePathOSPF(u);
//resultGraph.PrintGraph(u.Name);




PathAlgorithmAStar algStar = new PathAlgorithmAStar(graph);

Console.WriteLine();
Console.WriteLine(">>>>>>>>  Astar   <<<<<<<<<<<<");
Console.WriteLine();
List<Link> resultPath = algStar.AStarPath(u, z, new SimpleHeuristica());
foreach (Link l in resultPath)
{
    Console.Write(l.StartingEnd + " - ");
}
Console.WriteLine(z.Name);