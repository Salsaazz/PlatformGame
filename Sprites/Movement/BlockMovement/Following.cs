using Microsoft.Xna.Framework;
using PlatformGame.Blocks.Enemies;
using PlatformGame.Characters;
using PlatformGame.Interfaces;
using PlatformGame.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlatformGame.Movement.BlockMovement
{
    internal class Following : IMovingBehavior, IDamageBehavior
    {
        public void Move(Player player, Enemy enemy)
        {
            Damage(player, enemy);
            if (enemy.Position.X - 20 > player.Position.X && enemy.Position.X > player.Position.X)
            {
                enemy.Speed = new Vector2(-1, 0);
                enemy.IsLeft = true;
            }
            else if (enemy.Position.X + 20 < player.Position.X && enemy.Position.X < player.Position.X)
            {
                enemy.Speed = new Vector2(1, 0);
                enemy.IsLeft = false;
            }
            else enemy.Speed = Vector2.Zero;
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
