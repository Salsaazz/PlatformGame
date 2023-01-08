using Microsoft.Xna.Framework;
using PlatformGame.Blocks.Enemies;
using PlatformGame.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Interfaces
{
    internal interface IMovingBehavior
    {

        public void Move(Player player, Enemy enemy);
    }
}
