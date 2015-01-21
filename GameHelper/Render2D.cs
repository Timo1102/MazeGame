using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GameHelper
{
   public class Render2D : Render
    {
       Vector2 origin;
       Texture2D tx;
       private Rectangle TitleSafe;
       Rectangle retval2;
       Vector2 pos;
       Texture2D px;
       Texture2D btn;

       public Texture2D Texture
       {
           get
           {
               return tx;
           }
           private set
           { }
       }

       public Rectangle myRec
       {
           get
           {
               return GetTitleSafeArea(0.8f);
           }
           private set
           { }
       }

       

        public Render2D(GameObject gameobj, string name) : base(gameobj, name)
        {
            this.DrawOrder = 5;
            tx = gameobj.game.Content.Load<Texture2D>(name);

            colorRGB = Color.White;
             
         }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {

            
            gameObj.game.spriteBatch.Begin();
             pos = new Vector2(gameObj.transform.Position.X, gameObj.transform.Position.Y);
            origin = new Vector2(gameObj.transform.Position.X + (tx.Width / 2), gameObj.transform.Position.Y + (tx.Height / 2));
           

            if (gameObj.isActive)
            {

                gameObj.game.spriteBatch.Draw(tx, pos, null, colorRGB, gameObj.transform.Rotation.Z, Vector2.Zero, new Vector2(gameObj.transform.Scale.X, gameObj.transform.Scale.Y), SpriteEffects.None, 0f);
           
            }
            
            //gameObj.game.spriteBatch.Draw(px, new Rectangle(myRec.X - 1, myRec.Y - 1, px.Width, px.Height), Color.White);
            //gameObj.game.spriteBatch.Draw(px, new Rectangle(myRec.X + myRec.Width + 1, myRec.Y + 1, px.Width, px.Height), Color.White);
            //gameObj.game.spriteBatch.Draw(px, new Rectangle(myRec.X + 1, myRec.Y + myRec.Height + 1, px.Width, px.Height), Color.White);
            //gameObj.game.spriteBatch.Draw(px, new Rectangle(myRec.X + myRec.Width + 1, myRec.Y + myRec.Height + 1, px.Width, px.Height), Color.White);
            //gameObj.game.spriteBatch.Draw(btn, new Rectangle(myRec.X, myRec.Y, myRec.Width, myRec.Height), Color.White);
            gameObj.game.spriteBatch.End();
            GraphicsDevice.DepthStencilState = new DepthStencilState() { DepthBufferEnable = true };
            base.Draw(gameTime);
        }


        protected Rectangle GetTitleSafeArea(float percent)
        {
   
             retval2 = new Rectangle(
                (int)gameObj.transform.Position.X,
                (int)gameObj.transform.Position.Y,
                (int)(tx.Width * gameObj.transform.Scale.X),
               (int)(tx.Height * gameObj.transform.Scale.Y));

            return retval2;
        }

    }
}
