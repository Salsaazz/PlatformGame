using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Blocks;
using PlatformGame.Characters;
using PlatformGame.EnemyMoving;
using PlatformGame.Interfaces;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Enemies
{
    internal class MovingEnemy : Enemy
    {
        private float teller = 0;

        IMovingBehavior movingBehavior = new Moving();
        public MovingEnemy(Texture2D texture, Texture2D HitBoxTexture, Vector2 position, int totalSprites, int layers)
        {
            Position = position;
            Speed = new Vector2(2, 0);
            Texture = texture;
            objectAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, totalSprites, layers);
            textureWidth = texture.Width / totalSprites;
            HitBox = new Block(new Rectangle((int)Position.X, (int)Position.Y, 50, 53), Color.Red, HitBoxTexture);
            HitBox.Type = Block.ObjectType.ENEMY;
        }



        public override void Update(GameTime gameTime, Player player)
        {
            if (player.HitBox.RectangleBlock.Intersects(HitBox.RectangleBlock) && !IsDead)
            {
                if (player.gameTimer.Counter >= 1000)
                {
                    player.Health--;
                    player.gameTimer.Counter = 0;
                    /*player.movementManager.jump = false;
                    player.movementManager.onGround = false;
                    player.movementManager.isFalling = true;*/
                    if (player.movementManager.Movable.Speed.X > 0 || player.movementManager.Movable.Speed.X < 0
                        || player.movementManager.Movable.Speed.X == 0)
                    {
                        player.movementManager.Movable.Speed = new Vector2(0
                           , player.movementManager.Movable.Speed.Y);
                    }
                    else
                        Speed = new Vector2(Speed.X * -1, Speed.Y);


                     if (player.movementManager.pressY && !player.movementManager.isFalling)
                    {
                        player.movementManager.Movable.Speed = new Vector2(player.movementManager.Movable.Speed.X, 0);
                        player.movementManager.jump = false;
                        //player.movementManager.isFalling = true;
                        player.movementManager.onGround = false ;

                    }
                    else if (player.movementManager.isFalling && player.HitBox.RectangleBlock.Bottom-2   <= HitBox.RectangleBlock.Top)
                    {
                        IsDead = true;

                    }


                }
            }

            //HitbBox updaten (door position,moet mee veranderen met de sprite)
            Speed = movingBehavior.Move(this.Position, Speed);
            Position += Speed;
            HitBox = new Block(new Rectangle((int)Position.X, (int)Position.Y, 50, 53), Color.Red, HitBox.Texture);
            objectAnimation.Update(gameTime);

        }
    }
}
