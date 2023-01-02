using Microsoft.Xna.Framework;
using PlatformGame.Characters;
using PlatformGame.Enemies;
using PlatformGame.Interfaces;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Collision.Blocks
{
    internal class TileCollision : MovingBehavior
    {
        public override void Collide(Player player, Enemy enemy)
        {
            if (player.HitBox.RectangleBlock.Intersects(enemy.BoundingBox))
            {
                if (player.movementManager.Movable.Speed.X > 0 || player.movementManager.Movable.Speed.X < 0)
                {
                    player.movementManager.Movable.Speed = new Vector2(0, player.movementManager.Movable.Speed.Y);
                }

                if (player.movementManager.IsFalling)
                {
                    player.movementManager.jump = false;
                    player.movementManager.IsFalling = false;
                    player.movementManager.Movable.Speed = new Vector2(player.movementManager.Movable.Speed.X, 0);
                    player.movementManager.OnGround = true;
                }

                if (player.movementManager.pressY && !player.movementManager.IsFalling)
                {
                    player.movementManager.Movable.Speed = new Vector2(player.movementManager.Movable.Speed.X, 0);
                    player.movementManager.IsFalling = true;
                    player.movementManager.jump = false;
                    player.movementManager.pressY = false;
                }
            }

            else if (!player.movementManager.IsFalling
                && !player.movementManager.jump)
            {
                player.movementManager.IsFalling = true;
                player.movementManager.jump = false;
                player.movementManager.OnGround = false;
            }
            player.movementManager.futurePosition = player.movementManager.Movable.Position
                + player.movementManager.Movable.Speed;
        }
    }

}
