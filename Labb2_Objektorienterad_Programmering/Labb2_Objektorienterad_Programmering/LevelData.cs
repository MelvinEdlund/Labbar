using Labb2_Objektorienterad_Programmering.Elements;
using Labb2_Objektorienterad_Programmering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Labb2_Objektorienterad_Programmering
{
    public class LevelData
    {
        private static readonly Random rng = new Random();
        public HUD Hud { get; set; } 

        private List<LevelElement> elements = new List<LevelElement>();
        public IReadOnlyList<LevelElement> Elements => elements;

        private HashSet<Position> discoveredWalls = new HashSet<Position>();
        public Player Player { get; private set; }
        public int Round { get; private set; } = 1;
        public CombatManager Combat { get; set; }

        public void Load(string filename)
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Levels", "Level1.txt");
            var lines = File.ReadAllLines(path);


            for ( int y = 0; y < lines.Length; y++ )
            {
                string line = lines[y];

                for (int x = 0; x < line.Length; x++)
                {
                    char symbol = line[x];
                    switch (symbol)
                    {
                        case '#':
                            elements.Add(new Wall(x, y));
                            break;
                        case 'r':
                            elements.Add(new Rat(x, y));
                            break;
                        case 's':
                            elements.Add(new Snake(x, y));
                            break;
                        case '@':
                            var player = new Player(x, y);
                            elements.Add(player);
                            Player = player;
                            break;
                    }
                }
            }
            DrawVisibleArea(5);    

        }
        private bool IsBlocked(Position pos)
        {
            return elements.Any(e => e is Wall && e.Pos.X == pos.X && e.Pos.Y == pos.Y);
        }

        public bool TryMovePlayer(int dx, int dy)
        {
            if (Player == null) return false;

            var targetPos = Player.Pos.Offset(dx, dy);
            var enemy = FindEnemyAt(targetPos);

            if (enemy != null)
            {
                Combat.ResolveCombat(Player, enemy, true, elements);
                Round++;
                return true;
            }

            if (IsBlocked(targetPos)) return false;

            Console.SetCursorPosition(Player.Pos.X, Player.Pos.Y);
            Console.Write(' ');
            Player.Pos = targetPos;
            Player.Draw();

            DrawVisibleArea(5);
            Round++;
            return true;
        }

        public bool TryMoveEnemy(Enemy enemy, int dx, int dy)
        {
            if (dx == 0 && dy == 0) return false;

            var targetPos = enemy.Pos.Offset(dx, dy);

            if (IsPlayerAt(targetPos))
            {
                Combat.ResolveCombat(Player, enemy, playerAttacksFirst: false, elements);
                return true;
            }

            if (IsBlocked(targetPos) || FindEnemyAt(targetPos) != null)
                return false;

            Console.SetCursorPosition(enemy.Pos.X, enemy.Pos.Y);
            Console.Write(' ');
            enemy.Pos = targetPos;
            return true;
        }
        public void UpdateEnemies()
        {
            foreach (var enemy in elements.OfType<Enemy>().ToList())
            {
                enemy.Update(this);
            }
            DrawVisibleArea(5);

        }

        private Enemy FindEnemyAt(Position pos)
        {
            return elements.OfType<Enemy>().FirstOrDefault(e => e.Pos.X == pos.X && e.Pos.Y == pos.Y);
        }

        private bool IsPlayerAt(Position pos)
        {
            return Player != null && Player.Pos.X == pos.X && Player.Pos.Y == pos.Y;
        }

        public void DrawVisibleArea(int visionRange)
        {
            foreach (var element in elements)
            {
                if (element is Wall wall)
                {
                    if (element.IsVisible(Player, visionRange))
                    {
                        discoveredWalls.Add(element.Pos);
                        wall.Draw(ConsoleColor.White);
                    }
                    else if (discoveredWalls.Contains(element.Pos))
                    {
                        wall.Draw(ConsoleColor.DarkGray);
                    }
                }
                else
                {
                    if (element.IsVisible(Player, visionRange))
                    {
                        element.Draw();
                    }
                    else
                    {
                        Console.SetCursorPosition(element.Pos.X, element.Pos.Y);
                        Console.Write(' ');
                    }
                }
            }
            Player.Draw();
        }

    }
}
