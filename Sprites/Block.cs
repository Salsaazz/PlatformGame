using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame
{
    internal class Block : IGameComponent, ICollide<Block>
    {
        Rectangle rectangle;
        public Vector2 positie;
        public Texture2D objTexture;
        Color color;
        Vector2 snelheid;
        Vector2 direction = new Vector2(1, 1);
        public Block()
        {
        }
        public Block(Rectangle rectangle, Texture2D texture, Vector2 snelheid, Color color)
        {

            this.rectangle = rectangle;
            this.objTexture = texture;
            this.snelheid = snelheid;
            this.color = color;
            this.positie.X = this.rectangle.X;
            this.positie.Y = this.rectangle.Y;
        }

        public void Update(GameTime gameTime, int windowWidth, int widowHeight)
        {
            snelheid *= direction;
            positie += snelheid;
            this.rectangle.X = (int)positie.X;
            this.rectangle.Y = (int)positie.Y;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.objTexture, this.rectangle, this.color);
        }

        public void Collide(Block block)
        {
            if (this.rectangle.Intersects(block.rectangle))
            {
                this.direction.X *= -1;
                block.direction.X *= -1;
                this.color = Color.White;
                block.color = Color.White;
            }

        }
    }
}
