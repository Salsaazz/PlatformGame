using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Blocks;
using PlatformGame.Characters;
using PlatformGame.EnemyMoving;
using PlatformGame.Interfaces;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Enemies
{
    internal class MovingEnemy : Enemy
    {
        IMovingBehavior movingBehavior = new Moving();
        public MovingEnemy(Texture2D texture, Texture2D HitBoxTexture, Vector2 position, int totalSprites, int layers)
        {
            Position = position;
            Speed = new Vector2(2, 0);
            Texture = texture;
            objectAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, totalSprites, layers);
            textureWidth = texture.Width / totalSprites;
            HitBox = new Block(new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height), Color.Red, HitBoxTexture);
        }



        public override void Update(GameTime gameTime, Player player)
        {
            if (player.HitBox.RectangleBlock.Intersects(HitBox.RectangleBlock))
            {
                if (gameTimer.Counter == 1000)
                {
                    player.Health--;
                    gameTimer.Counter = 0;
                }
            }

            //HitbBox updaten (door position,moet mee veranderen met de sprite)
            Speed = movingBehavior.Move(this.Position, Speed);
            Position += Speed;
            HitBox = new Block(new Rectangle((int)Position.X, (int)Position.Y, textureWidth, Texture.Height), Color.Red, HitBox.Texture);
            objectAnimation.Update(gameTime);
            Debug.WriteLine(Position.X);
        }
    }
}
