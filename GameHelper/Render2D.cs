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
        public Render2D(GameObject gameobj, string name) : base(gameobj, name)
        {
            this.DrawOrder = 5;
            tx = gameobj.game.Content.Load<Texture2D>(name);
            TitleSafe = GetTitleSafeArea(.8f);
            colorRGB = Color.White;
             origin = new Vector2(gameObj.transform.Position.X + (tx.Width / 2), gameObj.transform.Position.Y + (tx.Height / 2));
         }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            
            gameObj.game.spriteBatch.Begin();
            Vector2 pos = new Vector2(gameObj.transform.Position.X, gameObj.transform.Position.Y);
            
            gameObj.game.spriteBatch.Draw(tx, pos, TitleSafe, colorRGB, gameObj.transform.Rotation.Z, origin, new Vector2(gameObj.transform.Scale.X, gameObj.transform.Scale.Y), SpriteEffects.None, 0f);
            gameObj.game.spriteBatch.End();
            GraphicsDevice.DepthStencilState = new DepthStencilState() { DepthBufferEnable = true };
            base.Draw(gameTime);
        }


        protected Rectangle GetTitleSafeArea(float percent)
        {
            Rectangle retval = new Rectangle(
               gameObj.game.graphics.GraphicsDevice.Viewport.X,
                 gameObj.game.GraphicsDevice.Viewport.Y,
                 gameObj.game.GraphicsDevice.Viewport.Width,
                 gameObj.game.GraphicsDevice.Viewport.Height);


            Rectangle retval2 = new Rectangle(
                (int)gameObj.transform.Position.X,
                (int)gameObj.transform.Position.Y,
                tx.Width,
                tx.Height);

            return retval2;
        }

    }
}
