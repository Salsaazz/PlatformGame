using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Characters;
using PlatformGame.Interfaces;
using PlatformGame.Movement;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame
{
    internal class Helper : IFollowPlayer
    {
        Animation walkAnimation;
        Texture2D _walkTexture;
        Rectangle walkRectangle;
        Rectangle idleFrame;
        int distance;

        public Helper(Texture2D texture)
        {
            this._walkTexture = texture;
            walkAnimation = new Animation(0.15d);
            walkRectangle = new Rectangle(0, 0, 32, 32);
            walkAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 1);
            idleFrame = new Rectangle(0, 0, texture.Width / 8, texture.Height);
            distance = 16;
        }


        public void Draw(SpriteBatch spriteBatch, Player followPlayer)
        {
            if (followPlayer.movementManager.standStill)
            {
                if (followPlayer.movementManager.IsLeft)
                    spriteBatch.Draw(_walkTexture, new Vector2(followPlayer.Position.X - distance, followPlayer.HitBox.Bottom - _walkTexture.Height), idleFrame, Color.White, 0f, new Vector2(0, 0), Vector2.One, SpriteEffects.FlipHorizontally, 0f);
                else
                    spriteBatch.Draw(_walkTexture, new Vector2(followPlayer.Position.X - distance, followPlayer.HitBox.Bottom - _walkTexture.Height), idleFrame, Color.White, 0f, new Vector2(0, 0), Vector2.One, SpriteEffects.None, 0f);

            }
            else
            {
                if (followPlayer.movementManager.IsLeft)
                    spriteBatch.Draw(_walkTexture, new Vector2(followPlayer.Position.X - distance, followPlayer.HitBox.Bottom - _walkTexture.Height), walkAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.FlipHorizontally, 0f);
                else
                    spriteBatch.Draw(_walkTexture, new Vector2(followPlayer.Position.X - distance, followPlayer.HitBox.Bottom - _walkTexture.Height), walkAnimation.CurrentFrame.SourceRectangle, Color.White);
            }
         }

        public void Update(GameTime gameTime)
        {
            walkAnimation.Update(gameTime);
        }
    }
}