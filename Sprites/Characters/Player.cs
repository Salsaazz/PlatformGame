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
        public Rectangle idleFrame;
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        private int hitBoxWidth;
        public int Health { get; set; } = 5;
        public Rectangle HitBox { get; set; }
        private Color Colour = Color.AliceBlue;
        public IInputReader InputReader { get; set; }
        public MovementManager movementManager;
        Texture2D hitboxTexture;
        public GameTimer gameTimer { get; set; } = new GameTimer();

        public Player(Texture2D texture, Texture2D hitboxtexture, IInputReader inputReader)
        {
            this.texture = texture;
            walkAnimation = new Animation(0.3d);
            hitBoxWidth = texture.Width / 6;
            idleFrame = new Rectangle(0, 0, texture.Width/6, texture.Height);
            //+21 marge door spritesheet marge tss de images
            walkAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, 6, 1);
            Position = new Vector2(60, 320);
            this.hitboxTexture = hitboxtexture;
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, hitBoxWidth, texture.Height);
            //van de IMoveable
            InputReader = inputReader;
            movementManager = new MovementManager();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw HitboxPlayer
            spriteBatch.Draw(hitboxTexture, HitBox, Color.BlueViolet);
            //HitBox.Draw(spriteBatch);
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
            movementManager.Move(this, bloklist);
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, hitBoxWidth, texture.Height);
            walkAnimation.Update(gameTime);
            gameTimer.UpdateCounter(gameTime);

        }

    }
}
