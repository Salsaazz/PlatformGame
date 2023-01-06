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
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle BoundingBox { get; set; }
        public Block(Vector2 position, Texture2D texture)
        {
            Position = position;
            Texture = texture;
        }

        public abstract void Draw(SpriteBatch spriteBatch);


    }
}
