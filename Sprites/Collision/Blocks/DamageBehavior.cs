using PlatformGame.Characters;
using PlatformGame.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Collision.Blocks
{
     abstract class DamageBehavior
    {
        public abstract void Damage(Player player, Enemy enemy);
    }
}
