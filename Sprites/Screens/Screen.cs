using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Terrain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Screens
{
    internal abstract class Screen
    {
        SpriteFont font;
        public Screen(SpriteFont font)
        {
            this.font = font;
        }
        public abstract void Draw(SpriteBatch spriteBatch, SpriteFont font);

        public abstract void Update(GameTime gameTime);
    }
}
