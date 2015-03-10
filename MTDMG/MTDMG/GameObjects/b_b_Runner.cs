using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameHelper;
using Microsoft.Xna.Framework;

namespace MTDMG.GameObjects
{
    /// <summary>
    /// Button to build a Runner
    /// </summary>
    class b_b_Runner : Button
    {
        PlayerControler player;
        public GameObject slot;

         public  b_b_Runner (MazeGame game, PlayerControler player)
            : base(game, "Textures/Button2")
        {
            this.player = player;
            this.isActive = false;
            ((Render2D)renderer).SetOrigin = Render2D.Origin.BottomLeft;
            renderer.color = Color.DeepSkyBlue.ToVector3();
            CanClick = true;
            ((Render2D)renderer).Offset = new Rectangle(+10, -10, -20, -20);
        }

         public override void MouseClick()
         {
         
                 player.myBase.SpawnRunner();

             base.MouseClick();
         }

    }
}
