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

namespace PlatformGame.Blocks.Enemies
{
    abstract class Enemy : Block
    {
        public Animation objectAnimation { get; set; }
        public bool IsLeft { get; set; } = false;
        public int TextureWidth { get; set; }
        public int TextureHeight { get; set; }
        public Texture2D BoundingBoxTexture { get; set; }
        public Vector2 Speed { get; set; }
        public bool IsDead { get; set; }
        public int Damage { get; set; }
        public IMovingBehavior MovingBehavior { get; set; }
        public Enemy(Vector2 position, Texture2D texture, Texture2D boxTexture, int totalSprites, int layers) : base(position, texture)
        {
            objectAnimation = new Animation(0.20d);
            objectAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, totalSprites, layers);
            IsDead = false;
            BoundingBoxTexture = boxTexture;
            Position = position;
            TextureWidth = texture.Width / totalSprites;
            TextureHeight = texture.Height;
        }


        public void Update(GameTime gameTime, Player player)
        {
            MovingBehavior.Move(player, this);
            Position += Speed;
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, TextureWidth, TextureHeight);
            objectAnimation.Update(gameTime);
        }

    }
}
