using Labb2_Objektorienterad_Programmering.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Labb2_Objektorienterad_Programmering
{
    public class CombatManager
    {
        private HUD hud;

        public CombatManager(HUD hud)
        {
            this.hud = hud;
        }
        public void ResolveCombat(Player player, Enemy enemy, bool playerAttacksFirst, List<LevelElement> elements)
        {
            if (playerAttacksFirst)
            {
                PlayerAttacksEnemy(player, enemy);
                if (enemy.HP > 0) 
                    EnemyAttacksPlayer(enemy, player);
            }
            else
            {
                EnemyAttacksPlayer(enemy, player);
                if (player.HP > 0) 
                    PlayerAttacksEnemy(player, enemy);
            }

            if (enemy.HP <= 0)
            {
                hud?.SetEnemyRoll(enemy.Name, 0, 0, 0);
                Console.SetCursorPosition(enemy.Pos.X, enemy.Pos.Y);
                Console.Write(' ');
                elements.Remove(enemy);
            }

            if (player.HP <= 0)
            {
                new GameLoop().ShowGameOver();
            }
        }
        private void PlayerAttacksEnemy(Player player, Enemy enemy)
        {
            int attack = player.AttackDice.Throw();
            int defence = enemy.DefenceDice.Throw();
            int damage = attack - defence;
            if (damage > 0) enemy.TakeDamage(damage);

            hud?.SetPlayerRoll(attack, defence, Math.Max(0, damage));
        }
        private void EnemyAttacksPlayer(Enemy enemy, Player player)
        {
            int attack = enemy.AttackDice.Throw();
            int defence = player.DefenceDice.Throw();
            int damage = attack - defence;
            if (damage > 0) player.TakeDamage(damage);

            hud?.SetEnemyRoll(enemy.Name, attack, defence, Math.Max(0, damage));
        }
    }
}
