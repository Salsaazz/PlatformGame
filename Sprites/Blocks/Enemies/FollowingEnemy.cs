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

namespace PlatformGame.Blocks.Enemies
{
    internal class FollowingEnemy : Enemy
    {
        public FollowingEnemy(Texture2D texture, Texture2D boxTexture, Vector2 position, int totalSprites, int layers)
           : base(position, texture, boxTexture, totalSprites, layers)
        {
            Speed = new Vector2(1, 0);
            objectAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, totalSprites, layers);
            Damage = 2;
            MovingBehavior2 = new Following();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            if (IsLeft)
            {
                spriteBatch.Draw(Texture, Position, objectAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), Vector2.One, SpriteEffects.FlipHorizontally, 0f);
            }
            else
            {
                spriteBatch.Draw(Texture, Position, objectAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), Vector2.One, SpriteEffects.None, 0f);
            }
        }
    }
}
