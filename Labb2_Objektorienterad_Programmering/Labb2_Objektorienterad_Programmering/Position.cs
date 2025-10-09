using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Objektorienterad_Programmering
{
    public struct Position
    {
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        // förflyttad Position
        public Position Offset(int dx, int dy)
        {
            return new Position(X + dx, Y + dy);
        }

        //  (för vision range)
        public double DistanceTo(Position other)
        {
            int dx = X - other.X;
            int dy = Y - other.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        // Gör att Position kan jämföras i HashSet och Dictionary
        public override bool Equals(object obj)
        {
            return obj is Position p && p.X == X && p.Y == Y;
        }

        public override int GetHashCode()
        {
            return (X, Y).GetHashCode();
        }
    }
}
