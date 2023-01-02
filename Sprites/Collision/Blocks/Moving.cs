using Microsoft.Xna.Framework;
using PlatformGame.Characters;
using PlatformGame.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Collision.Blocks
{
    internal class Moving : MovingBehavior
    {
        DamageBehavior damageBehavior = new KillWithDamage();
        public override void Collide(Player player, Enemy enemy)
        {
            damageBehavior.Damage(player, enemy);
            if (enemy.Position.X > 800 - 50 || enemy.Position.X < 0)
            {
                enemy.Speed = new Vector2(enemy.Speed.X * -1, enemy.Speed.Y);
            }
            else if (player.HitBox.RectangleBlock.Intersects(enemy.BoundingBox))
            {
                enemy.Speed = new Vector2(enemy.Speed.X * -1, enemy.Speed.Y);
            }
            else enemy.Speed = enemy.Speed;
            //BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, 50, 53);
        }

    }
}
