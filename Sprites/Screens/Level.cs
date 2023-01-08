using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Blocks;
using PlatformGame.Blocks.Enemies;
using PlatformGame.Characters;
using PlatformGame.Terrain;
using SharpDX.Direct2D1;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static PlatformGame.Terrain.Tile;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace PlatformGame.Screens
{
    internal class Level : Screen
    {
        Background background;
        Texture2D heart;
        List<Block> blocks;
        Vector2 restartPlayerPosition;
        List<Vector2> restartBlocksPosition;
        public Player player { get; set; }
        Helper helper;
        Item item;
        Fence fence;
        string text;
        Color textColor;
        public bool playerDead { get; set; }

        public Level(Background background, List<Block> blockList, Player player, Helper helper, SpriteFont font
            , Item item, Texture2D heart)
            : base(font)
        {
            this.background = background;
            this.heart = heart;
            blocks = blockList;
            this.player = player;
            this.helper = helper;
            this.item = item;
            playerDead = false;
            restartBlocksPosition = new List<Vector2>();
            text = "LOCKED";
            textColor = Color.Red;
            for (int i = 0; i < blocks.Count; i++)
            {
                restartBlocksPosition.Add(blockList[i].Position);
                if (blocks[i] is Fence)
                {
                    Fence  temp = blockList[i] as Fence;
                    fence = temp;
                }
            }
           
            restartPlayerPosition = player.Position;
        }
        public override void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            background.Draw(spriteBatch);
            foreach (var block in blocks)
            {
                if (block is Fence) fence = block as Fence;
                block.Draw(spriteBatch);
            }
            spriteBatch.Draw(item.Texture, new Vector2(400, 15), new Rectangle(item.TextureWidth, 0, item.TextureWidth, item.TextureHeight), Color.White, 0f, Vector2.Zero, new Vector2(2f, 2f), SpriteEffects.None, 0f);
            spriteBatch.DrawString(font, ":" + player.Item.ToString(), new Vector2(450,25), Color.Black, 0f, new Vector2(1f, 1f), 2f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(font, "LIVES: ", new Vector2(50, 25), Color.Black, 0f, new Vector2(1f, 1f), 1.5f, SpriteEffects.None, 0f);

            for (int i = 0; i < player.Health *32; i+= 32)
            {
                spriteBatch.Draw(heart, new Vector2(i +130, 15), new Rectangle(0, 0, heart.Width, heart.Height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

            }
            if (player.Item >= 5)
            {
                text = "UNLOCKED";
                textColor = Color.Green;
            }
            else { 
                textColor = Color.Red;
                text = "LOCKED";
            }

            spriteBatch.DrawString(font, text, new Vector2(fence.Position.X, fence.Position.Y -20), textColor, 0f, new Vector2(1f, 1f), 1f, SpriteEffects.None, 0f);
            player.Draw(spriteBatch);
            helper.Draw(spriteBatch, player);
        }

        public override void Update(GameTime gameTime)
        {
            if (player.Health <= 0)
            {
                playerDead = true;
            }
            else playerDead = false;
            foreach (var block in blocks)
            {
                if (block is Enemy)
                {
                    Enemy temp = block as Enemy;
                    temp.Update(gameTime, player);
                }
            }
            player.Update(gameTime, blocks);
            helper.Update(gameTime);
            background.Update(gameTime);
        }
        public void RestartLevel()
        {
            player.Position = restartPlayerPosition;
            playerDead = false;
            player.Item = 0;
            player.Health = 5;
            player.touchedGate = true;
            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i].Position = restartBlocksPosition[i];
                if (blocks[i] is Item)
                {
                    Item temp = blocks[i] as Item;
                    temp.IsTaken = false;
                }
            }

        }
    }
}
