﻿using Microsoft.Xna.Framework;
using PlatformGame.Characters;
using PlatformGame.Collision.Blocks.Damage;
using PlatformGame.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Collision.Blocks
{
    internal class Moving : IMovingBehavior, IDamageBehavior
    {
        //DamageBehavior damageBehavior = new KillWithDamage();
        public void Collide(Player player, Enemy enemy)
        {
            //damageBehavior.Damage(player, enemy);
            Damage(player, enemy);
            if (enemy.Position.X > 800 - 50 || enemy.Position.X < 0)
            {
                enemy.Speed = new Vector2(enemy.Speed.X * -1, enemy.Speed.Y);
            }
            else if (player.HitBox.Intersects(enemy.BoundingBox))
            {
                enemy.Speed = new Vector2(enemy.Speed.X * -1, enemy.Speed.Y);
            }
            else enemy.Speed = enemy.Speed;
        }

        public void Damage(Player player, Enemy enemy)
        {
            if (player.HitBox.Intersects(enemy.BoundingBox) && !enemy.IsDead)
            {
                if (player.movementManager.IsFalling && player.HitBox.Bottom - 5 < enemy.BoundingBox.Top)
                {
                    //kill enemy
                    enemy.IsDead = true;
                }
                else if (player.gameTimer.Counter >= 1000)
                {
                    player.Health -= enemy.Damage;
                    player.gameTimer.Counter = 0;
                }
                //running away after getting hit
            }
        }
    }
}
