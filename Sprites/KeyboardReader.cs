using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PlatformGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame
{
    internal class KeyboardReader : IInputReader
    {
        public bool IsDestinationInput => false;

        public Vector2 ReadInput()
        {
            KeyboardState keyState = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            if (keyState.IsKeyDown(Keys.Left)) { direction.X = -2; }
            if (keyState.IsKeyDown(Keys.Right))
            {
                direction.X = 2;}
            return direction;

        }



    }
}

