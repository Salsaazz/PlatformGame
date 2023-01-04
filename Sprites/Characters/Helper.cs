﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Characters;
using PlatformGame.Interfaces;
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
        int distance = 35;

        public Helper(Texture2D texture)
        {
            this._walkTexture = texture;
            walkAnimation = new Animation(0.15d);
            //normale width = 513 maar -1 want er is een zwarte streep
            walkRectangle = new Rectangle(0, 0, 64, 49);
            walkAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 1);
        }


        public void Draw(SpriteBatch spriteBatch, Player followPlayer)
        {

            if (followPlayer.movementManager.IsLeft)
                spriteBatch.Draw(_walkTexture, new Vector2(followPlayer.Position.X - distance, followPlayer.HitBox.Bottom - _walkTexture.Height), walkAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.FlipHorizontally, 0f);
            else
                spriteBatch.Draw(_walkTexture, new Vector2(followPlayer.Position.X - distance, followPlayer.HitBox.Bottom - _walkTexture.Height), walkAnimation.CurrentFrame.SourceRectangle, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            walkAnimation.Update(gameTime);
        }
    }
}