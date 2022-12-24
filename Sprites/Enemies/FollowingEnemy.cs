using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Blocks;
using PlatformGame.Characters;
using PlatformGame.EnemyMoving;

namespace PlatformGame.Enemies
{
    internal class FollowingEnemy : Enemy
    {
        IMovingBehavior movingBehavior = new Following();
        bool isLeft = false;
        public FollowingEnemy(Texture2D texture, Texture2D HitBoxTexture, Vector2 position, int totalSprites, int layers)
        {
            Position = position;
            Speed = new Vector2(1, 0);
            Texture = texture;
            objectAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, totalSprites, layers);
            textureWidth = texture.Width / totalSprites;
            HitBox = new Block(new Rectangle((int)Position.X, (int)Position.Y, 50, 48), Color.Red, HitBoxTexture);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            HitBox.Draw(spriteBatch);

            //spriteBatch.Draw(HitBox.Texture, new Rectangle((int)Position.X, (int)Position.Y, textureWidth, Texture.Height), Color.GreenYellow);
            if (isLeft)
            {

                spriteBatch.Draw(Texture, Position, objectAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1f, 1f), SpriteEffects.FlipHorizontally, 0f);
            }
            else
            {
                spriteBatch.Draw(Texture, Position, objectAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1f, 1f), SpriteEffects.None, 0f); 
            
            }
        }

        public override void Update(GameTime gameTime, Player player)
        {

            FollowPlayer(player);

            if (player.HitBox.RectangleBlock.Intersects(HitBox.RectangleBlock))
            {
                if (player.gameTimer.Counter >= 1000)
                {
                    player.Health--;
                    player.gameTimer.Counter = 0;
                }
            }
            if (Position.X > 800 - 50 || Position.X < 0)
            {
                Speed = new Vector2(Speed.X * -1, Speed.Y);
            }
            Position += Speed;
            HitBox = new Block(new Rectangle((int)Position.X, (int)Position.Y, 50,Texture.Height), Color.Red, HitBox.Texture);
            //movingBehavior.Move(Position);
            objectAnimation.Update(gameTime);
            gameTimer.UpdateCounter(gameTime);

        }
         void FollowPlayer(Player player)
        {

                var playerPosition = player.Position;
                if (Position.X != player.Position.X && Position.X > player.Position.X)
                {
                    Speed = new Vector2(-1, 0);
                    isLeft = true;
                }
                else if (Position.X != player.Position.X && Position.X < player.Position.X)
                {
                    Speed = new Vector2(1, 0);
                    isLeft = false;
                }
                //sta still
                else Speed = Vector2.Zero;
            }
        }
    }
