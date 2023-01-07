﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame
{
     class AnimationFrame
    {
            public Rectangle SourceRectangle { get; set; }

            public AnimationFrame(Rectangle sourceRectangle)
            {
                SourceRectangle = sourceRectangle;
            }

        }

}