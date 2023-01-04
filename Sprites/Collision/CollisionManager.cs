using Microsoft.Xna.Framework;
using PlatformGame.Blocks;
using PlatformGame.Characters;
using PlatformGame.Collision.Blocks;
using PlatformGame.Enemies;
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
        PlatformGame.Blocks.Block collisionBlock;
        public void Collide(bool hasCollided, MovementManager player, IMovable movable)
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
                if (player.pressDown && collisionBlock is Item)
                {
                    //voor de items
                    Item temp = collisionBlock as Item;
                        temp.IsTaken = true;
                }
                else if (!(collisionBlock is Item))
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

                    if (player.IsFalling && !(collisionBlock is Item))
                    {
                        if (collisionBlock is Tile)
                        {
                            Tile temp1 = collisionBlock as Tile;
                            if (temp1.TypeTile == Tile.TileType.GRASS)
                            {
                                player.jump = false;
                                player.IsFalling = false;
                                movable.Speed = new Vector2(movable.Speed.X, 0);
                                player.OnGround = true;
                                player.pressUp = false;
                            }
                        }
                        else if (collisionBlock is Enemies.Enemy)
                        {
                            player.jump = false;
                            player.IsFalling = false;
                            player.OnGround = true;
                            player.pressUp = false;
                        }

                    }

                    if (player.pressUp && !player.IsFalling && !(collisionBlock is Item))
                    {
                        if (!(collisionBlock is FollowingEnemy))

                        {
                            movable.Speed = new Vector2(movable.Speed.X, 0);
                            player.IsFalling = true;
                            player.jump = false;
                            player.pressUp = false;
                            player.OnGround = true;
                        }
                    }
                }
            }

            else if (!hasCollided
            && !player.IsFalling
            && !player.jump)
            {
                player.IsFalling = true;
                player.jump = false;

            }
            player.futurePosition = movable.Position + movable.Speed;

            Debug.WriteLine(player.IsFalling);
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
