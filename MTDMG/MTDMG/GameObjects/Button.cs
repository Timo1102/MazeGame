using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameHelper;

namespace MTDMG.GameObjects
{
    class Button : GameObject
    {
        public Button(MazeGame game)
            : base(game, game.mainCamera)
        {
            renderer = new Render2D(this, "Textures/test");
        }




    }
}
