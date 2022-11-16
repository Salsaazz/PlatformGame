using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using Sprites;
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
        public Vector2 positie;
        public Texture2D objTexture;
        public Color color;
        Vector2 snelheid;
        public Vector2 direction = new Vector2(1, 1);
        public List<Block> blockLijst = new List<Block>();
        public float teller = 0;
        public int damagePerSec = 2;
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
            //addBlock(rectangle, texture, snelheid, color);
        }
        private void addBlock(Rectangle rectangle, Texture2D texture, Vector2 snelheid, Color color)
        {
            blockLijst.Add(new Block(rectangle, texture, snelheid, color));
        }
        public Block(Rectangle rectangle)
        {

            this.rectangle = rectangle;
            //this.objTexture = texture;
            this.snelheid = new Vector2(2, 2);
            this.color = Color.Black;
            this.positie.X = this.rectangle.X;
            this.positie.Y = this.rectangle.Y;

        }
        public void Update(GameTime gameTime, int windowWidth, int widowHeight)
        {
            snelheid *= direction;
            positie += snelheid;
            this.rectangle.X = (int)positie.X;
            this.rectangle.Y = (int)positie.Y;
            teller += teller<1000?(float)gameTime.ElapsedGameTime.TotalMilliseconds:1000;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.objTexture, this.rectangle, this.color);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture, Rectangle rectangle, Color color)
        {
            spriteBatch.Draw(texture, rectangle, color);
        }
        //public void Collide(Block block)
        //{
        //    for (int i = 0; i < blockLijst.Count; i++)
        //    {
        //        for (int j = i; j < blockLijst.Count; j++)
        //        {
        //            if (blockLijst[i].rectangle.Intersects(blockLijst[j].rectangle))
        //            {
        //                blockLijst[i].direction.X *= -1;
        //                blockLijst[j].direction.X *= -1;
        //                blockLijst[i].color = Color.White;
        //                blockLijst[j].color = Color.White;
        //            }
        //        }
        //    }
        //}
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
        //public void CollideMethod()
        //{
        //    for (int i = 0; i < blockLijst.Count; i++)
        //    {
        //        for (int j = i; j < blockLijst.Count; j++)
        //        {
        //            if (blockLijst[i].rectangle.Intersects(blockLijst[j].rectangle))
        //            {
        //                blockLijst[i].direction.X *= -1;
        //                blockLijst[j].direction.X *= -1;
        //                blockLijst[i].color = Color.White;
        //                blockLijst[j].color = Color.White;
        //            }
        //        }
        //    }
        //}
 
