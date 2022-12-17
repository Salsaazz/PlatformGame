﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Blocks;
using PlatformGame.Characters;
using PlatformGame.Timer;
using PlatformGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Enemies
{
    abstract class Enemy//: IGameObjectCollider
    {
        //public int DamagePerSec { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle RectangleTexture { get; set; }
        public Animation objectAnimation { get; set; } = new Animation(0.20d);
        public bool IsLeft { get; set; } = false;
        public int textureWidth { get; set; }
        public int textureHeight { get; set; } = 1;
        public Vector2 Position { get; set; }
        public Block HitBox { get ; set ; }
        public GameTimer gameTimer = new GameTimer();
        public Vector2 Speed { get; set; } = Vector2.Zero;
        public bool IsDead { get; set; } = false;
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsDead)
            {
            HitBox.Draw(spriteBatch);
            if (Speed.X <0)
            {
                spriteBatch.Draw(Texture, Position, objectAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1.3f, 2.3f), SpriteEffects.FlipHorizontally, 0f);
            }
            else
                spriteBatch.Draw(Texture, Position, objectAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1.3f, 2.3f), SpriteEffects.None, 0f);
            }
        }

        abstract public void Update(GameTime gameTime, Player player);


    }
}
