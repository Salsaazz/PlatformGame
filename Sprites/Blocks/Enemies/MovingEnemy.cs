using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Blocks;
using PlatformGame.Characters;
using PlatformGame.Interfaces;
using PlatformGame.Movement.BlockMovement;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Blocks.Enemies
{
    internal class MovingEnemy : Enemy
    {

        public MovingEnemy(Texture2D texture, Texture2D boxTexture, Vector2 position, int totalSprites, int layers)
            : base(position, texture, boxTexture, totalSprites, layers)
        {

            Speed = new Vector2(5, 0);
            Damage = 1;
            MovingBehavior = new Moving();

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsDead)
            {
                if (IsLeft)
                {
                    spriteBatch.Draw(Texture, Position, objectAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), Vector2.One, SpriteEffects.FlipHorizontally, 0f);
                }
                else
                    spriteBatch.Draw(Texture, Position, objectAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), Vector2.One, SpriteEffects.None, 0f);
            }
        }
    }
}
