using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PlatformGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Movement
{
    internal class KeyboardReader : IInputReader
    {
        public bool IsDestinationInput => false;
        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.Q))
            {
                direction.X -= 1;
            }
            if (state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D))
            {
                direction.X += 1;
            }
            if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.LeftShift) ||
                state.IsKeyDown(Keys.Q) && state.IsKeyDown(Keys.LeftShift))
            {
                direction.X -= 1;
            }
            if (state.IsKeyDown(Keys.Right) && state.IsKeyDown(Keys.LeftShift) ||
                state.IsKeyDown(Keys.D) && state.IsKeyDown(Keys.LeftShift))
            {
                direction.X += 1;
            }
            if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.Space))
            {
                direction.Y -= 1;
            }

            return direction;
        }



    }
}

