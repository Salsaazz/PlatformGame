using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame;
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
        //public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> frames;
        //static maken zodat je dit kan meegeven voor de hitboxes list
        public int counter=0;
        private double secondCounter = 0;
        public List<Block> blocks = new List<Block>();
        public Animation()
        {
            frames = new List<AnimationFrame>();
        }

        public void Update(GameTime gameTime)
        {
            CurrentFrame = frames[counter];
            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
            int fps = 1;
            //animatie met de Speed aanpassen
            //per 0.3sec 1frame
            if (secondCounter >= 0.3d/ fps)
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
