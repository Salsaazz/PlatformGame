using Microsoft.Xna.Framework;
using PlatformGame.Blocks;
using PlatformGame.Characters;
using PlatformGame.Enemies;
using PlatformGame.Interfaces;
using PlatformGame.Movement;
using PlatformGame.Terrain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Collision
{
    internal class CollisionManager
    {
        bool isEnemy = false;
        bool isTile = false;
        bool isItem = false;
        public void Collide(bool hasCollided,MovementManager player, IMovable movable)
        {
            if (hasCollided)
            {

                //als het jumpt en collide --> topcollide
                //isfalling = true --> bottomcollide snehlheid=0
                //drukt op links of rechts --> snelheid(0,Y)

                //geef input
                //input => richting of valrichting
                //bereken toekomstige plaats adhv input
                //check of tp botst
                //nee positie = toekomst
                if (movable.Speed.X > 0 || movable.Speed.X < 0)
                {
                    movable.Speed = new Vector2(0, movable.Speed.Y);
                }

                if (player.isFalling)
                {
                    player.jump = false;
                    player.isFalling = false;
                    movable.Speed = new Vector2(movable.Speed.X, 0);
                    player.onGround = true;
                }

                if (player.pressY && !player.isFalling)
                {
                    movable.Speed = new Vector2(movable.Speed.X, 0);
                    player.isFalling = true;
                    player.jump = false;
                    player.pressY = false;
                }
            }
            if (!hasCollided   
            && !player.isFalling
            && !player.jump)
            {
                player.isFalling = true;
                player.jump = false;
                player.onGround = false;
            }
            player.futurePosition = movable.Position + movable.Speed;

        }

        public bool CollisionDetection(Rectangle rectangle, List<Tile> blockList)
        {
            foreach (var block in blockList)
            {
                if (rectangle.Intersects(block.HitBox.RectangleBlock))
                {
                    isTile = true;
                    isEnemy = false; 
                    isItem = false;
                    return true;
                }
            }
            return false;

        }
    }
}
