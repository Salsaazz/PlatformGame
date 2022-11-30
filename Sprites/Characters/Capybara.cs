using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.Characters;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame
{
    internal class Capybara : IGameObject
    {
        Animation walkAnimation;
        Texture2D _walkTexture;
        Rectangle walkRectangle;
        Vector2 positie;
        int marge = 70;
        Player followObject{ get; set; }
        public Capybara(Texture2D texture)
        {
            this._walkTexture = texture;
            walkAnimation = new Animation();
            //normale width = 513 maar -1 want er is een zwarte streep
            walkRectangle = new Rectangle(0, 0, 64, 49);
            walkAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 1);
            positie = new Vector2(10, 500);
            /*positieWMarge.X = player.Position.X - marge;
            positieWMarge.Y = Player.Position.Y+5;*/
        }

        public Rectangle HitBox { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector2 Position2 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector2 Speed2 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Draw(SpriteBatch spriteBatch, Player followObject)
        {

            if (followObject.movementManager.isLeft)
                spriteBatch.Draw(_walkTexture, new Vector2(followObject.Position.X - marge, followObject.Position.Y), walkAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.FlipHorizontally, 0f);

            else
                spriteBatch.Draw(_walkTexture, new Vector2(followObject.Position.X - marge, followObject.Position.Y), walkAnimation.CurrentFrame.SourceRectangle, Color.White);
        }


        public void Draw(SpriteBatch spritebatch) { throw new NotImplementedException(); }
        public void Update(GameTime gameTime, int windowWidth, int widowHeight)
        {

            this.positie.X += 1;
            walkAnimation.Update(gameTime);
        }
    }
}