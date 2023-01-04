using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Interfaces
{
    internal interface IFollowPlayer
    {
        void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch, Player player);
    }
}
