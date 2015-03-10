using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GameHelper
{
    /// <summary>
    /// Gameobject component class
    /// </summary>
    public class ObjectComponent : DrawableGameComponent
    {
      public  GameObject gameObj;

        
        public ObjectComponent(GameObject gameObj) : base(gameObj.game)
        {
            this.gameObj = gameObj;
        }
    }
}
