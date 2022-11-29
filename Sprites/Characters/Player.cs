using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PlatformGame.Interfaces;
using PlatformGame.Movement;
using SharpDX.Direct2D1.Effects;
using SharpDX.Mathematics.Interop;
using System;
using System.Diagnostics;
using System.Xml;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace PlatformGame.Characters
{
    internal class Player : IGameObject, IMovable
    {
        public int xCoordinaat = 0;
        private Texture2D texture;
        public Animation walkAnimation;
        public Rectangle idleFrame;
        //bewegen
        public Vector2 Position { get; set; }
        //Velocity
        public Vector2 Speed { get; set; }
        //Vector2 Velocity { get; set; } = new Vector2(0, 0);
        public bool isLeft = false;
        public int healthBar = 10;
        public float food;
        public Block drawBox;
        public Rectangle HitBox { get; set; }
        public Color Colour { get; set; } = Color.AliceBlue;
        public IInputReader InputReader { get; set; }
        public MovementManager movementManager;
        Texture2D boxTexture;
        bool keyPressed = false;

        public int ground = 550;
        public Player(Texture2D texture, Texture2D recTexture, IInputReader inputReader)
        {
            this.texture = texture;
            walkAnimation = new Animation();
            idleFrame = new Rectangle(0, 0, 57, 57);
            //+21 marge door spritesheet marge tss de images
            walkAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, 4, 1);
            Position = new Vector2(500, 250);
            boxTexture = recTexture;
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 50, 54);
            drawBox = new Block(new Rectangle((int)Position.X, (int)Position.Y, 32, 43), boxTexture, Speed, Color.AliceBlue);
            //van de IMoveable
            InputReader = inputReader;
            movementManager = new MovementManager();
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            throw new NotImplementedException();
        }
        public void Draw(SpriteBatch spriteBatch, Texture2D objTexture)
        {

             if ( movementManager.isLeft && !movementManager.standStill) {
                spriteBatch.Draw(texture, Position, walkAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.FlipHorizontally, 0f);
            }
            else if (movementManager.isLeft && movementManager.standStill)
            {
                spriteBatch.Draw(texture, Position, idleFrame, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.FlipHorizontally, 0f);
            }
            else if(!movementManager.isLeft && !movementManager.standStill)
                spriteBatch.Draw(texture, Position, walkAnimation.CurrentFrame.SourceRectangle, Color.White,0f,new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.None, 0f);
             else if(!movementManager.isLeft && movementManager.standStill)
            {
                spriteBatch.Draw(texture, Position, idleFrame, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.None, 0f);

            }
        }

        //geef input
        //input => richting of valrichting
        //bereken toekomstige plaats adhv input
        //check of tp botst
        //nee positie = toekomst
        //ja richting = 0;


        public void Update(GameTime gameTime, int windowWidth, int widowHeight)
        {
            movementManager.Move(this);

            Debug.WriteLine(Position);
            walkAnimation.Update(gameTime);
        }


    }
}
