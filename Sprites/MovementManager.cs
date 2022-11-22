using Microsoft.Xna.Framework;
using PlatformGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame
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
                direction -= movable.Position2;
            }

            var afstand = direction * movable.Speed2;
            var toekomstigePositie = movable.Position2 + afstand;
            movable.Position2 = toekomstigePositie;
            movable.Position2 += afstand;

            movable.Position2 += movable.Speed2;
            if (direction.Y < 0 && jump == false)
            {
                currentHeight = movable.Position2.Y;
                movable.Position2 -= new Vector2(0, -10f);
                movable.Speed2 -= new Vector2(0, -5f);
                jump = true;
            }

            if (jump == true)
            {
                float gravity = 1;
                movable.Speed2 += new Vector2(0, 0.15f * gravity);
            }

            if (movable.Position2.Y >= currentHeight)
                movable.Speed2 = Vector2.Zero;

        }
    }
}
