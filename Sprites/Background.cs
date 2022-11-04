using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Sprites
{
    internal class Background : IGameObject
    {
        Texture2D _cloudTexture;
        Texture2D _mountainTexture;
        Texture2D pineTexture;
        Texture2D skyTexture;
        GraphicsDeviceManager _graphics;
        public Background(Texture2D cloud, Texture2D mountain, Texture2D pine, Texture2D sky)
        {
            this._cloudTexture = cloud;
            this._mountainTexture = mountain;
            this.pineTexture = pine;
            this.skyTexture = sky;
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDeviceManager _graphics)
        {
            Vector2 back = new Vector2(0, 0);
            back.X = _graphics.PreferredBackBufferWidth;
            back.Y = _graphics.PreferredBackBufferHeight;
            spriteBatch.Draw(this.skyTexture, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, 5f, SpriteEffects.None, 0f);
            spriteBatch.Draw(this._mountainTexture, new Vector2(0, 150), null, Color.White, 0f, Vector2.Zero, 3f, SpriteEffects.None, 0f);
            spriteBatch.Draw(this._cloudTexture, new Vector2(0, 10), null, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
            spriteBatch.Draw(this.pineTexture, new Vector2(0, 250), null, Color.White, 0f, Vector2.Zero, 4.5f, SpriteEffects.None, 0f);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();

        }

        public void Draw(SpriteBatch spriteBatch, Texture2D objTexture)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime, int windowWidth, int widowHeight)
        {
            throw new NotImplementedException();
        }
    }
}
