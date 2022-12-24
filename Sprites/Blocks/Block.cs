using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Blocks
{
    internal class Block
    {

        public Color Color { get; set; }
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle RectangleBlock { get; set; }
        public Block(Rectangle rectangle, Color color, Texture2D texture)
        {
            RectangleBlock = rectangle;
            Texture = texture;
            Position = new Vector2(rectangle.X, rectangle.Y);
            Color = color;

        }

        public Block(Rectangle rectangle)
        {
            RectangleBlock = rectangle;
            Position = new Vector2(rectangle.X, rectangle.Y);
            Color = Color.Red;

        }
        public void Draw(SpriteBatch spriteBatch)
        {
                spriteBatch.Draw(Texture, RectangleBlock, Color);

        }


    }
}
