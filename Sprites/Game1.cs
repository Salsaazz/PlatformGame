using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using PlatformGame.Blocks;
using PlatformGame.Characters;
using PlatformGame.Enemies;
using PlatformGame.Interfaces;
using PlatformGame.Movement;
using PlatformGame.Screens;
using PlatformGame.Terrain;
using SharpDX.Direct2D1;
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
        private Player player;
        private Helper helper;
        Item item;
        private Texture2D _playerTexture;
        private Texture2D _capybara;
        private Player player;
        private Background background;
        private Capybara capy;
        Texture2D _cloudTexture;
        Texture2D _mountainTexture;
        Texture2D _pineTexture;
        Texture2D _skyTexture;
        Texture2D _cobraTexture;
        Texture2D _porcupineTexture;
        Texture2D HitBoxTexture;
        Texture2D _foodTexture;
        Texture2D _tile;
        Texture2D _gameOverTexture;
        Texture2D _fenceTexture;
        SpriteFont font;
        GameOverScreen gameOverScreen;
        StartScreen startScreen;
        Level level1;
        Level level2;

        TheEnd theEnd;
        ScreenManager screenManager;
        Fence fence;
        List<Block> blocks1 = new List<Block>();
        List<Block> blocks2 = new List<Block>();
        Song song;
        int[,] gameboard1 = new int[,]
{
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,2,2,2,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,0,2,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2 },
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,2 },
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,2,2,0,0,0,0,0,2,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,1,1,2,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,1,1,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,2,0,2,0,0,0,0,0,0,0,2,0,0,0,0,0,0,1,2,0,0,0,2,2,2,2 },
        { 1,0,0,0,0,0,0,0,0,2,0,0,0,0,0,2,0,0,0,0,0,0,0,1,1,2,0,0,0,0,0,1 },
        { 1,0,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,2,2,2,2,0,0,0,2,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,1,1,1,0,0,0,0,0,1 },
        { 1,0,0,0,0,2,2,0,0,0,0,0,0,0,0,0,2,0,0,0,2,0,0,1,1,1,0,0,0,0,0,2 },
        { 2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,1,1,2,0,0,0,0,0,2 },
        { 2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},


};
        int[,] gameboard2 = new int[,]
{
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
        { 1,0,0,0,0,0,0,0,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,2,2,0,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,2,2,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,2,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,1 },
        { 2,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,2,0,0,0,0,0,0,0,2,0,0,0,0,0,2,2,2,0,0,2,2,0,0,0,0,0,0,0,0,0,2 },
        { 1,0,0,2,2,0,0,0,0,2,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,2,2,0,0,0,2,2,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1 },
        { 2,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,2 },
        { 2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,0,0,2,2,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,0,0,0,0,0,0,0 },
        { 2,0,0,0,0,2,1,1,1,1,2,2,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0 },
        { 2,2,2,2,2,2,1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},


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
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
            player = Player.GetInstance();
            player.Init(_playerTexture, HitBoxTexture, inputReader);
            helper = new Helper(_catTexture);
            item = new Item(_foodTexture,3,new Vector2(10, 10));
            background = new Background(_cloudTexture, _mountainTexture, _pineTexture, _skyTexture);

            CreateBlocks(gameboard1, blocks1);
            CreateBlocks(gameboard2, blocks2);

            fence = new Fence(new Vector2(950, 64), _fenceTexture);
            blocks1.Add(new Fence(new Vector2(950, 64), _fenceTexture));
            blocks1.Add(new FollowingEnemy(_cobraTexture, HitBoxTexture, new Vector2(600, 620), 4, 1));
            blocks1.Add(new Fence(new Vector2(950, 64), _fenceTexture));
            blocks1.Add(new StandingEnemy(_porcupineTexture, HitBoxTexture, new Vector2(255, 369), 2, 1));
            blocks1.Add(new StandingEnemy(_porcupineTexture, HitBoxTexture, new Vector2(478, 402), 2, 1));
            blocks1.Add(new StandingEnemy(_porcupineTexture, HitBoxTexture, new Vector2(833, 655), 2, 1));
            blocks1.Add(new StandingEnemy(_porcupineTexture, HitBoxTexture, new Vector2(858, 655), 2, 1));
            blocks1.Add(new StandingEnemy(_porcupineTexture, HitBoxTexture, new Vector2(893, 655), 2, 1));
            blocks1.Add(new StandingEnemy(_porcupineTexture, HitBoxTexture, new Vector2(928, 655), 2, 1));
            blocks1.Add(new StandingEnemy(_porcupineTexture, HitBoxTexture, new Vector2(963, 655), 2, 1));
            blocks1.Add(new StandingEnemy(_porcupineTexture, HitBoxTexture, new Vector2(900, 80), 2, 1));
            blocks1.Add(new MovingEnemy(_crowTexture, HitBoxTexture, new Vector2(950, 448), 3, 1));
            blocks1.Add(new MovingEnemy(_crowTexture, HitBoxTexture, new Vector2(70, 352), 3, 1));
            blocks1.Add(new MovingEnemy(_crowTexture, HitBoxTexture, new Vector2(250, 96), 3, 1));       
            blocks1.Add(new Item(_foodTexture, 3 ,new Vector2(66, 415)));
            blocks1.Add(new Item(_foodTexture, 3, new Vector2(386, 448)));
            blocks1.Add(new Item(_foodTexture, 3, new Vector2(958, 360)));
            blocks1.Add(new Item(_foodTexture, 3, new Vector2(802, 354)));
            blocks1.Add(new Item(_foodTexture, 3, new Vector2(638, 105)));

            blocks2.Add(new Fence(new Vector2(950, 640), _fenceTexture));
            blocks2.Add(new StandingEnemy(_porcupineTexture, HitBoxTexture, new Vector2(253, 368), 2, 1));
            blocks2.Add(new StandingEnemy(_porcupineTexture, HitBoxTexture, new Vector2(375, 368), 2, 1));
            blocks2.Add(new StandingEnemy(_porcupineTexture, HitBoxTexture, new Vector2(637, 655), 2, 1));
            blocks2.Add(new StandingEnemy(_porcupineTexture, HitBoxTexture, new Vector2(675, 655), 2, 1));
            blocks2.Add(new StandingEnemy(_porcupineTexture, HitBoxTexture, new Vector2(600, 655), 2, 1));
            blocks2.Add(new StandingEnemy(_porcupineTexture, HitBoxTexture, new Vector2(500, 655), 2, 1));
            blocks2.Add(new StandingEnemy(_porcupineTexture, HitBoxTexture, new Vector2(552, 655), 2, 1));
            blocks2.Add(new StandingEnemy(_porcupineTexture, HitBoxTexture, new Vector2(578, 111), 2, 1));
            blocks2.Add(new StandingEnemy(_porcupineTexture, HitBoxTexture, new Vector2(834, 464), 2, 1));
            blocks2.Add(new StandingEnemy(_porcupineTexture, HitBoxTexture, new Vector2(930, 464), 2, 1));
            blocks2.Add(new MovingEnemy(_crowTexture, HitBoxTexture, new Vector2(683, 192), 3, 1));
            blocks2.Add(new MovingEnemy(_crowTexture, HitBoxTexture, new Vector2(250, 96), 3, 1));
            blocks2.Add(new MovingEnemy(_crowTexture, HitBoxTexture, new Vector2(100, 511), 3, 1));
            blocks2.Add(new FollowingEnemy(_cobraTexture, HitBoxTexture, new Vector2(560, 620), 4, 1));
            blocks2.Add(new Item(_foodTexture, 3, new Vector2(93, 520)));
            blocks2.Add(new Item(_foodTexture, 3, new Vector2(34, 266)));
            blocks2.Add(new Item(_foodTexture, 3, new Vector2(414, 361)));
            blocks2.Add(new Item(_foodTexture, 3, new Vector2(614, 105)));
            blocks2.Add(new Item(_foodTexture, 3, new Vector2(738, 553)));

            level1 = new Level(background, blocks1, player, helper, font, item, _heartTexture);
            level2 = new Level(background, blocks2, player, helper, font, item, _heartTexture);

            gameOverScreen = new GameOverScreen(font, _gameOverTexture);
            theEnd = new TheEnd(font, _theEndtexture);
            startScreen = new StartScreen(font, _startScreentexture, player, _cloudTexture);
            screenManager = new ScreenManager(startScreen, level1, level2, gameOverScreen, theEnd);
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
            _crowTexture = Content.Load<Texture2D>("./Crow/Crow2");
            _cobraTexture = Content.Load<Texture2D>("./Cobra/snake3");
            _porcupineTexture = Content.Load<Texture2D>("./Porcupine/Porcupine Sprite Sheet (2)");
            _foodTexture = Content.Load<Texture2D>("./Food/FISH");
            _tile = Content.Load<Texture2D>("./Tiles/spritesheet (4)");
            _fenceTexture = Content.Load<Texture2D>("./Fence/WoodenFence (1)");
            font = Content.Load<SpriteFont>("./Font/myFont");
            inputReader = new KeyboardReader();
            song = Content.Load<Song>("Song/Song");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            screenManager.Update(gameTime); 
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