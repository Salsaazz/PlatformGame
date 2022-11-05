﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame
{
    internal interface IGameComponent
    {
        void Update(GameTime gameTime, int windowWidth, int widowHeight);
        void Draw(SpriteBatch spriteBatch);
    }
}