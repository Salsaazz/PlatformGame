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

namespace PlatformGame.Terrain
{
    internal class Background
    {
        Texture2D _cloudTexture;
        Texture2D _mountainTexture;
        Texture2D pineTexture;
        Texture2D skyTexture;
        public Background(Texture2D cloud, Texture2D mountain, Texture2D pine, Texture2D sky)
        {
            _cloudTexture = cloud;
            _mountainTexture = mountain;
            pineTexture = pine;
            skyTexture = sky;
        }

        public void Draw(SpriteBatch spriteBatch)//GraphicsDeviceManager _graphics)
        {
            /*Vector2 back = new Vector2(0, 0);
            back.X = _graphics.PreferredBackBufferWidth;
            back.Y = _graphics.PreferredBackBufferHeight;*/
            spriteBatch.Draw(skyTexture, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, 5f, SpriteEffects.None, 0f);
            spriteBatch.Draw(_mountainTexture, new Vector2(0, 150), null, Color.White, 0f, Vector2.Zero, 3f, SpriteEffects.None, 0f);
            spriteBatch.Draw(_cloudTexture, new Vector2(0, 10), null, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
            spriteBatch.Draw(pineTexture, new Vector2(0, 250), null, Color.White, 0f, Vector2.Zero, 4.5f, SpriteEffects.None, 0f);

        }
    }
}
