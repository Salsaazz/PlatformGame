using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Interfaces;
using SharpDX.Direct3D9;
using Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PlatformGame.Characters.Player;

namespace PlatformGame.Characters
{
    internal class Capybara : IGameObject
    {
        Animation walkAnimation;
        Texture2D _walkTexture;
        Rectangle walkRectangle;
        Vector2 positie;
        int marge = 70;
        public Capybara(Texture2D texture)
        {
            _walkTexture = texture;
            walkAnimation = new Animation();
            //normale width = 513 maar -1 want er is een zwarte streep
            walkRectangle = new Rectangle(0, 0, 64, 49);
            walkAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 1);
            positie = new Vector2(10, 500);
        }

        public Rectangle HitBox { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector2 Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector2 Speed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Draw(SpriteBatch spriteBatch, Player player)
        {

            if (player.isLeft)
                spriteBatch.Draw(_walkTexture, new Vector2(player.Position.X - marge, player.Position.Y + 5), walkAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.FlipHorizontally, 0f);

            else
                spriteBatch.Draw(_walkTexture, new Vector2(player.Position.X - marge, player.Position.Y + 5), walkAnimation.CurrentFrame.SourceRectangle, Color.White);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime, int windowWidth, int widowHeight)
        {

            positie.X += 1;
            //this.positieWMarge.X = Player.Position2.X - marge;
            //this.Position2.Y+=2;
            walkAnimation.Update(gameTime);
        }
    }
}
