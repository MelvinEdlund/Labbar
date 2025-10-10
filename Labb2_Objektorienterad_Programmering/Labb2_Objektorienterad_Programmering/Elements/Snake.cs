using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Objektorienterad_Programmering.Elements
{
    internal class Snake : Enemy
    {
        public Snake(int x, int y) : base(x, y, 's', ConsoleColor.Green, "Snake", 5)
        {
            AttackDice = new Dice(3, 4, 2);
            DefenceDice = new Dice(1, 7, 5);
        }
        public override void Update(LevelData level)
        {
            int dx = 0, dy = 0;

            int distX = Pos.X - level.Player.Pos.X;
            int distY = Pos.Y - level.Player.Pos.Y;
            double distance = Math.Sqrt(distX * distX + distY * distY);

            if (distance <= 2)
            {
                if (Math.Abs(distX) > Math.Abs(distY))
                    dx = distX > 0 ? 1 : -1; 
                else
                    dy = distY > 0 ? 1 : -1; 
            }

            level.TryMoveEnemy(this, dx, dy);
        }
    }
}
