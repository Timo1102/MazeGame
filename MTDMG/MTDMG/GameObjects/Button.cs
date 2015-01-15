using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameHelper;
using Microsoft.Xna.Framework;

namespace MTDMG.GameObjects
{
    class Button : GameObject
    {
        public Button(MazeGame game)
            : base(game, game.mainCamera)
        {
            renderer = new Render2D(this, "Textures/test");
           // this.transform.Scale = new Vector3(0.5f, 0.5f, 0.5f);
        }




    }
}
