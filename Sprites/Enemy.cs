using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame
{
    internal class Enemy : IGameObject
    {
        public Rectangle HitBox { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Speed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Enemy() { }
        public Enemy(Vector2 position, Vector2 speed, Rectangle hitBox) {
            this.HitBox = hitBox;
            this.Position = position;
            this.Speed = speed;
                
          }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime, int windowWidth, int widowHeight)
        {
            throw new NotImplementedException();
        }
    }
}
