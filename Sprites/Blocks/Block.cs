using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Blocks
{
    public abstract class Block
    {
        public Color Color { get; set; }
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle BoundingBox { get; set; }
        public Block(Vector2 position, Color color, Texture2D texture)
        {
            Position = position;
            Texture = texture;
            Color = color;
        }

        public abstract void Draw(SpriteBatch spriteBatch);


    }
}
