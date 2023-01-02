using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.EnemyMoving
{
    internal interface IMovingBehavior2
    {
        public Vector2 Move(Vector2 position, Vector2 speed);
    }
}
