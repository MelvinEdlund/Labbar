using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Objektorienterad_Programmering
{
    public class Dice
    {
        private readonly int numberOfDice;
        private readonly int sidesPerDice;
        private readonly int modifier;
        private static readonly Random rnd = new Random();

        public Dice (int numberOfDice, int sidesPerDice, int modifier)
        {
            this.numberOfDice = numberOfDice;
            this.sidesPerDice = sidesPerDice;
            this.modifier = modifier;
        }

        public int Throw()
        {
            int total = 0;
            for (int i = 0; i < numberOfDice; i++)
            {
                total += rnd.Next(1, sidesPerDice + 1);
            }
            total += modifier;
            return total;
        }

        public override string ToString()
        {
            string mod;
            if (modifier >= 0) mod = "+" + modifier;
            else mod = modifier.ToString();
            return numberOfDice + "d" + sidesPerDice + mod;
        }
    }
}
