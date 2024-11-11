using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoGraphs
{
    public class Node
    {
        protected string _name;
        protected List<Link> _links;

        public String Name { get => _name; set => _name = value; }
        public List<Link> Links { get => _links; protected set => _links = value; }

        public List<String> ConnetedToNodesNames { get => _links.Select(l => l.ClosingEnd).ToList(); }
        
        
        public Node(string name)
        {
            Name = name;
            Links = new List<Link>();
        }

        public Node() : this("dummy")
        { }

        public Node(Node copyNode) : this(copyNode.Name)
        {
            _links.AddRange(copyNode.Links);
        }


        



        public override bool Equals(object? obj)
        {
            return obj is Node node && Name == node.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }





        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name} }}";
        }

    }
}
