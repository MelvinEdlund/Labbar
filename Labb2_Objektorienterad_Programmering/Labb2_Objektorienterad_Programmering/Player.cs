using Labb2_Objektorienterad_Programmering.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Labb2_Objektorienterad_Programmering
{
    public class Player : LevelElement
    {
        public int HP { get; protected set; }
        public Dice AttackDice { get; set; }
        public Dice DefenceDice { get; set; }
        public Player(int x, int y) : base(x, y, '@', ConsoleColor.Yellow)
        {
            HP = 100;
            AttackDice = new Dice(2, 6, 2);
            DefenceDice = new Dice(2, 6, 0);
        }

        public void TakeDamage(int amount)
        {
            if (amount <= 0) return;
            HP -= amount;
            if (HP < 0) HP = 0;
        }
    }
}
