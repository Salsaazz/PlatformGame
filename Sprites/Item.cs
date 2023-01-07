using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Blocks;
using PlatformGame.Collision.Blocks;
using PlatformGame.Timer;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PlatformGame
{
    internal class Item : Block
    {
        public int TextureWidth { get; set; }
        public int TextureHeight { get; set; }
        public bool IsTaken { get; set; } = false;
        Random random = new Random();
        int number;
        public Item( Texture2D texture,int totalSprites,Vector2 position ) : base(position, texture)
        {
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
                        spriteBatch.Draw(Texture, Position, new Rectangle(0, 0, TextureWidth, TextureHeight), Color.White);
                        break;
                    case 1:
                        spriteBatch.Draw(Texture, Position, new Rectangle(TextureWidth, 0, TextureWidth, TextureHeight), Color.White);
                        break;
                    case 2:
                        spriteBatch.Draw(Texture, Position, new Rectangle(TextureWidth * 2, 0, TextureWidth, TextureHeight), Color.White);
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
