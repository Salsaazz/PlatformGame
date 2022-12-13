using Microsoft.Xna.Framework;
using PlatformGame.Blocks;
using PlatformGame.Characters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.DamageEvent
{
    class Damage : CollideEvent
    {
        private float teller = 0;
        public int DamagePerSec { get; set; } = 1;
        public Damage(int damage) 
        {
            DamagePerSec = damage;
        }
        public void Execute(GameTime gameTime, Player player) {

            if (teller >= 1000)
            {
                player.Health -= DamagePerSec;
                teller = 0;
            }
            teller += teller<1000?(float)gameTime.ElapsedGameTime.TotalMilliseconds:1000;
            
        }

    }
}
