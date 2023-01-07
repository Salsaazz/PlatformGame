using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame
{
    internal class Fence : Block
    {
        Rectangle rectangle;
        public Fence(Vector2 position,Texture2D texture) : base(position, texture)
        {
            rectangle = new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, rectangle, Color.DarkOliveGreen);
        }
    }
}
