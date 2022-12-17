using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Characters;
using PlatformGame.EnemyMoving;

namespace PlatformGame.Enemies
{
    internal class FollowingEnemy : Enemy
    {
        IMovingBehavior movingBehavior = new Following();
        /*public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }*/

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
            if (Position.X > 1000 - textureWidth)
            {
                Position = new Vector2(Position.X * -1, Position.Y);
            }
            //movingBehavior.Move(Position);
            gameTimer.UpdateCounter(gameTime);

        }
    }
}
