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

            hud = new HUD(level.Player);
            level.Hud = hud; 
            hud.Draw();

            bool running = true;
            while (running)
            {
                var key = Console.ReadKey(true);


                int dx = 0, dy = 0;
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow: dy = -1; break;
                    case ConsoleKey.DownArrow: dy = 1; break;
                    case ConsoleKey.LeftArrow: dx = -1; break;
                    case ConsoleKey.RightArrow: dx = 1; break;
                    case ConsoleKey.Escape: running = false; continue;
                    default: continue;
                }

                level.TryMovePlayer(dx, dy);
                level.UpdateEnemies();

                hud.Draw();

                if (level.Player.HP <= 0)
                {
                    ShowGameOver();
                    return; // avsluta loopen när game over visas
                }
            }
            System.Threading.Thread.Sleep(50);

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
                    Run(); // starta om spelet
                    return;
                }
            }
        }
    }
}

