using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Blocks;
using PlatformGame.Interfaces;
using PlatformGame.Movement;
using PlatformGame.Terrain;
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
        //bewegen
        public Vector2 Position { get; set; }
        //Velocity
        public Vector2 Speed { get; set; }
        private int hitBoxWidth;
        private int textureHeight;
        public bool isLeft = false;
        public int Health { get; set; } = 5;
        public Block HitBox { get; set; }
        private Color Colour = Color.AliceBlue;
        public IInputReader InputReader { get; set; }
        public MovementManager movementManager;
        Texture2D hitboxTexture;
        public Player(Texture2D texture, Texture2D hitboxtexture, IInputReader inputReader)
        {
            this.texture = texture;
            walkAnimation = new Animation(0.3d);
            hitBoxWidth = texture.Width / 4 -7;
            idleFrame = new Rectangle(0, 0, texture.Width/4, texture.Height);
            //+21 marge door spritesheet marge tss de images
            walkAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, 4, 1);
            Position = new Vector2(60, 420);
            this.hitboxTexture = hitboxtexture;
            HitBox = new Block(new Rectangle((int)Position.X, (int)Position.Y, hitBoxWidth, texture.Height), Color.Green, hitboxTexture );
            //van de IMoveable
            InputReader = inputReader;
            movementManager = new MovementManager();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw HitboxPlayer
            HitBox.Draw(spriteBatch);
            if (movementManager.isLeft && !movementManager.standStill)
            {
                spriteBatch.Draw(texture, Position, walkAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.FlipHorizontally, 0f);
            }
            else if (movementManager.isLeft && movementManager.standStill)
            {
                spriteBatch.Draw(texture, Position, idleFrame, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.FlipHorizontally, 0f);
            }
            else if (!movementManager.isLeft && !movementManager.standStill)
                spriteBatch.Draw(texture, Position, walkAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.None, 0f);
            else if (!movementManager.isLeft && movementManager.standStill)
            {
                spriteBatch.Draw(texture, Position, idleFrame, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.None, 0f);

            }

        }

        public void Update(GameTime gameTime, List<Tile> list)
        {
            movementManager.Move(this, list);
            HitBox.RectangleBlock = new Rectangle((int)Position.X, (int)Position.Y, hitBoxWidth, texture.Height);
            walkAnimation.Update(gameTime);

        }


    }
}
