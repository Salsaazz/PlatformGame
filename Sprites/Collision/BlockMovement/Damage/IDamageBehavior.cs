using PlatformGame.Characters;
using PlatformGame.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Collision.Blocks.Damage
{
    internal interface IDamageBehavior
    {
        public void Damage(Player player, Enemy enemy);

    }
}
