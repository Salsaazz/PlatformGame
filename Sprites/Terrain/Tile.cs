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
    internal class Tile: Blok
    {
        private Texture2D texture;
        private Rectangle rectangle;
        private Texture2D BoundingBoxTexture;
        int textureWidth;
         public enum TileType{ GRASS, GROUND};
        public TileType TypeTile { get; set; }
        int x;
        int y;
        public Tile(Texture2D texture, int totalSprites, int x, int y, Texture2D boxTexture, TileType tileType)
            : base(new Vector2(x,y), Color.White, texture)
        {
            this.texture = texture;
            textureWidth = (int)((texture.Width / totalSprites));

            this.x = x;
            this.y = y;
            rectangle = new Rectangle(this.x, this.y, 32, 32);
            BoundingBox = new Rectangle(this.x, this.y, 32, 32);
            BoundingBoxTexture = boxTexture;
            this.TypeTile = tileType;
           
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(BoundingBoxTexture, BoundingBox, Color.White);
            if (TypeTile == TileType.GRASS)
            {
                spriteBatch.Draw(texture, new Vector2(x, y), new Rectangle(textureWidth, 0, textureWidth, texture.Height), Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
                spriteBatch.Draw(texture, new Vector2(x, y), new Rectangle(0, 0, textureWidth, texture.Height), Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
            }
            else if (TypeTile == TileType.GROUND)
            spriteBatch.Draw(texture, new Vector2(x, y), new Rectangle(textureWidth, 0, textureWidth, texture.Height), Color.White, 0f, Vector2.Zero,Vector2.One, SpriteEffects.None, 0f);


        }
    }
}