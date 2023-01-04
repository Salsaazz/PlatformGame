using Microsoft.Xna.Framework;
using PlatformGame.Blocks;
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
        public void Move(Player player, Enemy blok)
        {
            Collide(player, blok);
            blok.Position += blok.Speed;
            blok.BoundingBox = new Rectangle((int)blok.Position.X, (int)blok.Position.Y, blok.TextureWidth, blok.TextureHeight);
        }
        public abstract void Collide(Player player, Enemy enemy);
    }
}
