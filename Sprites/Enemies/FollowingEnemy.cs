using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Blocks;
using PlatformGame.Characters;
using PlatformGame.Collision.Blocks;
using PlatformGame.EnemyMoving;

namespace PlatformGame.Enemies
{
    internal class FollowingEnemy : Enemy
    {
        MovingBehavior movingBehavior = new Following();
        public FollowingEnemy(Texture2D texture, Texture2D boxTexture, Color color, Vector2 position, int totalSprites, int layers)
           : base(position, color, texture, boxTexture, totalSprites, layers)
        {
            Position = position;
            Speed = new Vector2(1, 0);
            Texture = texture;
            objectAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, totalSprites, layers);
            textureWidth = texture.Width / totalSprites;
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, textureWidth, textureHeight);
            Damage = 2;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            //spriteBatch.Draw(BoundingBoxTexture, BoundingBox, Color.Red);
            if (IsLeft)
            {

                spriteBatch.Draw(Texture, Position, objectAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), Vector2.One, SpriteEffects.FlipHorizontally, 0f);
            }
            else
            {
                spriteBatch.Draw(Texture, Position, objectAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), Vector2.One, SpriteEffects.None, 0f);

            }
        }

        public override void Update(GameTime gameTime, Player player)
        {
            movingBehavior.Move(player, this);
            objectAnimation.Update(gameTime);
        }
    }
}
