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
        private bool onGround = false;
        public void Move(IMovable movable, List<Block> blockList)
        {
            movable.Speed = new Vector2(movable.InputReader.ReadInput().X, 0);
            //movable.Speed = movable.InputReader.ReadInput();
            float yAxis = movable.InputReader.ReadInput().Y;
            //Debug.WriteLine("Falling " + isFalling);
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

            if ((int)yAxis > 0 && !jump && onGround )
            {
                jumpHeight = (int)movable.Position.Y - 120;
                isFalling = false;
                jump = true;
                //onGround = false;
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
            if (isFalling && !jump)
            {
                float i = 8f;
                movable.Speed += new Vector2(0, 0.15f * i);
                onGround = false;
            }

            var afstand = movable.Speed;
            var toekomstigePositie = movable.Position + afstand;
            Rectangle toekomstigeRect = new Rectangle((int)toekomstigePositie.X, (int)toekomstigePositie.Y, 50, 54);
            //isFalling = true;

            if (Collide(toekomstigeRect, blockList))
            {
                //als het jumpt en collide --> topcollide
                //isfalling = true --> bottomcollide snehlheid=0
                //drukt op links of rechts --> snelheid(0,Y)

                //geef input
                //input => richting of valrichting
                //bereken toekomstige plaats adhv input
                //check of tp botst
                //nee positie = toekomst
                if (movable.Speed.X > 0 || movable.Speed.X < 0)
                {
                    movable.Speed = new Vector2(0, movable.Speed.Y);
                }
                if (isFalling)
                {
                    jump = false;
                    isFalling = false;
                    movable.Speed = new Vector2(movable.Speed.X, 0);
                    onGround = true;
                }

                if (yAxis > 0)
                {
                    movable.Speed = new Vector2(movable.Speed.X, 0);
                    isFalling = true;
                    jump = false;

                }
                /*if (jump)
                {
                    jump = false;
                    movable.Speed = new Vector2(movable.Speed.X, 0);
                    isFalling = true;
                }*/
                //ja richting = 0;

                toekomstigePositie = movable.Position + movable.Speed;

            }
            else if (!(Collide(toekomstigeRect, blockList) &&!onGround) 
                && !isFalling 
                && !jump) 
            { 
                isFalling = true; 
                jump = false; }
            movable.Position = toekomstigePositie;
            Debug.WriteLine("Falling " + isFalling);

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
