using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTDMG.GameObjects.Guards
{
    class Runner : Guard
    {
        public Runner(MazeGame game, PlayerControler player)
            : base(game, player)
        {
            IntervallOffset = 0.3f;
        }
    }
}
