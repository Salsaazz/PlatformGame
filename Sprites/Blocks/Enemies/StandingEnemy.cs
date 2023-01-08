using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Blocks;
using PlatformGame.Characters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Standing = PlatformGame.Movement.BlockMovement.Standing;

namespace PlatformGame.Blocks.Enemies
{
    internal class StandingEnemy : Enemy
    {
        public StandingEnemy(Texture2D texture, Texture2D boxTexture, Vector2 position, int totalSprites, int layers)
            : base(position, texture, boxTexture, totalSprites, layers)
        {
            Speed = new Vector2(0, 0);
            objectAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, totalSprites, layers);
            Damage = 4;
            MovingBehavior2 = new Standing();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(Texture, Position, objectAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), Vector2.One, SpriteEffects.FlipHorizontally, 0f);

        }
    }
}
