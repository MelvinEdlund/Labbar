using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Objektorienterad_Programmering.Elements
{
    internal class Rat : Enemy
    {
        public Rat(int x, int y) : base(x, y, 'r', ConsoleColor.Red, "Rat", 10)
        {
            AttackDice = new Dice(1, 6, 3);
            DefenceDice = new Dice(1, 6, 1);
        }
        public override void Update(LevelData level)
        {
            int r = rng.Next(4);
            int dx = 0, dy = 0;
            switch (r)
            {
                case 0: dy = -1; break;
                case 1: dy = 1; break;
                case 2: dx = -1; break;
                case 3: dx = 1; break;
            }
            level.TryMoveEnemy(this, dx, dy);
        }

    }
}
