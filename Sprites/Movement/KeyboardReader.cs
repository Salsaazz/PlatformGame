using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PlatformGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Movement
{
    internal class KeyboardReader : IInputReader
    {
        public bool IsDestinationInput => false;
        public bool pressEnter { get; set; } = false;
        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            if (state.IsKeyDown(Keys.Left) ||
                state.IsKeyDown(Keys.A) ||
                state.IsKeyDown(Keys.Q))
            {
                direction.X -= 4;
                
            }
            if (state.IsKeyDown(Keys.Right) ||
                state.IsKeyDown(Keys.D))
            {
                direction.X += 4;
            }

            if (state.IsKeyDown(Keys.Up) ||
                state.IsKeyDown(Keys.W) ||
                 state.IsKeyDown(Keys.Z))
            {
                direction.Y += 2;
            }
            if (state.IsKeyDown(Keys.Down) ||
                 state.IsKeyDown(Keys.S))
            {
                direction.Y += -2;
            }
            if (state.IsKeyDown(Keys.Enter))
            {
                pressEnter = true;
            }
            else pressEnter = false;
            return direction;
        }



    }
}

