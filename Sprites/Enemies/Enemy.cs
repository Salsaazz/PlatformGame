using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Blocks;
using PlatformGame.Characters;
using PlatformGame.Timer;
using PlatformGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Enemies
{
    abstract class Enemy: Blok
    {
        //public int DamagePerSec { get; set; }
        public Rectangle RectangleTexture { get; set; }
        public Animation objectAnimation { get; set; } = new Animation(0.20d);
        public bool IsLeft { get; set; } = false;
        public int textureWidth { get; set; }
        public int textureHeight { get; set; } = 1;
        public Texture2D BoundingBoxTexture { get; set; }
        public GameTimer gameTimer = new GameTimer();
        public Vector2 Speed { get; set; } = Vector2.Zero;
        public bool IsDead { get; set; } = false;
        public int Damage { get; set; }
        public Enemy( Vector2 position,Color color, Texture2D texture, Texture2D boxTexture,int totalSprites, int layers) : base(position,color, texture)
        {
            Texture = texture;
            BoundingBoxTexture = boxTexture;
            Position = position;
            textureWidth = texture.Width / totalSprites;
            textureHeight = texture.Height;
        }


        abstract public void Update(GameTime gameTime, Player player);


    }
}
