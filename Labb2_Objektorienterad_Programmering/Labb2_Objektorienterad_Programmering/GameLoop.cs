using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Objektorienterad_Programmering
{
    public class GameLoop
    {
        private LevelData level;
        private HUD hud;

        public void Run()
        {
            Console.Clear();

            level = new LevelData();
            level.Load("Level1.txt");

            hud = new HUD(level.Player, level);
            level.Hud = hud;
            level.Combat = new CombatManager(hud);
            hud.Draw();

            bool running = true;
            while (running)
            {
                int dx = 0, dy = 0;

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;

                    switch (key)
                    {
                        case ConsoleKey.UpArrow: dy = -1; break;
                        case ConsoleKey.DownArrow: dy = 1; break;
                        case ConsoleKey.LeftArrow: dx = -1; break;
                        case ConsoleKey.RightArrow: dx = 1; break;
                        case ConsoleKey.Escape: running = false; continue;
                    }

                    while (Console.KeyAvailable) Console.ReadKey(true);
                }

                if (dx != 0 || dy != 0)
                {
                    level.TryMovePlayer(dx, dy);
                    level.UpdateEnemies();
                    hud.Draw();
                }
                System.Threading.Thread.Sleep(100);
            }
        }

        public void ShowGameOver()
        {
            Console.Clear();

            string text = "GAME OVER ";
            string retry = "Press R to restart or ESC to quit";

            int centerX = (Console.WindowWidth - text.Length) / 2;
            int centerY = Console.WindowHeight / 2;

            Console.SetCursorPosition(centerX, centerY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();

            Console.SetCursorPosition((Console.WindowWidth - retry.Length) / 2, centerY + 2);
            Console.WriteLine(retry);

            while (true)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
                else if (key == ConsoleKey.R)
                {
                    Run();
                    return;
                }
            }
        }
    }
}

