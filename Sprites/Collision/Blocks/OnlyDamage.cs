using PlatformGame.Characters;
using PlatformGame.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Collision.Blocks
{
    internal class OnlyDamage : DamageBehavior
    {
        public override void Damage(Player player, Enemy enemy)
        {
            if (player.HitBox.RectangleBlock.Intersects(enemy.BoundingBox))
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
