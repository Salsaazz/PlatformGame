using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using PlatformGame.Characters;
using PlatformGame.Interfaces;
using SharpDX.Direct3D9;
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


        public void Move(IMovable movable, List<Block> blockList)
        {
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

            if ((int)yAxis > 0 && !jump && !isFalling)
            {
                currentHeight = movable.Position.Y; ;
                jump = true;
            }

            if (jump && !isFalling)
            {
                float i = 8f;
                movable.Speed -= new Vector2(0, 0.15f * i);
            }
            if (movable.Position.Y <= currentHeight - 100 && jump && !isFalling)
            {
                isFalling = true;
            }
            if (jump && isFalling)
            {
                float i = 8f;
                movable.Speed += new Vector2(0, 0.15f * i);
            }

            if (movable.Position.Y >= currentHeight && jump && isFalling)
            {
                jump = false;
                movable.Speed = new Vector2(movable.Speed.X, 0);
                isFalling = false;

            }

            //if (hasCollided)
            //{
            //    movable.Speed = Vector2.Zero;
            //}
            var afstand = movable.Speed;
            var toekomstigePositie = movable.Position + afstand;
            Rectangle toekomstigeRect = new Rectangle((int)toekomstigePositie.X, (int)toekomstigePositie.Y, 50, 54);

            if (Collide(toekomstigeRect, blockList))
            {
                movable.Speed = Vector2.Zero;
                toekomstigePositie = movable.Position + movable.Speed;
            }
            movable.Position = toekomstigePositie;


        }
        void Jumping()
        {
        }
        bool Collide(Rectangle rectangle, List<Block> blockList)
        {
            foreach (var block in blockList)
            {
                if (rectangle.Intersects(block.rectangle))
                {
                    return true;
                }
            }
            return false;

        }
    }
}
