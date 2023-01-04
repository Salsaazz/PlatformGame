using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Blocks;
using PlatformGame.Collision.Blocks;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame
{
    internal class Item : Block
    {
        public int TextureWidth { get; set; }
        public int TextureHeight { get; set; }
        public bool IsTaken { get; set; } = false;
        Random random = new Random();
        int number;
        public Item(Vector2 position, Color color, Texture2D texture, int totalSprites) : base(position, color, texture)
        {
            Position = position;
            Color = color;
            Texture = texture;
            TextureWidth = texture.Width / totalSprites;
            TextureHeight = texture.Height;
            number = random.Next(0, totalSprites);
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, TextureWidth, TextureHeight);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsTaken)
            {
                switch (number)
                {
                    case 0:
                        spriteBatch.Draw(Texture, Position, new Rectangle(0, 0, TextureWidth, TextureHeight), Color);
                        break;
                    case 1:
                        spriteBatch.Draw(Texture, Position, new Rectangle(TextureWidth, 0, TextureWidth, TextureHeight), Color);
                        break;
                    case 2:
                        spriteBatch.Draw(Texture, Position, new Rectangle(TextureWidth * 2, 0, TextureWidth, TextureHeight), Color);
                        break;
                    default:
                        break;
                }
            }
        }


    }
}
