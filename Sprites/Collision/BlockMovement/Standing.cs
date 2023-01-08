using PlatformGame.Blocks.Enemies;
using PlatformGame.Characters;
using PlatformGame.Collision.Blocks.Damage;
using PlatformGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Collision.Blocks
{
    internal class Standing : IMovingBehavior, IDamageBehavior
    {
        public void Move(Player player, Enemy enemy)
        {
            Damage(player, enemy);
        }

        public void Damage(Player player, Enemy enemy)
        {
            if (player.HitBox.Intersects(enemy.BoundingBox))
            {
                if (player.gameTimer.Counter >= 1000)
                {
                    player.Health -= enemy.Damage;
                    player.gameTimer.Counter = 0;
                }
            }
        }
    }
}
