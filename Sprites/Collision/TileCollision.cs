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

namespace PlatformGame.Collision
{
    internal class TileCollision : Collision
    {
        public override void Movement(Player player, Enemy enemy)
        {
            if (player.HitBox.RectangleBlock.Intersects(enemy.HitBox.RectangleBlock))
            {
                if (player.movementManager.Movable.Speed.X > 0 || player.movementManager.Movable.Speed.X < 0)
                {
                    player.movementManager.Movable.Speed = new Vector2(0, player.movementManager.Movable.Speed.Y);
                }

                if (player.movementManager.isFalling)
                {
                    player.movementManager.jump = false;
                    player.movementManager.isFalling = false;
                    player.movementManager.Movable.Speed = new Vector2(player.movementManager.Movable.Speed.X, 0);
                    player.movementManager.onGround = true;
                }

                if (player.movementManager.pressY && !player.movementManager.isFalling)
                {
                    player.movementManager.Movable.Speed = new Vector2(player.movementManager.Movable.Speed.X, 0);
                    player.movementManager.isFalling = true;
                    player.movementManager.jump = false;
                    player.movementManager.pressY = false;
                }
            }
       
        else if (!player.movementManager.isFalling
            && !player.movementManager.jump)
            {
                player.movementManager.isFalling = true;
                player.movementManager.jump = false;
                player.movementManager.onGround = false;
            }
            player.movementManager.futurePosition = player.movementManager.Movable.Position 
                + player.movementManager.Movable.Speed;
        }
    }
    
}
