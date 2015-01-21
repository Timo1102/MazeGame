using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace GameHelper
{
   public class Button : GameObject
    {
       

        public Button(myGame game, string name)
            : base(game, game.mainCamera)
        {
            renderer = new Render2D(this, name);
            renderer.DrawOrder = 7;
        }
        


    }
}
