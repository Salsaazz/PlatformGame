using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Terrain
{
    internal class Tiles
    {
        public List<Block> blocks = new List<Block>();
        int[,] gameboard = new int[,]
     {
        { 1,1,1,1,1,1,1,1 },
        { 0,0,1,1,0,1,1,1 },
        { 1,0,0,0,0,0,0,1 },
        { 1,1,1,1,1,1,0,1 },
        { 1,0,0,0,0,0,0,2 },
        { 1,0,1,1,1,1,1,2 },
        { 1,0,0,0,0,0,0,0 },
        { 1,1,1,1,1,1,1,1 }
     };

        public void CreateBlocks(Texture2D texture) {

            for (int i = 0; i < gameboard.GetLength(0); i++)
            {
                for (int j = 0; j < gameboard.GetLength(1); j++)
                {
                    if (gameboard[i, j] == 1)
                    {
                        blocks.Add(new Block(new Rectangle((j * 10), (i * 10), 10, 10), texture, Color.Green));
                    }
                }
            }
        
        }
        

    }
}