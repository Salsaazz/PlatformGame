using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Blocks;
using PlatformGame.Characters;
using PlatformGame.EnemyMoving;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Enemies
{
    internal class StandingEnemy : Enemy
    {
        IMovingBehavior movingBehavior = new Moving();
        public StandingEnemy(Texture2D texture, Texture2D HitBoxTexture, Vector2 position, int totalSprites, int layers)
        {
            Position = position;
            Speed = new Vector2(2, 0);
            Texture = texture;
            objectAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, totalSprites, layers);
            textureWidth = texture.Width / totalSprites;
            HitBox = new Block(new Rectangle((int)Position.X, (int)Position.Y, 50, 53), Color.Red, HitBoxTexture);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            HitBox.Draw(spriteBatch);

                spriteBatch.Draw(Texture, Position, objectAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1.3f, 2.3f), SpriteEffects.None, 0f);

        }

        public override void Update(GameTime gameTime, Player player)
        {
            if (player.HitBox.RectangleBlock.Intersects(HitBox.RectangleBlock))
            {
                if (player.gameTimer.Counter >= 1000)
                {
                    player.Health--;
                    player.gameTimer.Counter = 0;

                }

                if (player.Speed.X > 0 || player.Speed.X < 0
                    )
                {
                    player.Speed = new Vector2(0
                       , player.Speed.Y);
                }
                 if (player.Speed.X == 0)
                {
                    player.movementManager.Movable.Speed = new Vector2(0
                       , player.Speed.Y);
                }

            }
            objectAnimation.Update(gameTime);
        }
    }
}
