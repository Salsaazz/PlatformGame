using Microsoft.Xna.Framework;
using PlatformGame.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Collide
{
    class CollideManager
    {
        public bool hasCollided(Rectangle hitbox, List<Block> list)
        {
                foreach (var block in list)
                {
                    if (hitbox.Intersects(block.rectangle))
                    {
                        return true;
                    }
                }
                return false;          
        }
        
    }
}
