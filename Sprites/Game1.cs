using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PlatformGame;
using PlatformGame.Characters;
using PlatformGame.Terrain;
using SharpDX.Direct2D1;
using SharpDX.Direct2D1.Effects;
using SharpDX.Direct3D9;
using System.Collections.Generic;
using System.Diagnostics;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace Sprites
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        //dePokemonPlayer
        private Texture2D _playerTexture;
        private Texture2D _capybara;
        private Player player;
        private Background background;
        private Capybara capy;
        Texture2D _cloudTexture;
        Texture2D _mountainTexture;
        Texture2D _pineTexture;
        Texture2D _skyTexture;
        Texture2D boxPlayerTexture;
        Vector2 blockPositie = new Vector2(40, 30);
        Vector2 blockPositie2 = new Vector2(290, 30);
        Rectangle rec1;
        Rectangle rec2;
        Rectangle rec3;
        Block block1 = new Block();
        SpriteFont font;
        Block block;
        Block hitBoxPlayer;
        List<Block> blockList = new List<Block>();

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
            player = new Player(_playerTexture, boxPlayerTexture);
            //block1
            rec1 = new Rectangle((int)blockPositie.X, (int)blockPositie.Y, (player.textureWidth - 25) / 4, player.textureHeight);
            //block2
            rec2 = new Rectangle((int)blockPositie2.X, (int)blockPositie2.Y, 50, 50);
            rec3 = new Rectangle((int)player.Position2.X + 100,(int) player.Position2.Y, 50, 50);
            capy = new Capybara(_capybara);
            background = new Background(_cloudTexture, _mountainTexture, _pineTexture, _skyTexture);
            hitBoxPlayer = new Block();
            //blockList.Add(new Block(rec1, boxPlayerTexture, new Vector2(1, 1), Color.Red));
            //blockList.Add(new Block(rec2, boxPlayerTexture, new Vector2(-1, 1), Color.Red));
            blockList.Add(new Block(rec3, boxPlayerTexture, new Vector2(0, 0), Color.Blue));


        }

        protected override void LoadContent()
        {
            boxPlayerTexture = new Texture2D(GraphicsDevice, 1, 1);
            boxPlayerTexture.SetData(new[] { Color.White });

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            _playerTexture = Content.Load<Texture2D>("playersheetsprites (5)");
            _capybara = Content.Load<Texture2D>("./Capybara/CapybaraWalk");
            _cloudTexture = Content.Load<Texture2D>("./Background/cloud");
            _mountainTexture = Content.Load<Texture2D>("./Background/mountain2");
            _pineTexture = Content.Load<Texture2D>("./Background/pine1");
            _skyTexture = Content.Load<Texture2D>("./Background/sky");
            font = Content.Load<SpriteFont>("./Font/myFont");
        }

        protected override void Update(GameTime gameTime)
        {
            Debug.WriteLine("Updated");
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            for (int i = 0; i < blockList.Count; i++)
            {
                for (int j = i+1; j < blockList.Count; j++)
                {
                    blockList[i].Collide(blockList[j]);
                }

            }
            for (int i = 0; i < blockList.Count; i++)
            {
                player.Collide(blockList[i]);

            }
            foreach (var block in blockList)
            {
                block.Update(gameTime, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            }
            player.Update(gameTime, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
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
            foreach (var block in blockList)
            {
                block.Draw(_spriteBatch);
            }
            player.Draw(_spriteBatch, _playerTexture);
            capy.Draw(_spriteBatch, player);
            _spriteBatch.DrawString(font, "A_STRANGE_ENCOUNTER", new Vector2(_graphics.PreferredBackBufferWidth / 2 - 100, 50), Color.Black, 0f, new Vector2(1f, 1f), 3f, SpriteEffects.None, 0f);
            _spriteBatch.DrawString(font, player.healthBar.ToString(), new Vector2(_graphics.PreferredBackBufferWidth / 2 - 100, 400), Color.Black, 0f, new Vector2(1f, 1f), 3f, SpriteEffects.None, 0f);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}