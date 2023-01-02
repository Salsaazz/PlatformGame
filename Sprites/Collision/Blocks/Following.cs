using Microsoft.Xna.Framework;
using PlatformGame.Characters;
using PlatformGame.Enemies;
using PlatformGame.Interfaces;
using PlatformGame.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlatformGame.Collision.Blocks
{
    internal class Following : MovingBehavior
    {
        DamageBehavior damageBehavior = new OnlyDamage();
        public override void Collide(Player player, Enemy enemy)
        {
            damageBehavior.Damage(player, enemy);
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
            //sta still
            else enemy.Speed = Vector2.Zero;
        }
    }
}
