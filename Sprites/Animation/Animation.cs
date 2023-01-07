using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlatformGame
{
    class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> frames;
        public int counter;
        private double secondCounter;
        private double framesPerSec;
        public Animation(double framesPerSec)
        {
            counter = 0;
            secondCounter = 0;
            frames = new List<AnimationFrame>();
            this.framesPerSec = framesPerSec;
            
        }

        public void Update(GameTime gameTime)
        {
            CurrentFrame = frames[counter];
            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
            int fps = 1;
            //animatie met de Velocity aanpassen
            //per 0.3dsec 1frame
            if (secondCounter >= framesPerSec/ fps)
            {
                counter++;;
                secondCounter = 0;
            }

            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }

        public void GetFramesFromTextureProperties(int width, int height, int numberOfWidthSprites, int numberOfHeightSprites)
        {
            int widthOfFrame = width / numberOfWidthSprites;
            int heightOfFrame = height / numberOfHeightSprites;

            for (int y = 0; y <= height - heightOfFrame; y += heightOfFrame)
            {
                for (int x = 0; x <= width - widthOfFrame; x += widthOfFrame)
                {
                    //x schuiven we op om naar de volgende frame te gaan
                    //van de spritesheet
                    frames.Add(new AnimationFrame(new Rectangle(x, y, widthOfFrame, heightOfFrame)));
                }
            }
        }


    }
}
