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
       Vector2 myOrigin;
       Texture2D tx;
       private Rectangle TitleSafe;
       Rectangle retval2;
       Vector2 pos;
       Texture2D px;
       Texture2D btn;

       public Rectangle Offset;

       public enum Origin
       {
           TopLeft,
           TopRight,
           BottomLeft,
           BottomRight,
           TopCenter,
           BottomCenter,
           Center
       }
       Origin origin;

       public Origin SetOrigin
       {
           get
           {
               return origin;
           }
           set
           {
               origin = value;
               myOrigin = GetOrigin(origin);
           }
       }

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

       

        public Render2D(GameObject gameobj, string name, Origin or) : base(gameobj, name)
        {
            this.DrawOrder = 5;
            origin = or;
            tx = gameobj.game.Content.Load<Texture2D>(name);
            px = gameobj.game.Content.Load<Texture2D>("Textures/pixel");
            myOrigin = GetOrigin(or);
            colorRGB = Color.White;

                Offset = new Rectangle(0, 0, 0, 0);
            
             
         }
        public Vector2 GetOrigin(Origin or)
        {
            pos = new Vector2(gameObj.transform.Position.X, gameObj.transform.Position.Y);
            
            switch (or)
            {
                case Origin.TopLeft:
                    myOrigin = new Vector2(0, 0);
                    break;
                case Origin.TopRight:
                    myOrigin = new Vector2(tx.Width,0);
                    break;
                case Origin.Center:
                    myOrigin = new Vector2(tx.Width / 2,tx.Height / 2);
                    break;
                case Origin.BottomLeft:
                    myOrigin = new Vector2(0, tx.Height);
                    break;
                case Origin.BottomRight:
                    myOrigin = new Vector2(tx.Width, tx.Height);
                    break;
                default :
                    myOrigin = pos;
                    break;
            }

            return myOrigin;
        }


        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {

            
            gameObj.game.spriteBatch.Begin();


            pos = new Vector2(gameObj.transform.Position.X, gameObj.transform.Position.Y);

            if (gameObj.isActive)
            {



                gameObj.game.spriteBatch.Draw(tx, pos, null, colorRGB, gameObj.transform.Rotation.Z, GetOrigin(origin), new Vector2(gameObj.transform.Scale.X, gameObj.transform.Scale.Y), SpriteEffects.None, 0f);

                if (gameObj.CanClick)
                {
                    gameObj.game.spriteBatch.Draw(px, new Rectangle(myRec.X - 1, myRec.Y - 1, px.Width, px.Height), Color.Red);
                    gameObj.game.spriteBatch.Draw(px, new Rectangle(myRec.X + myRec.Width + 1, myRec.Y + 1, px.Width, px.Height), Color.Red);
                    gameObj.game.spriteBatch.Draw(px, new Rectangle(myRec.X + 1, myRec.Y + myRec.Height + 1, px.Width, px.Height), Color.Red);
                    gameObj.game.spriteBatch.Draw(px, new Rectangle(myRec.X + myRec.Width + 1, myRec.Y + myRec.Height + 1, px.Width, px.Height), Color.Red);
                }
            }


    
            gameObj.game.spriteBatch.End();
            GraphicsDevice.DepthStencilState = new DepthStencilState() { DepthBufferEnable = true };
            base.Draw(gameTime);
        }


        protected Rectangle GetTitleSafeArea(float percent)
        {



             retval2 = new Rectangle(
                (int)(gameObj.transform.Position.X - GetOrigin(origin).X + Offset.X),
                (int)(gameObj.transform.Position.Y - GetOrigin(origin).Y + Offset.Y),
                (int)(tx.Width * gameObj.transform.Scale.X + Offset.Width),
               (int)(tx.Height * gameObj.transform.Scale.Y + Offset.Height));

            return retval2;
        }

    }
}
