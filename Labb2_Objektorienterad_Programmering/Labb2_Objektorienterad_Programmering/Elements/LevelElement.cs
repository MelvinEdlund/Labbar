using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Objektorienterad_Programmering.Elements
{
    public abstract class LevelElement
    {
        public Position Pos { get; set; }
        protected char Symbol { get; set; }
        protected ConsoleColor Color { get; set; }

        public LevelElement(int x, int y, char symbol, ConsoleColor color)
        {
            Pos = new Position(x, y);
            Symbol = symbol;
            Color = color;
        }
        public void Draw (ConsoleColor? overrideColor = null)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(Pos.X, Pos.Y);
            Console.ForegroundColor = overrideColor ?? Color;
            Console.Write(Symbol);
            Console.ResetColor();
        }
        public void Move(int dx, int dy)
        {
            Pos = Pos.Offset(dx, dy);
        }

        public bool IsVisible(Player player, int visionRange)
        {
            return Pos.DistanceTo(player.Pos) <= visionRange;
        }
    }
}
