using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Blocks;
using PlatformGame.Characters;
using PlatformGame.Collision.Blocks;
using PlatformGame.EnemyMoving;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Standing = PlatformGame.Collision.Blocks.Standing;

namespace PlatformGame.Enemies
{
    internal class StandingEnemy : Enemy
    {
        MovingBehavior movingBehavior = new Standing();
        public StandingEnemy(Texture2D texture, Texture2D boxTexture, Color color, Vector2 position, int totalSprites, int layers)
            : base(position, color, texture, boxTexture, totalSprites, layers)
        {
            Position = position;
            Speed = new Vector2(0, 0);
            Texture = texture;
            objectAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, totalSprites, layers);
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, textureWidth, textureHeight);
            Damage = 4;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BoundingBoxTexture, BoundingBox, Color.Red);

            spriteBatch.Draw(Texture, Position, objectAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), Vector2.One, SpriteEffects.None, 0f);

        }

        public override void Update(GameTime gameTime, Player player)
        {
            movingBehavior.Move(player, this);
            objectAnimation.Update(gameTime);
        }
    }
}
