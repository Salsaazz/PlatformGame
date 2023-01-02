using Microsoft.Xna.Framework;
using PlatformGame.Characters;
using PlatformGame.Collision.Blocks;
using PlatformGame.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Collision
{
    internal class KillWithDamage : DamageBehavior
    {
        public override void Damage(Player player, Enemy enemy)
        {
            if (player.HitBox.RectangleBlock.Intersects(enemy.BoundingBox) && !enemy.IsDead)
            {
                if (player.movementManager.IsFalling && player.HitBox.RectangleBlock.Bottom-5 < enemy.BoundingBox.Top)
                {
                    //kill enemy
                    enemy.IsDead = true;
                }
                 else if (player.gameTimer.Counter >= 1000 )
                {
                    player.Health -= enemy.Damage;
                    player.gameTimer.Counter = 0;
                }
                //running away after getting hit
                //enemy.Speed = new Vector2(enemy.Speed.X * -1, enemy.Speed.Y);

            }
        }
    }
}
