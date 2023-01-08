using Microsoft.Xna.Framework;
using PlatformGame.Blocks.Enemies;
using PlatformGame.Characters;
using PlatformGame.Interfaces;
using PlatformGame.Movement.BlockMovement.Damage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Movement.BlockMovement
{
    internal class Moving : IMovingBehavior, IDamageBehavior
    {
        public void Move(Player player, Enemy enemy)
        {
            Damage(player, enemy);
            if (enemy.Position.X > 1000 - 50 || enemy.Position.X < 0)
            {
                enemy.Speed = new Vector2(enemy.Speed.X * -1, enemy.Speed.Y);
            }
            else if (player.HitBox.Intersects(enemy.BoundingBox))
            {
                enemy.Speed = new Vector2(enemy.Speed.X * -1, enemy.Speed.Y);
            }
        }

        public void Damage(Player player, Enemy enemy)
        {
            if (player.HitBox.Intersects(enemy.BoundingBox) && !enemy.IsDead)
            {
                if (player.movementManager.IsFalling && player.HitBox.Bottom - 5 < enemy.BoundingBox.Top)
                {
                    enemy.IsDead = true;
                }
                else if (player.gameTimer.Counter >= 1000)
                {
                    player.Health -= enemy.Damage;
                    player.gameTimer.Counter = 0;
                }
            }
        }
    }
}
