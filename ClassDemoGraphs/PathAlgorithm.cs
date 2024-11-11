using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoGraphs
{
    public class PathAlgorithm
    {
        private Graph _graph;
        private List<Node> _nodes;
        private Graph _inOSPFGraph;


        public PathAlgorithm(Graph graph)
        {
            _graph = CopyGraph(graph);
            _nodes = new List<Node>();
        }

        private Graph CopyGraph(Graph graph)
        {
            Graph resGraph = new Graph();

            foreach (var node in graph.Nodes)
            {
                resGraph.AddNode(new Node(node));
            }
            
            return resGraph;
        }

        public Graph LinkStatePathOSPF(Node startNode)
        {
            _inOSPFGraph = new Graph();
            _nodes.Add(startNode);

            // opbyg korteste vej graf
            Node node = new Node(startNode);
            node.Links.Clear();
            _inOSPFGraph.AddNode(node);

            return DoOSPF();
        }

        protected Graph DoOSPF()
        {
            if (AllNodesInOSPF())
            {
                return _inOSPFGraph;
            }

            // find shortest from nodes in OSPF
            Link? shortest = null;
            foreach (Node node in _nodes)
            {
                foreach (Link link in node.Links)
                {
                    if (!_nodes.Contains(_inOSPFGraph.GetNodeByName(link.ClosingEnd)))
                    {
                        if (shortest is null)
                        {
                            shortest = link;
                        }
                        else
                        {
                            shortest = (shortest.Weight > link.Weight)?link:shortest;
                        }
                    }
                }
            }

            // shortest has shortest link 
            Node chosenNode = _graph.GetNodeByName(shortest.ClosingEnd);
            _nodes.Add(chosenNode);

            Node copynode = new Node(chosenNode);
            copynode.Links.Clear();
            _inOSPFGraph.AddNode(copynode);
            _inOSPFGraph.AddEdge(shortest);

            return DoOSPF(); 
        }

        private bool AllNodesInOSPF()
        {
            return _inOSPFGraph.Nodes.Count == _graph.Nodes.Count;
        }
    }
}
