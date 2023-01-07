using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Interfaces;
using PlatformGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using PlatformGame.Timer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Taskbar;

namespace PlatformGame.Terrain
{
    internal class Background: IGameObject
    {
        Texture2D _cloudTexture;
        Texture2D _mountainTexture;
        Texture2D pineTexture;
        Texture2D skyTexture;
        GameTimer gameTimer;
        Vector2 cloudPosition;
        public Background(Texture2D cloud, Texture2D mountain, Texture2D pine, Texture2D sky)
        {
            _cloudTexture = cloud;
            _mountainTexture = mountain;
            pineTexture = pine;
            skyTexture = sky;
            gameTimer = new GameTimer();
            cloudPosition = new Vector2(0, 10);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(skyTexture, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, 5f, SpriteEffects.None, 0f);
            spriteBatch.Draw(_mountainTexture, new Vector2(0, 150), null, Color.White, 0f, Vector2.Zero, 3f, SpriteEffects.None, 0f);
            spriteBatch.Draw(_cloudTexture, new Rectangle((int)cloudPosition.X, 45, _cloudTexture.Width, _cloudTexture.Height), Color.White);
            spriteBatch.Draw(_cloudTexture, new Rectangle((int)cloudPosition.X + 1000, 45, _cloudTexture.Width, _cloudTexture.Height), Color.White);
            spriteBatch.Draw(pineTexture, new Vector2(0, 250), null, Color.White, 0f, Vector2.Zero, 4.5f, SpriteEffects.None, 0f);


        }

        public void Update(GameTime gameTime)
        {
            gameTimer.UpdateCounter(gameTime);
            if (gameTimer.Counter > 50d)
            {
                cloudPosition.X -= 1;
                gameTimer.Counter = 0;
            }
            if (cloudPosition.X < -1000)
            {
                cloudPosition.X = 0;
            }
        }
    }
}
