using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PlatformGame;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Xna.Framework.Color;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
namespace Sprites
{
    internal class Player : IGameObject
    {
        public int xCoordinaat = 0;
        private Texture2D texture;
        public Animation walkAnimation;
        //bewegen
        public static Vector2 positie;
        //snelheid
        private Vector2 snelheid = new Vector2(1, 3);
        private bool isLeft = false;
        public int textureWidth = 0;
        public int textureHeight = 0;
        public Player(Texture2D texture)
        {
            this.texture = texture;
            walkAnimation = new Animation();
            //+21 marge door spritesheet marge tss de images
            walkAnimation.GetFramesFromTextureProperties(texture.Width+25, texture.Height,4, 1);
            positie = new Vector2(0, 700);
            textureWidth = texture.Width;
            textureHeight = texture.Height;
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D objTexture)
        {
            //probleem coordinaat x past zich aan wanneer er wordt afgewisseld tss links rechts
            //oplossing, x coordinaat aanpassen wnr dit gebeurd door +15 te doen
            Vector2 nieuwePositie = positie;
            if (isLeft)
                spriteBatch.Draw(texture, nieuwePositie, walkAnimation.CurrentFrame.SourceRectangle, Color.White,0f, new Vector2(0,0),new Vector2(1,1), SpriteEffects.FlipHorizontally,0f);
            if (!isLeft)
            { 
                nieuwePositie.X += 15;
                spriteBatch.Draw(texture, nieuwePositie, walkAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.None, 0f);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //probleem coordinaat x past zich aan wanneer er wordt afgewisseld tss links rechts
            //oplossing, x coordinaat aanpassen wnr dit gebeurd door +15 te doen
            Vector2 nieuwePositie = positie;
            if (isLeft)
                spriteBatch.Draw(texture, nieuwePositie, walkAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.FlipHorizontally, 0f);
            if (!isLeft)
            {
                nieuwePositie.X += 15;
                spriteBatch.Draw(texture, nieuwePositie, walkAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.None, 0f);
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
                if (state.IsKeyDown(Keys.Enter))
                {
                    //hier tekst: praten met de capybara
                }
            }
            if (state.IsKeyDown(Keys.Right))
            {
                direction.X = 2;
                isLeft = false;
            }
            direction *= snelheid;
            positie += direction;
            walkAnimation.Update(gameTime);
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

    }
}
