using Microsoft.Xna.Framework;
using System.Collections.Generic;
namespace PlatformGame.Interfaces
{
    internal interface ICollide<T>
    {
        bool Collide(Rectangle hitbox, List<T> list);
    }
}
