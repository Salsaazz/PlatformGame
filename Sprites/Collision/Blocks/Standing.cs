using PlatformGame.Characters;
using PlatformGame.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Collision.Blocks
{
    internal class Standing : MovingBehavior
    {
        DamageBehavior damageBehavior = new OnlyDamage();
        public override void Collide(Player player, Enemy enemy)
        {
            damageBehavior.Damage(player, enemy);
        }
    }
}
