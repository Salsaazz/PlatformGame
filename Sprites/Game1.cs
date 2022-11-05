using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PlatformGame;
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
        Texture2D playerTexture;
        Vector2 blockPositie = new Vector2(40, 30);
        Vector2 blockPositie2 = new Vector2(290, 30);
        Rectangle playerRec;
        Rectangle playerRec2;
        Block block1 =  new Block();
        SpriteFont font;
        List<Block> blocks = new List<Block>(2);
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
            player = new Player(_playerTexture);
            //block1
            playerRec = new Rectangle((int)blockPositie.X, (int)blockPositie.Y, (player.textureWidth-25)/4, player.textureHeight);
            //block2
            playerRec2 = new Rectangle((int)blockPositie2.X, (int)blockPositie2.Y, 50 , 50);
            //block1 = new Block(blockPositie, playerRec, playerTexture, Color.Blue);
            //blokken toevoegen
            capy = new Capybara(_capybara);

            blocks.Add(new Block(playerRec, playerTexture, new Vector2(1, 1), Color.Blue));
            blocks.Add(new Block(playerRec2, playerTexture, new Vector2(-1,1),Color.Red));
            background = new Background(_cloudTexture, _mountainTexture, _pineTexture, _skyTexture);
        }

        protected override void LoadContent()
        {
            playerTexture = new Texture2D(GraphicsDevice, 1, 1);
            playerTexture.SetData(new[] { Color.White });
            //block1.objTexture = playerTexture;
            //block1.Initialize();

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
            /*if (playerRec.Intersects(playerRec2)) hasCollided = true;
                playerRec.X++;*/
            //playerRec2.X--;
            //blockPositie.X += 10;
            //block1.Update(gameTime, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight, blockPositie);
            Collided(blocks);
            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i].Update(gameTime, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            }
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
            _spriteBatch.DrawString(font, "A_STRANGE_ENCOUNTER", new Vector2(_graphics.PreferredBackBufferWidth/3 -100, 50), Color.Black, 0f, new Vector2(1f,1f), 3f, SpriteEffects.None,0f);
            //draw all blocks
            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i].Draw(_spriteBatch);
            }
            _spriteBatch.DrawString(font, blocks[0].positie.X.ToString(), blockPositie, Color.Black);
            _spriteBatch.DrawString(font, blocks[1].positie.X.ToString(), blockPositie2, Color.Black);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

         void Collided(List<Block> blocks)
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                for (int j = i+1; j < blocks.Count; j++)
                {
                    blocks[i].Collide(blocks[j]);
                }
            }

        }
    }
}