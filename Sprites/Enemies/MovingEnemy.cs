using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Blocks;
using PlatformGame.Characters;
using PlatformGame.EnemyMoving;
using PlatformGame.Interfaces;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Enemies
{
    internal class MovingEnemy : Enemy
    {
        IMovingBehavior movingBehavior = new Moving();
        public MovingEnemy(Texture2D texture, Rectangle rectangle, int widthtexture, int totalSprites, int layers)
        {
            Position = new Vector2(rectangle.X, rectangle.Y);
            Texture = texture;
            objectAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, totalSprites, layers);
            textureWidth = texture.Width / totalSprites;
            HitBox = new Block(rectangle, Color.Red, texture);

        }


        /*public override void Draw(SpriteBatch spriteBatch)
        {
            HitBox.Draw(spriteBatch);
            if (IsLeft)
            {
                spriteBatch.Draw(Texture, Position, objectAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.FlipHorizontally, 0f);
            }
            else
            spriteBatch.Draw(Texture, Position, objectAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.None, 0f);
        }*/

        public override void Update(GameTime gameTime, Player player)
        {
            if (player.HitBox.RectangleBlock.Intersects(HitBox.RectangleBlock))
            {
                if (gameTimer.Counter == 1000)
                {
                    player.Health--;
                    gameTimer.Counter = 0;
                }
            }
            if (Position.X > 1000 - textureWidth)
            {
                Position = new Vector2(Position.X * -1, Position.Y);
                IsLeft = true;
            }
            else if(Position.X < 0)
            {
                Position = new Vector2(Position.X * -1, Position.Y);
                IsLeft = false;
            }
            movingBehavior.Move(Position);
            //HitbBox updaten (door position,moet mee veranderen met de sprite)
            HitBox = new Block(new Rectangle((int)Position.X, (int)Position.Y, textureWidth, textureWidth), Color.Red, Texture);
        }

        public void Update(GameTime gameTime, List<Blockies> list)
        {
            throw new NotImplementedException();
        }


    }
}
