﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprites
{
     class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> frames;
        public int counter;
        private double secondCounter = 0;

        public Animation()
        {
            frames = new List<AnimationFrame>();
        }
        public void AddFrame(AnimationFrame frame)
        {
            frames.Add(frame);
            CurrentFrame = frames[0];
        }


        public void Update(GameTime gametime)
        {
            CurrentFrame = frames[counter];

            secondCounter += gametime.ElapsedGameTime.TotalSeconds;
            int fps = 1;
            //animatie met de snelheid aanpassen
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
                    frames.Add(new AnimationFrame(new Rectangle(x, y, widthOfFrame, heightOfFrame)));
                }
            }
        }


    }
}
