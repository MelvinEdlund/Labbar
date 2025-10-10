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
        private LevelData level;
        private string playerRoll = "";
        private string enemyRoll = "";

        public HUD(Player player, LevelData level)
        {
            this.player = player;
            this.level = level;
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
            int hudY = Console.WindowHeight - 4;

            WriteLine(0, hudY, $"HP: {player.HP}   Round: {level.Round}", ConsoleColor.Yellow);

            WriteLine(0, hudY + 1, playerRoll);

            WriteLine(0, hudY + 2, enemyRoll);
        }

        private void WriteLine(int x, int y, string text, ConsoleColor? color = null)
        {
            if (y < 0 || y >= Console.WindowHeight) return;

            Console.SetCursorPosition(x, y);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(x, y);

            if (color != null) Console.ForegroundColor = color.Value;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
