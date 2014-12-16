using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GameHelper
{
    public class ObjectComponent
    {
      public  GameObject gameObj;

        
        public ObjectComponent(GameObject gameObj)
        {
            this.gameObj = gameObj;
        }
    }
}
