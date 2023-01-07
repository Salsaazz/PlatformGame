using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Timer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PlatformGame.Screens
{
    internal class TheEnd : Screen
    {
        Texture2D texture;
        GameTimer gameTimer;
        Color[] colors = new Color[] { Color.Blue, Color.OrangeRed, Color.DeepPink, Color.ForestGreen };
        Color color = Color.ForestGreen;
        Random rnd = new Random();
        int checkNumber = -1;
        int number=-1;
        string text = "PRESS [ENTER]";
        public TheEnd(SpriteFont font, Texture2D texture) : base(font)
        {
            this.texture = texture;
            gameTimer = new GameTimer();
        }

        public override void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.Draw(texture, new Vector2(0, -300), null, Color.White, 0f, Vector2.Zero,2f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(font, "YOU SURVIVED...", new Vector2(700 / 2 - 150, 350), color, 0f, Vector2.One, 5f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(font, "FOR NOW :^)", new Vector2(700 / 2 - 150, 430), color, 0f, Vector2.One, 2f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(font, text, new Vector2(700 / 2, 500), Color.White, 0f, Vector2.One, 2f, SpriteEffects.None, 0f);

        }

        public override void Update(GameTime gameTime)
        {
            if (gameTimer.Counter > 1000)
            {
                checkNumber = rnd.Next(0, colors.Length);
                if (checkNumber != number)
                {
                    text = "PRESS [ENTER]";
                    number = checkNumber;
                    gameTimer.Counter = 0;
                }

                }
            else if (gameTimer.Counter > 500 && text != "")
            {
                text = "";
                gameTimer.Counter = 0;

            }

            switch (number)
            {
                case 0:
                    color = colors[0];
                    break;
                case 1:
                    color = colors[1];
                    break;
                case 2:
                    color = colors[2];
                    break;
                case 3:
                    color = colors[3];
                    break;
                default:
                    break;
            }
            gameTimer.UpdateCounter(gameTime);
        }
    }
}
