using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PlatformGame;
using PlatformGame.Characters;
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
        private Background background;
        Texture2D _cloudTexture;
        Texture2D _mountainTexture;
        Texture2D _pineTexture;
        Texture2D _skyTexture;
        Texture2D boxPlayerTexture;
        SpriteFont font;
        Block hitBoxPlayer;
        List<Block> blockList = new List<Block>();
        List<Block> blocks = new List<Block>();
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
            player = new Player(_playerTexture, boxPlayerTexture, inputReader);
            capy = new Capybara(_capyTexture);
            background = new Background(_cloudTexture, _mountainTexture, _pineTexture, _skyTexture);
            hitBoxPlayer = new Block();
            blockList.Add(new Block(new Rectangle(600, 450, 50, 50), boxPlayerTexture, Color.Blue));
            blockList.Add(new Block(new Rectangle(300, 550, 50, 50), boxPlayerTexture, Color.Blue));
            blockList.Add(new Block(new Rectangle(350, 550, 50, 50), boxPlayerTexture, Color.Blue));
            blockList.Add(new Block(new Rectangle(400, 550, 50, 50), boxPlayerTexture, Color.Blue));
            blockList.Add(new Block(new Rectangle(450, 550, 50, 50), boxPlayerTexture, Color.Blue));
            blockList.Add(new Block(new Rectangle(500, 550, 50, 50), boxPlayerTexture, Color.Blue));
            blockList.Add(new Block(new Rectangle(550, 550, 50, 50), boxPlayerTexture, Color.Blue));
            blockList.Add(new Block(new Rectangle(500, 400, 50, 50), boxPlayerTexture, Color.Blue));


            //CreateBlocks();
        }

        protected override void LoadContent()
        {
            boxPlayerTexture = new Texture2D(GraphicsDevice, 1, 1);
            boxPlayerTexture.SetData(new[] { Color.White });

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            _playerTexture = Content.Load<Texture2D>("playersheetsprites_0");
            _capyTexture = Content.Load<Texture2D>("./Capybara/CapybaraWalk");
            _cloudTexture = Content.Load<Texture2D>("./Background/cloud");
            _mountainTexture = Content.Load<Texture2D>("./Background/mountain2");
            _pineTexture = Content.Load<Texture2D>("./Background/pine1");
            _skyTexture = Content.Load<Texture2D>("./Background/sky");
            font = Content.Load<SpriteFont>("./Font/myFont");
            inputReader = new KeyboardReader();
        }

        protected override void Update(GameTime gameTime)
        {
            Debug.WriteLine("Updated");
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here

            //tiles draw

            player.Update(gameTime, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight, blockList);
            capy.Update(gameTime, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            base.Update(gameTime);

            // Debug.WriteLine(_graphics.PreferredBackBufferHeight);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            // TODO: Add your drawing code here
            //nog enemy, jumping player,tilesets met collision detections
            background.Draw(_spriteBatch, _graphics);
            player.Draw(_spriteBatch, _playerTexture);
            capy.Draw(_spriteBatch, player);
            _spriteBatch.DrawString(font, "A_STRANGE_ENCOUNTER", new Vector2(_graphics.PreferredBackBufferWidth / 2 - 100, 50), Color.Black, 0f, new Vector2(1f, 1f), 3f, SpriteEffects.None, 0f);
            _spriteBatch.DrawString(font, player.healthBar.ToString(), new Vector2(_graphics.PreferredBackBufferWidth / 2 - 100, 400), Color.Black, 0f, new Vector2(1f, 1f), 3f, SpriteEffects.None, 0f);
            foreach (var block in blockList)
            {
                block.Draw(_spriteBatch);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
         void CreateBlocks()
        {

            for (int i = 0; i < gameboard.GetLength(0); i++)
            {
                for (int j = 0; j < gameboard.GetLength(1); j++)
                {
                    if (gameboard[i, j] == 1)
                    {
                        blocks.Add(new Block(new Rectangle((j * 57), (i * 57), 57, 57), boxPlayerTexture, Color.Green));
                    }
                }
            }

        }

    }
}