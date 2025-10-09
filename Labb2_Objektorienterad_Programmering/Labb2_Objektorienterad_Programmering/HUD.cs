using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Objektorienterad_Programmering
{
    public class HUD
    {
        private Player player;

        private string playerRoll = "";
        private string enemyRoll = "";

        public HUD(Player player)
        {
            this.player = player;
        }

        public void SetPlayerRoll(int attack, int defence, int damage)
        {
            playerRoll = $"Player: atk {attack}, def {defence}, dmg {damage}";
        }

        public void SetEnemyRoll(string enemyName, int attack, int defence, int damage)
        {
            enemyRoll = $"{enemyName}: atk {attack}, def {defence}, dmg {damage}";
        }

        public void Draw()
        {
            int hudY = Console.WindowHeight - 3;
            
            // Player HUD
            Console.SetCursorPosition(0, hudY);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, hudY);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"HP: {player.HP}   ");
            Console.ResetColor();
            Console.Write(playerRoll);

            // Enemy HUD
            Console.SetCursorPosition(0, hudY + 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, hudY + 1);
            Console.Write(enemyRoll);
        }
    }
}
