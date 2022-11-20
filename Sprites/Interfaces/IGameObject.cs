using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame
{
    internal interface IGameObject
    {
        void Update(GameTime gameTime, int windowWidth, int widowHeight);
        void Draw(SpriteBatch spriteBatch);
        Rectangle HitBox { get; set; }
        Vector2 Position2 { get; set; }
        Vector2 Speed2 { get; set; }

    }
}
