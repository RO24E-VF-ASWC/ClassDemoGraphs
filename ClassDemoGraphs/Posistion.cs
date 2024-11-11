﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoGraphs
{
    public class Posistion
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Posistion() : this(-1,-1)
        { }

        public Posistion(int x, int y)
        {
            X = x;
            Y = y;
        }


        public override bool Equals(object? obj)
        {
            return obj is Posistion posistion &&
                   X == posistion.X &&
                   Y == posistion.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static bool operator ==(Posistion left, Posistion right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(Posistion left, Posistion right)
        {
            return !(left == right);
        }


        public override string ToString()
        {
            return $"{{{nameof(X)}={X.ToString()}, {nameof(Y)}={Y.ToString()}}}";
        }

        
    }
}
