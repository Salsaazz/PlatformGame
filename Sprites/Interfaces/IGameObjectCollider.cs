using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Blocks;
using PlatformGame.Terrain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.Interfaces
{
    internal interface IGameObjectCollider
    {
        void Update(GameTime gameTime, List<Blok> list);
        void Draw(SpriteBatch spriteBatch);
        Block HitBox { get; set; }
    }
}
