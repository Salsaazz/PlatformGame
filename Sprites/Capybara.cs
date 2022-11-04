using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprites.Player;

namespace Sprites
{
    internal class Capybara: IGameObject
    {
        Animation walkAnimation;
        Texture2D _walkTexture;
        Rectangle walkRectangle;
        Vector2 positie;
        Vector2 positie2;
        int marge = 70;
        public Capybara(Texture2D texture)
        {
            this._walkTexture = texture;
            walkAnimation = new Animation();
            //normale width = 513 maar -1 want er is een zwarte streep
            walkRectangle = new Rectangle(0, 0, 64, 49);
            walkAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 1);
            positie = new Vector2(10, 500);
            positie2.X = Player.positie.X - marge;
            positie2.Y = Player.positie.Y+5;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_walkTexture, this.positie2, walkAnimation.CurrentFrame.SourceRectangle, Color.White);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D objTexture)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime, int windowWidth, int widowHeight)
        {

            this.positie.X+=1;
            this.positie2.X = Player.positie.X - marge;
            //this.positie.Y+=2;
            walkAnimation.Update(gameTime);
        }
    }
}
