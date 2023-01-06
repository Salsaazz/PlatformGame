﻿using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PlatformGame.Blocks;
using PlatformGame.Characters;
using PlatformGame.Movement;
using PlatformGame.Timer;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keyboard = Microsoft.Xna.Framework.Input.Keyboard;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace PlatformGame.Screens
{
    internal class ScreenManager 
    {
        GameOverScreen gameOverScreen;
        StartScreen startScreen;
        Level level1;
        Level level2;
        TheEnd theEnd;
        ScreenType CurrentScreenType { get; set; } = ScreenType.START;
        Screen CurrentScreen { get; set; }
        KeyboardReader readKey = new KeyboardReader();
        /*public ScreenManager(GameOverScreen gameOverScreen,StartScreen startScreen,Level level1,
        Level level2,
        TheEnd theEnd)*/
        public ScreenManager(StartScreen startScreen, Level level1, Level level2, GameOverScreen gameOverScreen,
            TheEnd theEnd)
        {
            //this.gameOverScreen = gameOverScreen;
            this.startScreen = startScreen;
            CurrentScreen = this.startScreen;
            this.level1 = level1;
            this.level2 = level2;
            this.gameOverScreen = gameOverScreen;
            this.theEnd = theEnd;

        }
        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            //CurrentScreen.Draw(spriteBatch, font);
            switch (CurrentScreenType)
            {
                case ScreenType.START:
                    startScreen.Draw(spriteBatch, font);
                    break;
                case ScreenType.GAMEOVER:
                    gameOverScreen.Draw(spriteBatch, font);

                    break;
                case ScreenType.LEVEL1:
                    level1.Draw(spriteBatch, font);

                    break;
                case ScreenType.LEVEL2:
                    level2.Draw(spriteBatch, font);

                    break;
                case ScreenType.ENDING:
                    theEnd.Draw(spriteBatch, font);

                    break;
                default:
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {

            KeyboardState state = Keyboard.GetState();
            if (CurrentScreenType == ScreenType.START)
            {
                CurrentScreen = startScreen;

            }
            if (state.IsKeyDown(Keys.Enter) && CurrentScreenType == ScreenType.START ||
                state.IsKeyDown(Keys.Enter) && CurrentScreenType == ScreenType.GAMEOVER)
            {
                CurrentScreenType = ScreenType.LEVEL1;
                level1.RestartLevel();
                level2.RestartLevel();

            }

             if (CurrentScreenType == ScreenType.ENDING)
            {
                CurrentScreen = theEnd;
                if (state.IsKeyDown(Keys.Enter))
                {
                    CurrentScreenType = ScreenType.START;
                }
            }
             if (CurrentScreenType == ScreenType.LEVEL1)
            {

                if (level1.playerDead)
                {
                    CurrentScreenType = ScreenType.GAMEOVER;
                }
                else if (level1.player.Item >= 5 && level1.player.touchedGate)
                {
                    CurrentScreenType = ScreenType.LEVEL2;

                }
                else
                    CurrentScreen = level1;
            }
             if (CurrentScreenType == ScreenType.LEVEL2)
            {
                level2.RestartLevel();

                if (level2.playerDead)
                {
                    CurrentScreenType = ScreenType.GAMEOVER;
                }
                 if (level2.player.Item >= 5 && level2.player.touchedGate)
                {
                    CurrentScreenType = ScreenType.ENDING;

                }
                else
                { CurrentScreen = level2; 
                
                }
            }

             if (CurrentScreenType == ScreenType.GAMEOVER && state.IsKeyDown(Keys.RightShift) ||
                CurrentScreenType == ScreenType.GAMEOVER && state.IsKeyDown(Keys.LeftShift))
            {
                CurrentScreenType = ScreenType.START;

            }
             if (CurrentScreenType == ScreenType.GAMEOVER)
            {
                CurrentScreen = gameOverScreen;
            }
            CurrentScreen.Update(gameTime);
        
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
