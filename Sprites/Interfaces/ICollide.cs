using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Interfaces
{
    internal interface ICollide<T>
    {
        bool Collide(T obj);
    }
}
