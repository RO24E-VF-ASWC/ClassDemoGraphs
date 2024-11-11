using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoGraphs
{
    public class PythagorasHeuristica : IHeuristica
    {
        public double Heuristica(AstarNode from, AstarNode to)
        {
            return Math.Sqrt(
              Math.Pow(to.Pos.X - from.Pos.X, 2) +
              Math.Pow(to.Pos.Y - from.Pos.Y, 2)
              );
        }
    }
}
