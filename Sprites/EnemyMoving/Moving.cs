using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.EnemyMoving
{
    internal class Moving : IMovingBehavior
    {
        public Vector2 Move(Vector2 position, Vector2 speed)
        {
            if (position.X > 800 - 50 || position.X < 0)
            {
                speed = new Vector2(speed.X * -1, speed.Y);
            }

            return speed;
        }
    }
}
