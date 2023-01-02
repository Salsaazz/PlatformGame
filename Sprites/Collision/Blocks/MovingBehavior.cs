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

namespace PlatformGame.Collision.Blocks
{
    abstract class MovingBehavior : ICollide
    {
        public void Move(Player player, Enemy enemy)
        {
            Collide(player, enemy);
            enemy.Position += enemy.Speed;
            enemy.BoundingBox = new Rectangle((int)enemy.Position.X, (int)enemy.Position.Y, enemy.textureWidth, enemy.textureHeight);
        }
        public abstract void Collide(Player player, Enemy enemy);
    }
}
