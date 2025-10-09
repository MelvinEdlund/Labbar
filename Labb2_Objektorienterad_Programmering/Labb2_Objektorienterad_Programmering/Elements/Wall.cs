using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Objektorienterad_Programmering.Elements
{
    internal class Wall : LevelElement
    {
        public Wall(int x, int y) : base(x, y, '#', ConsoleColor.Gray)
        {
        }
    }
}
