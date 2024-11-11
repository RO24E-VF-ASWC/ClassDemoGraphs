using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoGraphs
{
    public class SimpleHeuristica : IHeuristica
    {
        public double Heuristica(AstarNode from, AstarNode to)
        {
            return 
                Math.Abs(from.Pos.X - to.Pos.X) + 
                Math.Abs(from.Pos.Y - to.Pos.Y);
        }
    }
}
