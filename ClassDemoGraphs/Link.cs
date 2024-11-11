using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoGraphs
{
    public class Link
    {
        private String? _startingEnd;
        private String? _closingEnd;
        private int _weight;

        public String? StartingEnd { get => _startingEnd; set => _startingEnd = value; }
        public String? ClosingEnd { get => _closingEnd; set => _closingEnd = value; }
        public int Weight { get => _weight; set => _weight = value; }

        public Link(String? startingEnd, String? closingEnd, int weight)
        {
            StartingEnd = startingEnd;
            ClosingEnd = closingEnd;
            Weight = weight;
        }

        public Link():this(null,null,-1)
        {
        }

        public Link(Link copyLink) : this(copyLink.StartingEnd, copyLink.ClosingEnd, copyLink.Weight)
        {
        }



        public override bool Equals(object? obj)
        {
            Link? link = obj as Link;
            if (link == null) return false;

            return (EqualityComparer<String?>.Default.Equals(StartingEnd, link.StartingEnd) &&
                   EqualityComparer<String?>.Default.Equals(ClosingEnd, link.ClosingEnd)) ||
                   (EqualityComparer<String?>.Default.Equals(StartingEnd, link.ClosingEnd) &&
                   EqualityComparer<String?>.Default.Equals(ClosingEnd, link.StartingEnd));
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StartingEnd, ClosingEnd);
        }



        public override string ToString()
        {
            return $"{{{nameof(StartingEnd)}={StartingEnd}, {nameof(ClosingEnd)}={ClosingEnd}, {nameof(Weight)}={Weight.ToString()}}}";
        }
    }
}
