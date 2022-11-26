using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PlatformGame.Interfaces;
using SharpDX.Mathematics.Interop;
using System;
using System.Diagnostics;
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
        //Velocity
        Vector2 Velocity { get; set; } = new Vector2(0,0);
        public bool isLeft = false;
        public int textureWidth = 0;
        public int textureHeight = 0;
        public int healthBar = 10;
        public float food;
        public bool hasCollidedL = false;
        public bool hasCollidedR = false;
        public Block drawBox;
        public Rectangle DrawBox { get; set; }
        public Rectangle HitBox { get; set; }
        public Color Colour { get; set; } = Color.AliceBlue;
        public Vector2 Position2 { get; set; }
        public Vector2 Speed2 { get; set; }
        private bool keyPressed = false;
        public IInputReader InputReader { get; set; } = new KeyboardReader();
        private MovementManager movementManager = new MovementManager();
        Texture2D boxTexture;
        bool isJumping = false;
        bool hasJumped = false;
        int currentYAxis;
        bool onTile { get; set; } = false;
        bool collideTop { get; set; } = false;
        public bool isFalling { get; private set; }

        public int ground;
        public Player(Texture2D texture, Texture2D recTexture)
        {
            this.texture = texture;
            walkAnimation = new Animation();
            idleFrame = new Rectangle(0, 0, 57, 57);
            //+21 marge door spritesheet marge tss de images
            walkAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, 4, 1);
            Position = new Vector2(500,500);
            textureWidth = texture.Width;
            textureHeight = texture.Height;
            boxTexture = recTexture;
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 50, 54);
            drawBox = new Block(new Rectangle((int)Position.X, (int)Position.Y, 32, 43), boxTexture, Velocity, Color.AliceBlue);
            //van de IMoveable
            Position2 = this.Position;
            Speed2 = this.Velocity;

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
                //drawBox.Draw(spriteBatch, boxTexture, new Rectangle(HitBox.X + 30, HitBox.Y + 5, 32, 48), Colour);
                //drawBox.Draw(spriteBatch, boxTexture, HitBox, Colour);
                spriteBatch.Draw(boxTexture, HitBox, null, Color.White, 0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);

                if (!keyPressed)
                {
                    //spriteBatch.Draw(texture, new Vector2(nieuwePositie.X -16, 700), idleFrame, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.FlipHorizontally, 0f);
                    spriteBatch.Draw(texture, new Vector2(nieuwePositie.X, nieuwePositie.Y), idleFrame, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.FlipHorizontally, 0f);

                }
                else
                {
                    //spriteBatch.Draw(texture, new Vector2(nieuwePositie.X -16, 700), walkAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.FlipHorizontally, 0f);
                    spriteBatch.Draw(texture, new Vector2(nieuwePositie.X, nieuwePositie.Y), walkAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.FlipHorizontally, 0f);

                }


            }
            if (!isLeft)
            {
                //nieuwePositie.X += 15;
                //drawBox.Draw(spriteBatch, boxTexture, new Rectangle(HitBox.X + 19, HitBox.Y + 5, 32, 48), Colour);
                //drawBox.Draw(spriteBatch, boxTexture, HitBox, Colour);
                spriteBatch.Draw(boxTexture, HitBox, null, Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, 0f);


                if (!keyPressed)
                { 
                    spriteBatch.Draw(texture, Position, idleFrame, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.None, 0f); 
                }
                else
                {
                    spriteBatch.Draw(texture, Position, walkAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.None, 0f);
                }
            }
        }



        /*public void Update(GameTime gameTime, int windowWidth, int windowHeight)
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
            if (state.IsKeyDown(Keys.Up) && !isJumping && !isFalling)
            {
                isJumping = true;
                Debug.WriteLine("WANTS TO JUMP");
            }
            if (isJumping)
            {
                //de Velocity van de jump
                float i = 10f;
                //gravity
                direction.Y -= 0.15f * i;
            }
            if (isFalling)
            {
                //de Velocity van de jump
                float i = 10f;
                //gravity
                direction.Y += 0.15f * i;
                isJumping = false;
                
            }

            ///werk hier verder aan
            if (Position.Y + texture.Height >= 750 && isFalling)
            {
                isFalling = false;
                direction.Y = 0;
            }
            if (Position.Y + texture.Height <= 560 + textureHeight && isJumping)
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
            direction *= Velocity;
            Position += direction;
            //Move();
            //HitBox = new Rectangle((int)Position.X, (int)Position.Y, 32, 43);
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 50, 54);
            //DrawBox = HitBox;
            walkAnimation.Update(gameTime);
            Debug.WriteLine(Position.Y);

            //Move(windowWidth, windowHeight);
        }*/
        public void Update(GameTime gameTime, int windowWidth, int windowHeight)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.GetPressedKeys().Length == 0) keyPressed = false;
            else keyPressed = true;
            if (!keyPressed)
            {
                Velocity = new Vector2(0, Velocity.Y);
            }
            if (state.IsKeyDown(Keys.Left) && !hasCollidedL ||
                state.IsKeyDown(Keys.Left) && hasCollidedR 
                || state.IsKeyDown(Keys.Left) && hasJumped)
            {
                Velocity = new Vector2(-3, Velocity.Y);
                isLeft = true;
                hasCollidedR = false;
            }

            if (state.IsKeyDown(Keys.Right) && !hasCollidedR
                || state.IsKeyDown(Keys.Right) && hasJumped)
            {
                Velocity = new Vector2(3, Velocity.Y);
                isLeft = false;
                hasCollidedL = false;
            }

            if (state.IsKeyDown(Keys.Up) && !hasJumped )
            {
                currentYAxis = (int)Position.Y;
                Position -= new Vector2(0, 10);
                Velocity += new Vector2(0, -5f);
                hasJumped = true;
            }
            if (hasJumped || !onTile)
            {
                float i = 1;
                Velocity += new Vector2(0, (0.15f * i));
            }

            if (onTile)
            {
                Velocity = new Vector2(Velocity.X, 0);

            }
            //sprong hoogte
            if (Position.Y + texture.Height >= currentYAxis+ texture.Height )
            {
                hasJumped = false;
            }
            if (!hasJumped)
            {
                Velocity = new Vector2(Velocity.X, 0);
            }


            /*if (onTile)
            {
                Velocity = new Vector2(Velocity.X, 0);
                //currentYAxis = ground;
                Debug.WriteLine(Velocity);

            }
            if (!onTile)
            {
                isFalling = true;
                Debug.WriteLine("not on tile");
                //hasJumped = true;
            }*/

            Position += Velocity;
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 50, 54);
            walkAnimation.Update(gameTime);

        }
        public void Move()//int windowWidth, int windowHeight)
        {

            //collision detection
            /*if (Position.X > windowWidth - 25 || Position.X < 0)
                Velocity.X *= -1;
            if (Position.Y > windowHeight - texture.Height || Position.Y < 0)
                Velocity.Y *= -1;
            Position += Velocity;*/
            movementManager.Move(this);

        }

     public void Collide(Block block)
        {
            Colour = Color.Red;
            if (HitBox.Intersects(block.rectangle) && !block.IsDead)
            {
                if (HitBox.Bottom <= block.rectangle.Top + 10 && block.type == Block.blockType.Enemy)
                {
                    block.IsDead = true;
                    Debug.WriteLine("DEATH");
                }
                else if (HitBox.Bottom <= block.rectangle.Top + 10 && block.type == Block.blockType.Tile)
                {
                    onTile = true;
                    ground = HitBox.Bottom;

                }

                if (HitBox.Right >= block.rectangle.Left)
                {
                    hasCollidedR = true;
                    Velocity = new Vector2(0, Velocity.Y);
                    if (isLeft && hasCollidedR)
                    { hasCollidedR = false; }

                }
                if (HitBox.Left == block.rectangle.Right)
                {
                    hasCollidedL = true;
                    Velocity = new Vector2(0, Velocity.Y);
                    if (hasCollidedL && !isLeft)
                    {
                        hasCollidedL = false;
                    }

                }

                else
                {
                    block.color = Color.Red;
                    hasCollidedL = true;
                }

                //BEWERKEN
                //als de de hitbox van een enemy is 
                //anders player.x = 0
                if (HitBox.Top <= block.rectangle.Bottom)
                {
                    collideTop = true;
                    Velocity = new Vector2(Velocity.X, 0);
                }


                if (block.teller >= 1000)
                {
                    healthBar -= block.damagePerSec;
                    block.teller = 0;
                }
            }
            else onTile = false;

        }
        

        public bool IsTouchingGround()
        {
            if (Position.Y == 500)
                return true;
            else return false;
        }
    }
}
