using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Blocks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Terrain
{
    internal class Tile: Block
    {
        private Rectangle rectangle;
        private Texture2D BoundingBoxTexture;
        int textureWidth;
         public enum TileType{ GRASS, GROUND};
        public TileType TypeTile { get; set; }
        public Tile(Texture2D texture, int totalSprites, Vector2 position, Texture2D boxTexture, TileType tileType)
            : base(position, texture)
        {
            textureWidth = (int)((texture.Width / totalSprites));
            rectangle = new Rectangle((int)Position.X, (int)Position.Y, 32, 32);
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, 32, 32);
            BoundingBoxTexture = boxTexture;
            this.TypeTile = tileType;
           
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            if (TypeTile == TileType.GRASS)
            {
                spriteBatch.Draw(Texture, Position, new Rectangle(textureWidth, 0, textureWidth, Texture.Height), Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
                spriteBatch.Draw(Texture,Position, new Rectangle(0, 0, textureWidth, Texture.Height), Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
            }
            else if (TypeTile == TileType.GROUND)
            spriteBatch.Draw(Texture, Position, new Rectangle(textureWidth, 0, textureWidth, Texture.Height), Color.White, 0f, Vector2.Zero,Vector2.One, SpriteEffects.None, 0f);


        }
    }
}