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
using System.Windows.Forms;

namespace PlatformGame.Collision
{
    internal class FollowingEnemyCollision : Collision
    {
        public override void Movement(Player player, Enemy enemy)
        {
            if (player.HitBox.RectangleBlock.Intersects(enemy.HitBox.RectangleBlock))
            {
                if (player.gameTimer.Counter >= 1000)
                {
                    player.Health--;
                    player.gameTimer.Counter = 0;
                }
            }
        }
    }
}
