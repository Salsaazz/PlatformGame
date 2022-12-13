using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Timer
{
    internal class GameTimer
    {
        public float Counter { get; set; } = 0;
        public void UpdateCounter(GameTime gameTime)
        {
            this.Counter += this.Counter < 1000 ? (float)gameTime.ElapsedGameTime.TotalMilliseconds : 1000;
        }
    }
}
