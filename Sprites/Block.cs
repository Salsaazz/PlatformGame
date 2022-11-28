using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame
{
    internal class Block : ICollide<Block>
    {
        public Rectangle rectangle;
        public Vector2 Position;
        public Texture2D objTexture;
        public Color color;
        Vector2 snelheid;
        public Vector2 direction = new Vector2(1, 1);
        public List<Block> blockLijst = new List<Block>();
        public float teller = 0;
        public int damagePerSec = 2;
        public bool IsDead { get; set; } = false;
        public blockType type { get; set; } = blockType.Tile;
        public enum blockType { Enemy, Tile }

        public Block()
        {
        }
        public Block(Rectangle rectangle, Texture2D texture, Vector2 snelheid, Color color)
        {

            this.rectangle = rectangle;
            this.objTexture = texture;
            this.snelheid = snelheid;
            this.color = color;
            this.Position.X = this.rectangle.X;
            this.Position.Y = this.rectangle.Y;
            //addBlock(rectangle, texture, Velocity, color);
        }
        public Block(Rectangle rectangle, Texture2D texture, Color color)
        {

            this.rectangle = rectangle;
            this.objTexture = texture;
            this.snelheid = new Vector2(0, 0);
            this.color = color;
            this.Position.X = this.rectangle.X;
            this.Position.Y = this.rectangle.Y;
        }
        private void addBlock(Rectangle rectangle, Texture2D texture, Vector2 snelheid, Color color)
        {
            blockLijst.Add(new Block(rectangle, texture, snelheid, color));
        }

        public Block(Rectangle rectangle)
        {

            this.rectangle = rectangle;
            this.snelheid = new Vector2(2, 2);
            this.color = Color.Black;
            this.Position.X = this.rectangle.X;
            this.Position.Y = this.rectangle.Y;

        }
        public void Update(GameTime gameTime, int windowWidth, int widowHeight)
        {
            snelheid *= direction;
            Position += snelheid;
            this.rectangle.X = (int)Position.X;
            this.rectangle.Y = (int)Position.Y;
            teller += teller < 1000 ? (float)gameTime.ElapsedGameTime.TotalMilliseconds : 1000;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsDead)
                spriteBatch.Draw(this.objTexture, this.rectangle, this.color);

        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture, Rectangle rectangle, Color color)
        {
            if (!IsDead)
                spriteBatch.Draw(texture, rectangle, color);

        }
        public bool Collide(Block block)
        {

            if (this.rectangle.Intersects(block.rectangle))
            {
                this.direction.X *= -1;
                block.direction.X *= -1;
                this.color = Color.White;
                block.color = Color.White;
            }
            //TODO
            return false;
        }
    }
}

