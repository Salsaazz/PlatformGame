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
        Texture2D _cloudTexture;
        Vector2 cloudPosition;

        public StartScreen(SpriteFont font, Texture2D backGroundTexture, Player player, Texture2D clouds)
            :base(font)
        {
            gameTimer = new GameTimer();
            this.texture = backGroundTexture;
            this.player = player;
            _cloudTexture = clouds;
            cloudPosition = new Vector2(0,0);
        }
        public override void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.Draw(texture, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, 1.3f, SpriteEffects.None, 0f);
            spriteBatch.Draw(_cloudTexture, new Rectangle((int)cloudPosition.X, 45, _cloudTexture.Width, _cloudTexture.Height), Color.White);
            spriteBatch.Draw(_cloudTexture, new Rectangle((int)cloudPosition.X + 1000, 45, _cloudTexture.Width, _cloudTexture.Height), Color.White);

            spriteBatch.DrawString(font, "ESCAPE_THE_FOREST", new Vector2(1000 / 2 - 230, 700 / 2 - 100), Color.Black, 0f, Vector2.One, 3.5f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(font, text, new Vector2(1000 / 2 -230, 700 / 2 ), Color.BurlyWood, 0f, Vector2.One, 1.4f, SpriteEffects.None, 0f);

        }

        public override void Update(GameTime gameTime)
        {
            gameTimer.UpdateCounter(gameTime);
            if (player.Health != 5)
            {
               player.Health = 5;

            }

            if (gameTimer.Counter > 50d)
            {

                if (gameTimer.Counter > 10000 && text == "")
                {

                    text = "PRESS [ENTER] TO START";
                    gameTimer.Counter = 0;

                }
                else if (gameTimer.Counter > 5000 && text != "")
                {
                     text = "";
                     gameTimer.Counter = 0;

                }
                cloudPosition.X -= 1;
            }
            if (cloudPosition.X < -1000)
            {
                cloudPosition.X = 0;
            }
            gameTimer.UpdateCounter(gameTime);

        }
    }
}
