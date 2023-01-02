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
    internal interface IMovingbehavior : ICollide
    {
        public void Move(Player player, Enemy enemy)
        {
            Collide(player, enemy);
            enemy.Position += enemy.Speed;
            enemy.BoundingBox = new Rectangle((int)enemy.Position.X, (int)enemy.Position.Y, 50, enemy.Texture.Height);
        }
        public abstract void Collide(Player player, Enemy enemy);
    }
}
