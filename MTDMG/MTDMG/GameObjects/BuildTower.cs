using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameHelper;
using Microsoft.Xna.Framework;

namespace MTDMG.GameObjects
{
    /// <summary>
    /// Button to buid a tower
    /// </summary>
    class BuildTower : Button 
    {

        public PlayerControler player;
        public Slot slot;
        public BuildTower(MazeGame game, PlayerControler player)
            : base(game, "Textures/Button1")
        {
            this.player = player;
            CanClick = true;
            isActive = true;
            ((Render2D)renderer).SetOrigin = Render2D.Origin.BottomRight;
            ((Render2D)renderer).Offset = new Rectangle(-10, -10, -20, -20);
            //this.transform.Scale = new Vector3(0.5f, 0.5f, 0);
           // this.transform.Scale = new Vector3(0.5f, 0.5f, 0.5f);
        }


        public override void MouseClick()
        {
            Console.WriteLine("Click on Button BuildTower");
            
            player.SpwanTower(slot);
            base.MouseClick();
        }

        public override void Update(GameTime gameTime)
        {
           // 
            base.Update(gameTime);
        }

    }
}
