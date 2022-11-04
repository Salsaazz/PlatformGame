using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame
{
    internal class Block : IGameObject
    {
        Rectangle rectangle;
        Vector2 positie;
        Texture2D objTexture;
        Color color;
        public Block()
        {
            throw new NotImplementedException();
        }
        public Block(Vector2 positie, int textureWidth, int textureHeight, Color color, Texture2D texture)
        {
            this.positie.X = positie.X;
            this.positie.Y = positie.Y;
            this.rectangle = new Rectangle((int)this.positie.X, (int)this.positie.Y, textureWidth, textureHeight);
            this.color = color;
            this.objTexture = texture;
        }
        public void Draw(SpriteBatch spriteBatch, Texture2D objTexture)
        {
            spriteBatch.Draw(objTexture, rectangle, this.color);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(objTexture, rectangle, this.color);
        }

        public void Update(GameTime gameTime, int windowWidth, int widowHeight)
        {
            this.positie.X += 1;
        }
        public void LoadContent(GraphicsDevice graphicsDevice)
        {
            objTexture = new Texture2D(graphicsDevice, 1, 1);
            objTexture.SetData(new[] { Color.White });
        }
    }
}
