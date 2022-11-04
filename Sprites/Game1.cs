using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PlatformGame;
using SharpDX.Direct2D1.Effects;
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
        Texture2D playerTexture;
        Vector2 blockPositie = new Vector2(40, 30);
        Rectangle playerRec;
        Rectangle playerRec2;
        Block block1;
        SpriteFont font;
        bool hasCollided = false;
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
            //block1 = new Block(new Vector2(50, 0), playerTexture.Width, playerTexture.Height, Color.Aquamarine, playerTexture);

            _graphics.PreferredBackBufferWidth = 1000;
            _graphics.PreferredBackBufferHeight = 1000;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();
            player = new Player(_playerTexture);
            //block1
            playerRec = new Rectangle((int)blockPositie.X, (int)blockPositie.Y, (player.textureWidth-25)/4, player.textureHeight);
            //block2
            playerRec2 = new Rectangle((int)blockPositie.X+280, (int)blockPositie.Y, (player.textureWidth - 25) / 4, player.textureHeight);
            capy = new Capybara(_capybara);
            background = new Background(_cloudTexture, _mountainTexture, _pineTexture, _skyTexture);
        }

        protected override void LoadContent()
        {
            playerTexture = new Texture2D(GraphicsDevice, 1, 1);
            playerTexture.SetData(new[] { Color.AliceBlue });
            //block1.LoadContent(GraphicsDevice);
            //player.block1.LoadContent(GraphicsDevice);
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here 
            player.Update(gameTime, _graphics.PreferredBackBufferWidth,_graphics.PreferredBackBufferHeight);
            capy.Update(gameTime, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            //block1.Update(gameTime, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            if (playerRec.Intersects(playerRec2)) hasCollided = true;
                playerRec.X++;
            playerRec2.X--;

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
            _spriteBatch.Draw(playerTexture, playerRec, Color.Red);
            _spriteBatch.Draw(playerTexture, playerRec2, Color.Green);
            //player.block1.Draw(_spriteBatch, playerTexture);
            player.Draw(_spriteBatch);
            capy.Draw(_spriteBatch);
            if(hasCollided)_spriteBatch.DrawString(font, "Gebotst", new Vector2(40, 0), Color.WhiteSmoke);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}