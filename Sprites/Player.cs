using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PlatformGame;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DirectWrite;
using SharpDX.MediaFoundation.DirectX;
using SharpDX.WIC;
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

namespace Sprites
{
    internal class Player : IGameObject, ICollide<Block>
    {
        public int xCoordinaat = 0;
        private Texture2D texture;
        public Animation walkAnimation;
        //bewegen
        public Vector2 positie;
        //snelheid
        private Vector2 snelheid = new Vector2(1, 3);
        public bool isLeft = false;
        public int textureWidth = 0;
        public int textureHeight = 0;
        public int healthBar = 10;
        public float food;
        bool isFalling = false;
        bool hasJumped = false;
        public bool hasCollided = false;
        int jumpPosition = 0;
        public Block drawBox;
        public Rectangle HitBox { get; set; }
        public Color Colour { get; set; } = Color.AliceBlue;
        Texture2D boxTexture;
        
        public Player(Texture2D texture, Texture2D recTexture)
        {
            this.texture = texture;
            walkAnimation = new Animation();
            //+21 marge door spritesheet marge tss de images
            walkAnimation.GetFramesFromTextureProperties(texture.Width+25, texture.Height,4, 1);
            positie = new Vector2(0, 700);
            textureWidth = texture.Width;
            textureHeight = texture.Height;
            this.boxTexture = recTexture;
            HitBox = new Rectangle((int)positie.X + 19, (int)positie.Y + 5, 32, 43);
            this.drawBox = new Block(new Rectangle((int)positie.X + 19, (int)positie.Y + 5, 32, 43), recTexture, this.snelheid, Color.AliceBlue);
            //Block.blockLijst.Add(new Block(new Rectangle((int)positie.X + 19, (int)positie.Y + 5, 32, 43), recTexture, this.snelheid, Color.Aquamarine));
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            throw new NotImplementedException();
        }
        public void Draw(SpriteBatch spriteBatch, Texture2D objTexture)
        {
            //probleem coordinaat x past zich aan wanneer er wordt afgewisseld tss links rechts
            //oplossing, x coordinaat aanpassen wnr dit gebeurd door +15 te doen
            Vector2 nieuwePositie = positie;
            if (isLeft)
            {
                drawBox.Draw(spriteBatch, this.boxTexture, new Rectangle(HitBox.X + 30, HitBox.Y + 5, 32, 48), Colour);
                spriteBatch.Draw(texture, nieuwePositie, walkAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.FlipHorizontally, 0f);

            }
            if (!isLeft)
            {
                nieuwePositie.X += 15;
                drawBox.Draw(spriteBatch, this.boxTexture, new Rectangle(HitBox.X+19, HitBox.Y+ 5, 32, 48), Colour);
                spriteBatch.Draw(this.texture, nieuwePositie, walkAnimation.CurrentFrame.SourceRectangle, Color.White ,0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.None, 0f);

            }


        }

        public void Update(GameTime gameTime, int windowWidth, int windowHeight)
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            if (state.IsKeyDown(Keys.Left))
            {
                direction.X = -2;
                isLeft = true;

            }
            if (state.IsKeyDown(Keys.Up) && hasJumped == false)
            {
                //hier tekst: praten met de capybara
                //hoe hoog jumpen
                positie.Y -= 150f;
                direction.Y += -5f;
                hasJumped = true;
                Debug.WriteLine(positie.Y);
                Debug.WriteLine("direction = " + direction.Y);
            }
            if(hasJumped == true)
            {
                //de snelheid van de jump
                float i = 5;
                //gravity
                direction.Y += 0.15f * i;
            }
            if(positie.Y + this.texture.Height >= 750)
            {
                hasJumped = false;
            }
            if (hasJumped == false) direction.Y = 0f;
 
            if (state.IsKeyDown(Keys.Right))
            {
                direction.X = 2;
                isLeft = false;
            }
            direction *= snelheid;
            positie += direction;
            HitBox = new Rectangle((int)positie.X, (int)positie.Y, 32, 43);
            walkAnimation.Update(gameTime);
            Debug.WriteLine(positie.Y);

            //Move(windowWidth, windowHeight);
        }

        private void Move(int windowWidth, int windowHeight) {

            //collision detection
            if (positie.X > windowWidth-25 || positie.X < 0)
                snelheid.X *= -1;
            if (positie.Y > windowHeight - texture.Height || positie.Y < 0)
                snelheid.Y *= -1;
            positie += snelheid;
        }

        public void Collide(Block block)
        {
            if (HitBox.Intersects(block.rectangle))
            {
                //this.positie.X -= 5;
                block.direction.X *= -1;
                block.direction.Y *= -1;
                Colour = Color.Red;
                block.color = Color.White;
                Debug.WriteLine("collided" + healthBar);
                Debug.WriteLine("healthbar: " + healthBar);
                //hasCollided = true;
                if (block.teller >= 1000)
                {
                    healthBar-= block.damagePerSec;
                    block.teller = 0;
                }
            }
            else
                    { Debug.WriteLine("not collided");
                //Debug.WriteLine(drawBox.positie);
                hasCollided = false;
            }

        }
    }
}
