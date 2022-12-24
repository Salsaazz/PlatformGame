using Microsoft.Xna.Framework;
using PlatformGame.Characters;
using PlatformGame.Enemies;
using PlatformGame.Interfaces;
using PlatformGame.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Collision
{
    abstract class Collision : ICollide
    {
        public void Collide(Player player, Enemy enemy)
        {
            Movement(player, enemy);
        }
        public abstract void Movement(Player player, Enemy enemy);
    }
}
