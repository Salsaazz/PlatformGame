using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PlatformGame.Blocks;
using PlatformGame.Characters;
using PlatformGame.Enemies;
using PlatformGame.Interfaces;
using PlatformGame.Movement;
using PlatformGame.Terrain;
using SharpDX.Direct2D1;
using SharpDX.Direct2D1.Effects;
using SharpDX.Direct3D9;
using System.Collections.Generic;
using System.Diagnostics;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace PlatformGame
{
    public class Game1 : Game
    {
        //TODO tiles
        //FOOD collect
        //collide met enemy --> dood
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        //dePokemonPlayer
        private Player player;
        private Capybara capy;
        private Texture2D _playerTexture;
        private Texture2D _capyTexture;
        private Texture2D _crowTexture;
        private Background background;
        Texture2D _cloudTexture;
        Texture2D _mountainTexture;
        Texture2D _pineTexture;
        Texture2D _skyTexture;
        Texture2D HitBoxPlayerText;
        SpriteFont font;
        List<Blockies> blockList = new List<Blockies>();
        List<Blockies> textureBlockList = new List<Blockies>();
        Enemy crow;
        int[,] gameboard = new int[,]
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
        IInputReader inputReader;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            _graphics.PreferredBackBufferWidth = 1000;
            _graphics.PreferredBackBufferHeight = 1000;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();
            //player = new Player(_playerTexture, HitBoxPlayerText, inputReader);
            player = new Player(_playerTexture,HitBoxPlayerText, inputReader);
            capy = new Capybara(_capyTexture);
            //crow = new MovingEnemy(_crowTexture);
            background = new Background(_cloudTexture, _mountainTexture, _pineTexture, _skyTexture);
            for (int i = 0; i < 1000; i+=50)
            {
                blockList.Add(new Blockies(new Rectangle(100+i, 550, 50, 50), HitBoxPlayerText, Color.Blue));

            }
            for (int i = 0; i < 800; i+=50)
            {
                blockList.Add(new Blockies(new Rectangle(i+ 380, 250-i, 50, 50), HitBoxPlayerText, Color.Blue));

            }

        }

        protected override void LoadContent()
        {
            HitBoxPlayerText = new Texture2D(GraphicsDevice, 1, 1);
            HitBoxPlayerText.SetData(new[] { Color.White });


            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            _playerTexture = Content.Load<Texture2D>("playersheetsprites_0");
            _capyTexture = Content.Load<Texture2D>("./Capybara/CapybaraWalk");
            _cloudTexture = Content.Load<Texture2D>("./Background/cloud");
            _mountainTexture = Content.Load<Texture2D>("./Background/mountain2");
            _pineTexture = Content.Load<Texture2D>("./Background/pine1");
            _skyTexture = Content.Load<Texture2D>("./Background/sky");
            _crowTexture = Content.Load<Texture2D>("./Crow/Crow");
            font = Content.Load<SpriteFont>("./Font/myFont");
            inputReader = new KeyboardReader();
        }

        protected override void Update(GameTime gameTime)
        {
            Debug.WriteLine("Updated");
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            player.Update(gameTime, blockList);
            capy.Update(gameTime);
            base.Update(gameTime);
            // Debug.WriteLine(_graphics.PreferredBackBufferHeight);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            // TODO: Add your drawing code here
            background.Draw(_spriteBatch, _graphics);
            player.Draw(_spriteBatch);
            capy.Draw(_spriteBatch, player);
            _spriteBatch.DrawString(font, "A_STRANGE_ENCOUNTER", new Vector2(_graphics.PreferredBackBufferWidth / 2 - 100, 50), Color.Black, 0f, new Vector2(1f, 1f), 3f, SpriteEffects.None, 0f);
            _spriteBatch.DrawString(font, player.Health.ToString(), new Vector2(_graphics.PreferredBackBufferWidth / 2 - 100, 400), Color.Black, 0f, new Vector2(1f, 1f), 3f, SpriteEffects.None, 0f);
            foreach (var block in blockList)
            {
                block.Draw(_spriteBatch);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
         /*void CreateBlocks()
        {

            for (int i = 0; i < gameboard.GetLength(0); i++)
            {
                for (int j = 0; j < gameboard.GetLength(1); j++)
                {
                    if (gameboard[i, j] == 1)
                    {
                        blocks.Add(new BlockList(new Rectangle((j * 57), (i * 57), 57, 57), HitBoxPlayerText, Color.Green));
                    }
                }
            }

        }*/
        /* void CreateBlocks()
        {
            for (int l = 0; l < gameboard.GetLength(0); l++)
            {
                for (int k = 0; k < gameboard.GetLength(1); k++)
                {
                    if (gameboard[l,k] == 1)
                    {
                    textureBlockList.Add(blockFactory.CreateBlock(gameboard[l, k]), );

                    }
                    else
                        textureBlockList.Add(blockFactory.CreateBlock(gameboard[l, k]), );

                }
            }

        }*/
    }
}