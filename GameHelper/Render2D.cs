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
       Texture2D tx;
       private Rectangle TitleSafe;
        public Render2D(GameObject gameobj, string name) : base(gameobj, name)
        {
            this.DrawOrder = 5;
            tx = gameobj.game.Content.Load<Texture2D>(name);
            TitleSafe = GetTitleSafeArea(.8f);
         }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            
            gameObj.game.spriteBatch.Begin();
            Vector2 pos = new Vector2(TitleSafe.Left, TitleSafe.Top);
            gameObj.game.spriteBatch.Draw(tx, pos, Color.White);
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

            return retval;
        }

    }
}
