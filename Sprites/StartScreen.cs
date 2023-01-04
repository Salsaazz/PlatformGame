using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Timer;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Xna.Framework.Color;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace PlatformGame
{
    internal class StartScreen
    {
        GameTimer gameTimer;
        string text = "PRESS [ENTER] TO START";
        public StartScreen()
        {
            gameTimer = new GameTimer();
        }
        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            if (gameTimer.Counter > 500 && text != "")
            {
                text = "";
                gameTimer.Counter = 0;

            }
            else if(gameTimer.Counter > 500 && text == ""){

                text = "PRESS [ENTER] TO START";
                gameTimer.Counter = 0;

            }
            spriteBatch.DrawString(font, text, new Vector2(800/2, 800/2), Color.Red, 0f, Vector2.One, 1.3f, SpriteEffects.None, 0f);


        }

        public void Update(GameTime gameTime)
        {
            gameTimer.UpdateCounter(gameTime);
        }
    }
}
