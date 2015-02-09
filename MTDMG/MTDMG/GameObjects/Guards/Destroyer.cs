using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameHelper;
using Microsoft.Xna.Framework;


namespace MTDMG.GameObjects.Guards
{
    class Destroyer : Guard
    {
        public Destroyer(MazeGame game, PlayerControler player)
            : base(game, player)
        {
            renderer = new Render3D(this, "Model/Guard");
            transform.Scale = new Vector3(0.4f, 0.4f, 0.4f);
        }

    }
}
