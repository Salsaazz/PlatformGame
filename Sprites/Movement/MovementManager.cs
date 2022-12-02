using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using PlatformGame.Characters;
using PlatformGame.Interfaces;
using SharpDX.Direct3D9;
using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
        public bool isFalling = true;
        private int jumpHeight = 0;

        public void Move(IMovable movable, List<Block> blockList)
        {
            movable.Speed = new Vector2(movable.InputReader.ReadInput().X, 0);
            float yAxis = movable.InputReader.ReadInput().Y;
            Debug.WriteLine("X: " + movable.Speed.X+"Y: " +yAxis);
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
                jumpHeight = (int)movable.Position.Y - 120;
                isFalling = false;
                jump = true;
            }

            if (jump && !isFalling)
            {
                float i = 20f;
                movable.Speed -= new Vector2(0, 0.15f * i);
            }
            if (movable.Position.Y <= jumpHeight && jump && !isFalling)
            {
                isFalling = true;
                jump = false;
            }
            //if (jump && isFalling)
            if (isFalling || isFalling && !jump)
            {
                float i = 8f;
                movable.Speed += new Vector2(0, 0.15f * i);
                //jump = false;
            }


            var afstand = movable.Speed;
            var toekomstigePositie = movable.Position + afstand;
            Rectangle toekomstigeRect = new Rectangle((int)toekomstigePositie.X, (int)toekomstigePositie.Y, 50, 54);

            if (Collide(toekomstigeRect, blockList))
            {


                //geef input
                //input => richting of valrichting
                //bereken toekomstige plaats adhv input
                //check of tp botst
                //nee positie = toekomst
                if (isFalling)
                {
                    isFalling = false;
                    movable.Speed = new Vector2(movable.Speed.X, 0);
                }
                //ja richting = 0;
                if (movable.Speed.X > 0 || movable.Speed.X < 0)
                {
                    movable.Speed = new Vector2(0, movable.Speed.Y);
                }

                if (yAxis > 0 && !jump)
                {
                    //movable.Speed = new Vector2(movable.Speed.X, 0);
                    isFalling = true;
                    jump = false;

                }
                if (jump)
                {
                    jump = false;
                    isFalling = true;
                }
                toekomstigePositie = movable.Position + movable.Speed;

            }
            else if(!jump)isFalling = true;
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
