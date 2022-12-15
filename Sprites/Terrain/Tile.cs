using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Terrain
{
    internal class Tile
    {
        private Texture2D texture;
        private Rectangle rectangle;
        int textureWidth;
        int textureHeight;

        Animation textureSprites;
        int x;
        int y;
        public Block HitBox { get; set; }
        public Tile(Texture2D texture, int totalSprites, int x, int y, Texture2D HitBoxtexture)
        {
            this.texture = texture;
            textureWidth = (int)((texture.Width / totalSprites));

            this.x = x;
            this.y = y;
            rectangle = new Rectangle(this.x, this.y, textureWidth, texture.Height);
            HitBox = new Block(new Rectangle(this.x, this.y, (int)(textureWidth * 3.5f), (int)(texture.Height *3.35f)), Color.LightBlue, HitBoxtexture);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            HitBox.Draw(spriteBatch);
            //spriteBatch.Draw(texture, Position, walkAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.None, 0f);

            spriteBatch.Draw(texture, new Vector2(x, y), new Rectangle(textureWidth, 0, textureWidth, texture.Height), Color.White, 0f, Vector2.Zero, new Vector2(3.6f, 3.6f), SpriteEffects.None, 0f);
            spriteBatch.Draw(texture, new Vector2(x, y), new Rectangle(0, 0, textureWidth, texture.Height), Color.White, 0f, Vector2.Zero, new Vector2(3.6f, 3.6f), SpriteEffects.None, 0f);
        }
    }
}