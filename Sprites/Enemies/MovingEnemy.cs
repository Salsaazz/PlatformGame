using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Blocks;
using PlatformGame.Characters;
using PlatformGame.Collision.Blocks;
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

        //IMovingBehavior movingBehavior = new Moving();
        public MovingEnemy(Texture2D texture, Texture2D boxTexture, Vector2 position, int totalSprites, int layers)
            : base(position, texture, boxTexture, totalSprites, layers)
        {

            Speed = new Vector2(5, 0);
            objectAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, totalSprites, layers);
            Damage = 1;
            MovingBehavior2 = new Moving();

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsDead)
            {
                //spriteBatch.Draw(BoundingBoxTexture, BoundingBox, Color.Red);
                if (Speed.X < 0)
                {
                    spriteBatch.Draw(Texture, Position, objectAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), Vector2.One, SpriteEffects.FlipHorizontally, 0f);
                }
                else
                    spriteBatch.Draw(Texture, Position, objectAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), Vector2.One, SpriteEffects.None, 0f);
            }
        }
    }
}
