using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoGraphs
{
    public interface IHeuristica
    {
        public double Heuristica(AstarNode from, AstarNode to);
    }
}
