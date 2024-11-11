using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoGraphs
{
    public class AstarNode:Node
    {
        public Posistion Pos { get; set; }
        public List<Link> parentPath { get; set;  }
        
        public AstarNode(string name, int posX, int posY):base(name)
        {
            Pos = new Posistion();
            Pos.X = posX;
            Pos.Y = posY;
            parentPath = new List<Link>(); ;
        }

        public AstarNode(string name) : this(name, 1, 1)
        {
        }

        public AstarNode() : this("dummy", 1, 1)
        { }

        public AstarNode(AstarNode copyNode) : this(copyNode.Name, copyNode.Pos.X, copyNode.Pos.Y)
        {
            Links.AddRange(copyNode.Links);
        }

        public override string ToString()
        {
            return $"{{{nameof(Pos)}={Pos}, {nameof(Name)}={Name}, {nameof(Links)}={Links}}}";
        }
    }
}
