using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Blocks;
using PlatformGame.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame
{
    internal class ScreenManager : IGameObject
    {
        Player Hero { get; set; }
        Helper Companion { get; set; }
        List<Block> BlockList { get; set; }
        Item item { get; set; }
        List<Item> ItemList { get; set; }
         ScreenType currentScreen = ScreenType.START;
        int[,] currentGamoard = new int[,]
            {};
        int[,] currentGamoard1 = new int[,]
{
        { 1,0,0,0,0,0,0,1,0,0,0,10 },
        { 1,0,0,0,0,0,0,1,0,0,0,0 },
        { 1,0,0,0,0,0,0,1,0,0,0,0 },
        { 1,1,1,1,1,1,0,1,0,0,0,0},
        { 1,0,0,0,0,0,0,2,0,0,0,0 },
        { 1,0,0,0,0,0,0,1,0,0,0,0 },
        { 1,0,0,0,0,0,0,0,0,0,0,0 },
        { 1,0,0,0,0,0,0,0,0,0,0,0},
        { 1,0,0,0,0,0,0,1,0,0,0,0 },
        { 1,0,0,0,0,0,0,1,0,0,0,0 },
        { 1,0,0,0,0,0,0,1,0,0,0,0 },
        { 1,0,0,0,0,0,0,1,0,0,0,0 },
        { 1,1,1,1,1,1,0,1,0,0,0,0},
        { 1,0,0,0,0,0,0,2,0,0,0,0 },
        { 1,0,0,0,0,0,0,8,0,0,0,0 },
        { 1,1,1,1,1,1,1,1,1,1,1,1},
        { 1,1,1,1,1,1,1,1,1,1,1,1}

};
        public ScreenManager(Player player, Helper helper, List<Block> blockList, Item item)    
        {
            Hero = player;
            Companion = helper;
            BlockList = blockList;
            this.item = item;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
        public void SetScreen(ScreenType setscreen)
        {
            currentScreen = setscreen;

        }
        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
        public enum ScreenType
        {
            START,
            GAMEOVER,
            LEVEL1,
            LEVEL2,
            ENDING
        }
    }
}
