using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using PlatformGame.Interfaces;
using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Movement
{
    internal class MovementManager
    {
        public float currentHeight;
        public bool isLeft = false;
        public bool standStill = true;
        public bool jump = false;
        public bool isFalling = false;
        public void Move(IMovable movable)
        {
            //var direction = movable.InputReader.ReadInput();
            movable.Speed = new Vector2(movable.InputReader.ReadInput().X, 0);
            float yAxis = movable.InputReader.ReadInput().Y;
            if (movable.Speed.X < 0)
            {
                isLeft = true;
                standStill = false;
            }
            else if (movable.Speed.X > 0)
            {
                isLeft = false;
                standStill = false;
            }
            else standStill = true;
            if (movable.InputReader.IsDestinationInput)
            {
                movable.Speed -= movable.Position;
                movable.Speed.Normalize();
            }

            if ((int)yAxis> 0 && jump == false && !isFalling)
            {
                currentHeight = movable.Position.Y;
                movable.Position -= new Vector2(0, 120f);
                movable.Speed += new Vector2(0, -10f);
                jump = true;
                isFalling = true;
            }

            if (jump && isFalling)
            {
                float i = 8f;
                movable.Speed += new Vector2(0, 0.15f * i);
            }

            if (movable.Position.Y >= currentHeight)
            {
                jump = false;

            }
            if (!jump)
            {
                movable.Speed = new Vector2(movable.Speed.X, 0);
                isFalling = false;
            }

            var afstand =  movable.Speed;
            var toekomstigePositie = movable.Position + afstand;
            movable.Position = toekomstigePositie;
            //movable.Position += movable.Speed;
            Debug.WriteLine(jump);


        }
    }
}
