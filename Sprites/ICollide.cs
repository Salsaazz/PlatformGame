﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame
{
    internal interface ICollide<T>
    {
        void Collide(T obj);
    }
}