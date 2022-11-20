using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Interfaces
{
    internal interface IMovable
    {
        public Vector2 Position2 { get; set; }
        public Vector2 Speed2 { get; set; }
        public IInputReader InputReader { get; set; }
    }
}
