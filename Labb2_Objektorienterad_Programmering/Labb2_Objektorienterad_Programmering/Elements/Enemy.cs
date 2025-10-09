using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Labb2_Objektorienterad_Programmering.Elements
{
    public abstract class Enemy : LevelElement
    {
        protected static readonly Random rng = new Random();

        public string Name { get; protected set; }
        public int HP { get; set; }
        public Dice AttackDice { get; set; }
        public Dice DefenceDice { get; set; }

        public Enemy(int x, int y, char symbol, ConsoleColor color, string name, int hp) 
            : base(x, y, symbol, color)
        {
            Name = name;
            HP = hp;
        }

        public abstract void Update(LevelData level);

        public void TakeDamage(int amount)
        {
            if (amount <= 0) return;
            HP -= amount;
            if (HP < 0) HP = 0;
        }
    }
}