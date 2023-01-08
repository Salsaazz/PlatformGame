using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Blocks;
using PlatformGame.Interfaces;
using PlatformGame.Movement;
using PlatformGame.Terrain;
using PlatformGame.Timer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Reflection.Metadata;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace PlatformGame.Characters
{
    internal class Player : IGameObjectCollider, IMovable
    {
        private Texture2D texture;
        public Animation walkAnimation;
        private Rectangle idleFrame;
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        private int hitBoxWidth;
        public int Health { get; set; }
        public Rectangle HitBox { get; set; }
        private Color Colour = Color.AliceBlue;
        public IInputReader InputReader { get; set; }
        public MovementManager movementManager;
        Texture2D hitboxTexture;
        public GameTimer gameTimer { get; set; }
        public int Item { get; set; }
        public bool touchedGate { get; set; } 
        private static Player uniqueInstance;

        private  Player (){
            Health = 5;
            touchedGate = false;
            Position = new Vector2(38, 600);
            walkAnimation = new Animation(0.3d);
            gameTimer = new GameTimer();

        }

        public static Player GetInstance() {
            if (uniqueInstance == null)
            {
                uniqueInstance = new Player();

        }
            return uniqueInstance;

    }
        public void Init(Texture2D texture, Texture2D hitboxtexture, IInputReader inputReader)
        {
            this.texture = texture;
            hitBoxWidth = texture.Width / 6;
            idleFrame = new Rectangle(0, 0, texture.Width / 6, texture.Height);
            walkAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, 6, 1);
            this.hitboxTexture = hitboxtexture;
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, hitBoxWidth, texture.Height);
            InputReader = inputReader;
            movementManager = new MovementManager();
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            if (movementManager.standStill)
            {
                if (movementManager.IsLeft)
                    spriteBatch.Draw(texture, Position, idleFrame, Color.White, 0f, new Vector2(0, 0), Vector2.One, SpriteEffects.FlipHorizontally, 0f);

                else
                    spriteBatch.Draw(texture, Position, idleFrame, Color.White, 0f, new Vector2(0, 0), Vector2.One, SpriteEffects.None, 0f);
            }
            else
            {
                if (movementManager.IsLeft)
                    spriteBatch.Draw(texture, Position, walkAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.FlipHorizontally, 0f);
                else
                    spriteBatch.Draw(texture, Position, walkAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.None, 0f);
            }


        }

        public void Update(GameTime gameTime, List<Block> bloklist)
        {
            movementManager.Move(this, bloklist, this);
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, hitBoxWidth, texture.Height);
            walkAnimation.Update(gameTime);
            gameTimer.UpdateCounter(gameTime);
        }
    }
}
