using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System.Diagnostics;

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
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
            player = new Player(_playerTexture);
            capy = new Capybara(_capybara);
            background = new Background(_cloudTexture, _mountainTexture, _pineTexture, _skyTexture);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _playerTexture = Content.Load<Texture2D>("playersheetsprites (5)");
            _capybara = Content.Load<Texture2D>("./Capybara/CapybaraWalk");
            _cloudTexture = Content.Load<Texture2D>("./Background/cloud");
             _mountainTexture = Content.Load<Texture2D>("./Background/mountain2");
            _pineTexture = Content.Load<Texture2D>("./Background/pine1");
            _skyTexture = Content.Load<Texture2D>("./Background/sky");
            Debug.WriteLine(",sklcc");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here 
            player.Update(gameTime, _graphics.PreferredBackBufferWidth,_graphics.PreferredBackBufferHeight);
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
            player.Draw(_spriteBatch);
            capy.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}