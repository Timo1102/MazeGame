using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameHelper;
using Microsoft.Xna.Framework;

namespace MTDMG.GameObjects
{
    class Tower : GameObject
    {
        public Tower(MyGame game)
            : base(game, game.mainCamera)
        {
            renderer = new Render3D(this, "Model/Tower");
            transform.Scale = new Vector3(0.3f, 0.6f, 0.3f);
        }

    }
}
