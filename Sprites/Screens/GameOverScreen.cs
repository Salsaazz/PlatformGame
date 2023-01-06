using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Timer;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PlatformGame.Screens
{
    internal class GameOverScreen : Screen
    {

        Texture2D texture;
        GameTimer gameTimer;
        string text = "PRESS [ENTER] TO RESTART";
        string text2 = "PRESS [SHIFT] TO QUIT";

        public GameOverScreen(SpriteFont font, Texture2D texture) : base(font) {
            this.texture = texture;
            gameTimer = new GameTimer();
        }
        public override void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.Draw(texture, new Vector2(0, 0), null, Color.DarkBlue, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
            if (gameTimer.Counter > 1000 && text != "")
            {
                text = "";
                text2 = "";
                gameTimer.Counter = 0;

            }
            else if (gameTimer.Counter > 1000 && text == "")
            {

                text = "PRESS [ENTER] TO RESTART";
                text2 = "PRESS [SHIFT] TO QUIT";
                gameTimer.Counter = 0;
            }

                spriteBatch.DrawString(font, "GAME OVER", new Vector2(700/2 -120, 200), Color.GhostWhite, 0f, Vector2.One, 8f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(font, "...WHO WILL TAKE CARE OF THE KITTEN NOW?", new Vector2(700 / 2 - 20, 350), Color.GhostWhite, 0f, Vector2.One, 1f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(font, text, new Vector2(700 / 2 + 200, 700 / 2 + 100), Color.DarkGreen, 0f, Vector2.One, 1.6f, SpriteEffects.None, 0f);
                spriteBatch.DrawString(font, text2, new Vector2(700 / 2 - 200, 700 / 2 + 100), Color.DarkBlue, 0f, Vector2.One, 1.6f, SpriteEffects.None, 0f);

        }

        public override void Update(GameTime gameTime)
        {
            gameTimer.UpdateCounter(gameTime);
        }
    }
}
