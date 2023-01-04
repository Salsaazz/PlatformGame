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
using Tile = PlatformGame.Terrain.Tile;

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
        private Helper capy;
        private Texture2D _playerTexture;
        private Texture2D _catTexture;
        private Texture2D _crowTexture;
        private Background background;
        Texture2D _cloudTexture;
        Texture2D _mountainTexture;
        Texture2D _pineTexture;
        Texture2D _skyTexture;
        Texture2D _cobraTexture;
        Texture2D _porcupineTexture;
        Texture2D HitBoxTexture;
        Texture2D _foodTexture;
        Texture2D _tile;
        SpriteFont font;
        StartScreen startScreen;
        List<Blocks.Block> gameObjects = new List<Blocks.Block>();
        List<Tile> textureBlockList = new List<Tile>();

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
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 800;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();
            player = new Player(_playerTexture,HitBoxTexture, inputReader);
            capy = new Helper(_catTexture);
            textureBlockList.Add(new Tile(_tile, 2, 500, 670, HitBoxTexture, Tile.TileType.GRASS));
            background = new Background(_cloudTexture, _mountainTexture, _pineTexture, _skyTexture);
            for (int i = 0; i < 2000; i+=32)
            {

                gameObjects.Add(new Tile(_tile, 2, 600-i,500, HitBoxTexture, Tile.TileType.GRASS));

            }

            gameObjects.Add(new MovingEnemy( _crowTexture, HitBoxTexture,  Color.Red, new Vector2(100, 500), 3, 1));
            gameObjects.Add(new FollowingEnemy(_cobraTexture, HitBoxTexture, Color.Green, new Vector2(100, 600), 4, 1));
            gameObjects.Add(new StandingEnemy(_porcupineTexture, HitBoxTexture, Color.Green, new Vector2(400, 470), 2, 1));
            gameObjects.Add(new Item(new Vector2(400, 400), Color.White, _foodTexture, 3));
            startScreen = new StartScreen();
        }

        protected override void LoadContent()
        {
            HitBoxTexture = new Texture2D(GraphicsDevice, 1, 1);
            HitBoxTexture.SetData(new[] { Color.White });


            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            _playerTexture = Content.Load<Texture2D>("./Player/Dude_Monster_Walk_6");
            _catTexture = Content.Load<Texture2D>("./Cat/Cat Sprite Sheet");
            _cloudTexture = Content.Load<Texture2D>("./Background/cloud");
            _mountainTexture = Content.Load<Texture2D>("./Background/mountain2");
            _pineTexture = Content.Load<Texture2D>("./Background/pine1");
            _skyTexture = Content.Load<Texture2D>("./Background/sky");
            _crowTexture = Content.Load<Texture2D>("./Crow/Crow2");
            _cobraTexture = Content.Load<Texture2D>("./cobra/snake3");
            _porcupineTexture = Content.Load<Texture2D>("./Porcupine/Porcupine Sprite Sheet (2)");
            _foodTexture = Content.Load<Texture2D>("./Food/FISH");
            _tile = Content.Load<Texture2D>("./Tiles/spritesheet (4)");
            font = Content.Load<SpriteFont>("./Font/myFont");
            inputReader = new KeyboardReader();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            startScreen.Update(gameTime);
            player.Update(gameTime, gameObjects);
            capy.Update(gameTime);
            foreach (var gobject in gameObjects)
            {
                if (gobject is Enemy)
                {
                    Enemies.Enemy temp = gobject as Enemies.Enemy;
                    temp.Update(gameTime, player);
                }

            }

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            // TODO: Add your drawing code here
            background.Draw(_spriteBatch, _graphics);
            startScreen.Draw(_spriteBatch, font);

            player.Draw(_spriteBatch);
            capy.Draw(_spriteBatch, player);
            _spriteBatch.DrawString(font, "A_STRANGE_ENCOUNTER", new Vector2(_graphics.PreferredBackBufferWidth / 2 - 100, 50), Color.Black, 0f, new Vector2(1f, 1f), 3f, SpriteEffects.None, 0f);
            _spriteBatch.DrawString(font, player.Health.ToString(), new Vector2(_graphics.PreferredBackBufferWidth / 2 - 100, 400), Color.Black, 0f, new Vector2(1f, 1f), 3f, SpriteEffects.None, 0f);
            foreach (var gameObject in gameObjects)
            {
                gameObject.Draw(_spriteBatch);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}