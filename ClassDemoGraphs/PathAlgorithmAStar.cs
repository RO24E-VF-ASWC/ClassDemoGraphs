using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassDemoGraphs
{
    public class PathAlgorithmAStar
    {
        // general
        private Graph _graph;
        private PriorityQueue<AstarNode, double> _openList;

        // for each pathfinding
        private IHeuristica _h;
        private List<AstarNode> _closedList;


        public PathAlgorithmAStar(Graph graph)
        {
            _graph = CopyGraph(graph);
            _openList = new PriorityQueue<AstarNode, double>(new MinValue());
        }

        private Graph CopyGraph(Graph graph)
        {
            Graph resGraph = new Graph();

            foreach (var node in graph.Nodes)
            {
                resGraph.AddNode(new AstarNode((AstarNode)node));
            }

            return resGraph;
        }

        public List<Link> AStarPath(AstarNode startNode, AstarNode endNode, IHeuristica h)
        {
            //_openList = new PriorityQueue<AstarNode, double>();
            _closedList = new List<AstarNode>();
            _h = h;

            AstarNode current = startNode;
            _openList.Enqueue(startNode, _h.Heuristica(startNode, endNode));
            while (_openList.Count > 0 && !_closedList.Exists(x => x.Pos == endNode.Pos))
            {
                current = _openList.Dequeue();
                _closedList.Add(current);

                foreach(String nname in current.ConnetedToNodesNames)
                {
                    AstarNode n = (AstarNode)_graph.GetNodeByName(nname);
                    Link currentLink = current.Links.First(
                        l => l.StartingEnd == current.Name && l.ClosingEnd == nname
                        );

                    if (!_closedList.Contains(n))
                    {
                        bool isFound = false;

                        foreach(var node in _openList.UnorderedItems)
                        {
                            if (node.Element == n)
                            {
                                isFound = true;
                            }
                        }

                        if (!isFound)
                        {
                            n.parentPath.AddRange(current.parentPath);
                            n.parentPath.Add(currentLink);

                            double dist = h.Heuristica(n, endNode);
                            double weight = n.parentPath.Sum(l => l.Weight);
                            _openList.Enqueue(n, dist + weight);
                        }
                    }
                }
            }

            // construct path, if end was not closed return null
            AstarNode? goalNode = _closedList.Find( n => n.Pos == endNode.Pos );

            if ( goalNode == null )
            {
                throw new ArgumentException("No Path");
            }

            //goalNode.parentPath.Reverse();
            return goalNode.parentPath;
        }

        private Graph DoAStar()
        {
            throw new NotImplementedException();
        }
    }

    internal class MinValue : IComparer<double>
    {
        public int Compare(double x, double y)
        {
            return y.CompareTo(x);
        }
    }
}
