using Microsoft.Xna.Framework;
using PlatformGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Movement
{
    internal class MovementManager
    {
        public bool jump = false;
        public float currentHeight;

        public void Move(IMovable movable)
        {
            var direction = movable.InputReader.ReadInput();
            if (movable.InputReader.IsDestinationInput)
            {
                direction -= movable.Position;
            }

            var afstand = direction * movable.Speed;
            var toekomstigePositie = movable.Position + afstand;
            movable.Position = toekomstigePositie;
            movable.Position += afstand;

            movable.Position += movable.Speed;
            if (direction.Y < 0 && jump == false)
            {
                currentHeight = movable.Position.Y;
                movable.Position -= new Vector2(0, -10f);
                movable.Speed -= new Vector2(0, -5f);
                jump = true;
            }

            if (jump == true)
            {
                float gravity = 1;
                movable.Speed += new Vector2(0, 0.15f * gravity);
            }

            if (movable.Position.Y >= currentHeight)
                movable.Speed = Vector2.Zero;

        }
    }
}
