﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PlatformGame;
using PlatformGame.Interfaces;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DirectWrite;
using SharpDX.MediaFoundation;
using SharpDX.MediaFoundation.DirectX;
using SharpDX.WIC;
using Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace PlatformGame.Characters
{
    internal class Player : IGameObject, ICollide<Block>, IMovable
    {
        public int xCoordinaat = 0;
        private Texture2D texture;
        public Animation walkAnimation;
        public Rectangle idleFrame;
        //bewegen
        public Vector2 Position { get; set; }
        //Speed2
        public Vector2 Speed { get; set; }
        public bool isLeft = false;
        public int textureWidth = 0;
        public int textureHeight = 0;
        public int healthBar = 10;
        public float food;
        // bool isFalling = false;
        bool isFalling = false;
        public bool hasCollided = false;
        public Block drawBox;
        public Rectangle HitBox { get; set; }
        public Color Colour { get; set; } = Color.AliceBlue;
        public Vector2 Position2 { get; set; }
        public Vector2 Speed2 { get; set; }
        private bool keyPressed = false;
        public IInputReader InputReader { get; set; } = new KeyboardReader();

        private MovementManager movementManager = new MovementManager();
        Texture2D boxTexture;
        bool isJumping = false;

        public Player(Texture2D texture, Texture2D recTexture)
        {
            this.texture = texture;
            walkAnimation = new Animation();
            idleFrame = new Rectangle(0, 0, 55, 57);
            //+21 marge door spritesheet marge tss de images
            walkAnimation.GetFramesFromTextureProperties(texture.Width + 25, texture.Height, 4, 1);
            Position = new Vector2(0, 700);
            Speed =  new Vector2(1, 3);
            textureWidth = texture.Width;
            textureHeight = texture.Height;
            boxTexture = recTexture;
            HitBox = new Rectangle((int)Position.X + 19, (int)Position.Y + 5, 32, 43);
            drawBox = new Block(new Rectangle((int)Position.X + 19, (int)Position.Y + 5, 32, 43), recTexture, Speed, Color.AliceBlue);
            //van de IMoveable
            Position2 = this.Position;
            Speed2 = this.Speed;

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            throw new NotImplementedException();
        }
        public void Draw(SpriteBatch spriteBatch, Texture2D objTexture)
        {
            //probleem coordinaat x past zich aan wanneer er wordt afgewisseld tss links rechts
            //oplossing, x coordinaat aanpassen wnr dit gebeurd door +15 te doen
            Vector2 nieuwePositie = Position;

            if (isLeft)
            {
                drawBox.Draw(spriteBatch, boxTexture, new Rectangle(HitBox.X + 28, HitBox.Y + 5, 32, 48), Colour);

                if (!keyPressed)
                {
                    spriteBatch.Draw(texture, new Vector2(nieuwePositie.X +9, nieuwePositie.Y), idleFrame, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.FlipHorizontally, 0f);
                }
                else
                {
                    spriteBatch.Draw(texture, nieuwePositie, walkAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.FlipHorizontally, 0f);

                }


            }
            if (!isLeft)
            {
                nieuwePositie.X += 15;
                drawBox.Draw(spriteBatch, boxTexture, new Rectangle(HitBox.X + 19, HitBox.Y + 5, 32, 48), Colour);
                if (!keyPressed)
                { spriteBatch.Draw(texture, nieuwePositie, idleFrame, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.None, 0f);}
                else
                {
                    spriteBatch.Draw(texture, nieuwePositie, walkAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.None, 0f);
                }
            }
        }
    


        public void Update(GameTime gameTime, int windowWidth, int windowHeight)
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            if (state.GetPressedKeys().Length == 0) keyPressed = false;
            else keyPressed = true;
                if (state.IsKeyDown(Keys.Left))
                {
                    direction.X = -2;
                    isLeft = true;

                }
                if (state.IsKeyDown(Keys.Up) && isJumping == false && !isFalling)
                {
                    isJumping = true;
                }
                if (isJumping)
                {
                    //de Speed2 van de jump
                    float i = 10;
                    //gravity
                    direction.Y -= 0.15f * i;
                }
                if (isFalling == true)
                {
                    //de Speed2 van de jump
                    float i = 10;
                    //gravity
                    direction.Y += 0.15f * i;
                }
                ///werk hier verder aan
                if (Position.Y + texture.Height >= 750 && isFalling)
                {
                    isFalling = false;
                    direction.Y = 0;
                }
                if (Position.Y + texture.Height <= 580 + textureHeight && isJumping)
                {
                    isFalling = true;
                    direction.Y = 0;
                    isJumping = false;
                }
                if (state.IsKeyDown(Keys.Right))
                {
                    direction.X = 2;
                    isLeft = false;
                }
            
            direction *= Speed;
            Position += direction;
            //Move();
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 32, 43);
            walkAnimation.Update(gameTime);
            Debug.WriteLine(Position.Y);

            //Move(windowWidth, windowHeight);
        }

        public void Move()//int windowWidth, int windowHeight)
        {

            //collision detection
            /*if (Position2.X > windowWidth - 25 || Position2.X < 0)
                Speed2.X *= -1;
            if (Position2.Y > windowHeight - texture.Height || Position2.Y < 0)
                Speed2.Y *= -1;
            Position2 += Speed2;*/
            movementManager.Move(this);
            
        }

        public void Collide(Block block)
        {
            Debug.WriteLine("block positie y: " + block.Position.Y);
            if (HitBox.Intersects(block.rectangle))
            {
                 
                    block.direction.X *= -1;
                    block.direction.Y *= -1;
                    Colour = Color.Red;
                    block.color = Color.White;
                    if (block.teller >= 1000)
                    {
                        healthBar -= block.damagePerSec;
                        block.teller = 0;
                    }
                
            }
            else
            {
                hasCollided = false;
            }

        }
        public bool IsTouchingGround()
        {
            if (Position.Y == 1000)
                return true;
            else return false;
        }
    }
}
