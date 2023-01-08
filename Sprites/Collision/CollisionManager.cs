using Microsoft.Xna.Framework;
using PlatformGame.Blocks;
using PlatformGame.Blocks.Enemies;
using PlatformGame.Characters;
using PlatformGame.Interfaces;
using PlatformGame.Movement;
using PlatformGame.Terrain;
using SharpDX.Direct2D1;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Collision
{
    class CollisionManager
    {
        Block collisionBlock;
        public void Collide(bool hasCollided, MovementManager movementManager, IMovable movable, Player player)
        {

            if (hasCollided)
            {


                if (collisionBlock is Fence)
                {
                    player.touchedGate = true;
                }
                else player.touchedGate = false;

                if (collisionBlock is Item)
                {
                    Item temp = collisionBlock as Item;
                    if (!temp.IsTaken && movementManager.pressDown)
                    { temp.IsTaken = true;
                        player.Item++;
                    }
                }
                 else if(!(collisionBlock is Item))
                {


                    if (movable.Speed.X > 0 &&
                            !(collisionBlock is FollowingEnemy)
                            ||
                            movable.Speed.X < 0 &&
                            !(collisionBlock is FollowingEnemy)
                            || !(collisionBlock is Item) &&
                            movable.Speed.X < 0
                            || !(collisionBlock is Item) &&
                            movable.Speed.X > 0)
                    {
                        movable.Speed = new Vector2(0, movable.Speed.Y);
                    }

                    if (movementManager.IsFalling && !(collisionBlock is Item))
                    {
                        if (collisionBlock is Tile)
                        {
                            Tile temp1 = collisionBlock as Tile;
                            if (temp1.TypeTile == Tile.TileType.GRASS)
                            {
                                movementManager.jump = false;
                                movementManager.IsFalling = false;
                                movable.Speed = new Vector2(movable.Speed.X, 0);
                                movementManager.OnGround = true;
                                movementManager.pressUp = false;
                            }
                        }
                        else if (collisionBlock is Enemy)
                        {
                            movementManager.jump = false;
                            movementManager.IsFalling = false;
                            movementManager.OnGround = true;
                            movementManager.pressUp = false;
                        }

                    }

                    if (movementManager.pressUp && !movementManager.IsFalling && !(collisionBlock is Item))
                    {
                        if (!(collisionBlock is FollowingEnemy))

                        {
                            movable.Speed = new Vector2(movable.Speed.X, 0);
                            movementManager.IsFalling = true;
                            movementManager.jump = false;
                            movementManager.pressUp = false;
                            movementManager.OnGround = true;
                        }
                    }
                }
            }

            else if (!hasCollided
            && !movementManager.IsFalling
            && !movementManager.jump)
            {
                movementManager.IsFalling = true;
                movementManager.jump = false;
                movementManager.pressDown = false;
            }
            movementManager.futurePosition = movable.Position + movable.Speed;
        }

        public bool CollisionDetection(Rectangle futureRect, List<PlatformGame.Blocks.Block> blockList)
        {
            foreach (var block in blockList)
            {
                if (futureRect.Intersects(block.BoundingBox) &&!( block is MovingEnemy))
                {
                     collisionBlock = block;
                    return true;
                }
            }
            return false;

        }

    }
}
