using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameHelper;
using Microsoft.Xna.Framework;

namespace MTDMG.GameObjects.Buttons
{
    class b_b_Searcher : Button
    {
        PlayerControler player;
        public GameObject slot;


        public b_b_Searcher(MazeGame game, PlayerControler player)
            : base(game, "Textures/Button1")
        {
            this.player = player;
            this.isActive = false;
            ((Render2D)renderer).SetOrigin = Render2D.Origin.BottomRight;
            renderer.color = Color.BurlyWood.ToVector3();
            CanClick = true;
            ((Render2D)renderer).Offset = new Rectangle(-10, -10, -20, -20);
        }

        public override void MouseClick()
        {
            player.myBase.SpawnSearcher();
            base.MouseClick();
        }

    }
}
