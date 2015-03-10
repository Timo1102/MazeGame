using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameHelper;
using Microsoft.Xna.Framework;

namespace MTDMG.GameObjects.Buttons
{
    /// <summary>
    /// Button to build a Destroyer
    /// </summary>
    class b_b_Destroyer : Button
    {
        PlayerControler player;
        public GameObject slot;


        public b_b_Destroyer(MazeGame game, PlayerControler player)
            : base(game, "Textures/Button3")
        {
            this.player = player;
            this.isActive = false;
            ((Render2D)renderer).SetOrigin = Render2D.Origin.TopLeft;
            renderer.color = Color.Aqua.ToVector3();
            CanClick = true;
            ((Render2D)renderer).Offset = new Rectangle(+10, +10, -20, -20);
        }

        public override void MouseClick()
        {
         
             player.myBase.SpawnDestroyer();
            base.MouseClick();
        }

        
    }
}
