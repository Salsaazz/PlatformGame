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
        public bool isLeft { get; set; } = false;
        public bool standStill = true;
        public bool jump { get; set; } = false;
        public bool isFalling { get; set; } = true;
        private int jumpHeight = 0;
        public bool onGround { get; set; } = false;
        public bool pressY { get; set; } = false;
        public float XCoordinate { get; set; } = 0;
        public Rectangle futureRect;
        CollisionManager collision = new CollisionManager();
        public Vector2 futurePosition { get; set; }
        public IMovable Movable { get; set; }
        public void Move(IMovable movable, List<Tile> blockList)
        {
            Movable = movable;
            movable.Speed = new Vector2(movable.InputReader.ReadInput().X, 0);
            XCoordinate = movable.InputReader.ReadInput().X;
            float yAxis = movable.InputReader.ReadInput().Y;
            Debug.Write(movable.Speed.X);
            if (yAxis > 0 && !isFalling && !jump)
            {
                //om de zoveel seconde veranderd de input
                // gaat direct van 2 --> 0
                //dus zal er een error ontstaan als je wilt jumpen met collion detection
                //eens willen jumpen(yAxis) --> variabele blijft op 2 tot die weer valt
                //hiermee coll detection doen via een bool (pressY)
                pressY = true;
            }

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

            if (pressY && !jump && onGround)
            {
                jumpHeight = (int)movable.Position.Y - 57 * 2;
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
            if (isFalling && !jump)
            {
                float i = 10f;
                movable.Speed += new Vector2(0, 0.15f * i);
                onGround = false;
            }

            futurePosition = movable.Position + movable.Speed;

            futureRect = new Rectangle((int)futurePosition.X, (int)futurePosition.Y, 50, 54);

            var hasCollided = collision.CollisionDetection(futureRect, blockList);
            collision.Collide(hasCollided,this, movable);
            movable.Position = futurePosition;
        }

    }
}
