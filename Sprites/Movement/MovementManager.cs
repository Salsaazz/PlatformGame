using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using PlatformGame.Blocks;
using PlatformGame.Characters;
using PlatformGame.Collision;
using PlatformGame.Interfaces;
using PlatformGame.Terrain;
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
        public bool IsLeft { get; set; } = false;
        public bool standStill = true;
        public bool jump { get; set; } = false;
        public bool IsFalling { get; set; } = true;
        private int jumpHeight = 0;
        public bool OnGround { get; set; } = false;
        public bool pressUp { get; set; } = false;
        public bool pressDown { get; set; } = false;
        public float XCoordinate { get; set; } = 0;
        public Rectangle futureRect { get; set; }
        CollisionManager collision = new CollisionManager();
        public Vector2 futurePosition { get; set; }
        public IMovable Movable { get; set; }
        public void Move(IMovable movable, List<Block> blockList, Player player)
        {
            this.Movable = movable;
            movable.Speed = new Vector2(movable.InputReader.ReadInput().X, 0);
            XCoordinate = movable.InputReader.ReadInput().X;
            float yAxis = movable.InputReader.ReadInput().Y;
            if (yAxis > 0 && !IsFalling && !jump)
            {
                pressUp = true;
                pressDown = false;
            }
            else if(yAxis < 0) { pressDown = true; }

            if (movable.Speed.X < 0)
            {
                IsLeft = true;
                standStill = false;
            }
            else if (movable.Speed.X > 0)
            {
                IsLeft = false;
                standStill = false;
            }
            else standStill = true;
            if (movable.InputReader.IsDestinationInput)
            {
                movable.Speed -= movable.Position;
                movable.Speed.Normalize();
            }

            if (pressUp && !jump && OnGround)
            {
                jumpHeight = (int)movable.Position.Y - 32 * 2 -5;
                IsFalling = false;
                jump = true;
                OnGround = false;

            }

            if (jump && !IsFalling)
            {
                float i = 20f;
                movable.Speed -= new Vector2(0, 0.15f * i);
                OnGround = false;

            }
            if (movable.Position.Y <= jumpHeight && jump && !IsFalling)
            {
                IsFalling = true;
                jump = false;
                OnGround = false;
            }
            if (IsFalling && !jump)
            {
                float i = 10f;
                movable.Speed += new Vector2(0, 0.15f * i);
                OnGround = false;
            }

            futurePosition = movable.Position + movable.Speed;

            futureRect = new Rectangle((int)futurePosition.X, (int)futurePosition.Y, 32, 32);

            var hasCollided = collision.CollisionDetection(futureRect, blockList);
            collision.Collide(hasCollided,this, movable, player);
            movable.Position = futurePosition;
        }
    }
}
