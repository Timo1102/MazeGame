using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameHelper;
using Microsoft.Xna.Framework;

namespace MTDMG.GameObjects.Guards
{
    class Runner : Guard
    {
        public Runner(MazeGame game, PlayerControler player)
            : base(game, player)
        {
            IntervallOffset = 0.3f;
            renderer = new Render3D(this, "Model/Runner");
            transform.Scale = new Vector3(0.6f, 0.6f, 0.6f);
        }

        
       


    }
}
