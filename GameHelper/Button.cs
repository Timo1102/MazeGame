using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace GameHelper
{
    /// <summary>
    /// 2D button class
    /// </summary>
   public class Button : GameObject
    {
       
       /// <summary>
       /// Set a render and change the draworder
       /// </summary>
       /// <param name="game"></param>
       /// <param name="name"></param>
        public Button(myGame game, string name)
            : base(game, game.mainCamera)
        {
            renderer = new Render2D(this, name, Render2D.Origin.TopLeft );
            renderer.DrawOrder = 7;
        }
        


    }
}
