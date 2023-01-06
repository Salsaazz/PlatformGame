using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Characters;
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
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace PlatformGame.Screens
{
    internal class StartScreen : Screen
    {
        GameTimer gameTimer;
        string text = "PRESS [ENTER] TO START";
        Texture2D texture;
        Player player { get; set; }
        public StartScreen(SpriteFont font, Texture2D backGroundTexture, Player player)
            :base(font)
        {
            gameTimer = new GameTimer();
            this.texture = backGroundTexture;
            this.player = player;
        }
        public override void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.Draw(texture, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, 1.3f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(font, "ESCAPE_THE_FOREST", new Vector2(1000 / 2 - 230, 700 / 2 - 100), Color.Black, 0f, Vector2.One, 3.5f, SpriteEffects.None, 0f);
            if (gameTimer.Counter > 500 && text != "")
            {
                text = "";
                gameTimer.Counter = 0;

            }
            else if (gameTimer.Counter > 1000 && text == "")
            {

                text = "PRESS [ENTER] TO START";
                gameTimer.Counter = 0;

            }
            spriteBatch.DrawString(font, text, new Vector2(1000 / 2 -200, 700 / 2 +10), Color.BurlyWood, 0f, Vector2.One, 1.4f, SpriteEffects.None, 0f);

        }

        public override void Update(GameTime gameTime)
        {
            gameTimer.UpdateCounter(gameTime);
            if (player.Health != 5)
            {
               player.Health = 5;

            }
        }
    }
}
