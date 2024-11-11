using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoGraphs
{
    public class Graph
    {
        private readonly Dictionary<String, Node> _nodes;

        public List<Node> Nodes => _nodes.Values.ToList();


        public Graph() 
        { 
            _nodes = new Dictionary<String, Node>();
        }

        
        public void AddNode(Node newNode)
        {
            _nodes.Add(newNode.Name, newNode);
        }

        public void AddEdge(String startNodeName, string endNodeName, int weight)
        {
            Node startNode = _nodes[startNodeName];
            Node endNode = _nodes[endNodeName];

            startNode.Links.Add(new Link(startNodeName, endNodeName, weight));
            endNode.Links.Add(new Link(endNodeName,startNodeName, weight));
        }

        public void AddEdge(Link link)
        {
            AddEdge(link.StartingEnd,link.ClosingEnd,link.Weight);
        }

        public void PrintGraph(String nameOfStartingNode)
        {
            Node? startNode = (_nodes.ContainsKey(nameOfStartingNode)) ? _nodes[nameOfStartingNode]:null;    
            
            PrintNode(startNode);
        }


        private List<Node> _visitNodes = new List<Node>();
        private void PrintNode(Node? startNode)
        {
            if (startNode is null)
            {
                Console.WriteLine("No graph");
                return;
            }
            _visitNodes.Clear();
            PrintNodeRec(startNode);
        }
        private void PrintNodeRec(Node? startNode)
        {

            if (startNode is null)
            {
                return;
            }

            if (!_visitNodes.Contains(startNode))
            {
                _visitNodes.Add(startNode);
                Console.WriteLine("Node :" + startNode.Name);
                List<Node> nodes = new List<Node>();
                foreach (Link link in startNode.Links)
                {

                        Console.WriteLine($"{startNode.Name} - {link.Weight} - {link.ClosingEnd}");
                        nodes.Add(_nodes[link.ClosingEnd]);
                }

                foreach (Node n in nodes)
                {
                    PrintNodeRec(n);
                }
            }
        }

        public Node? GetNodeByName(string name)
        {
            if (_nodes.ContainsKey(name))
            {
                return _nodes[name];
            }
            return null;
        }
        public bool IsInGraph(String NodeName)
        {
            return _nodes.ContainsKey(NodeName);
        }

        public override string ToString()
        {
            return $"{{{nameof(Nodes)}={Nodes}}}";
        }
    }
}
