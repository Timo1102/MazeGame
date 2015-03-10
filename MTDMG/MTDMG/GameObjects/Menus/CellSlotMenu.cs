using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTDMG.GameObjects.Menus
{
    /// <summary>
    /// Menu of a CellSlot
    /// </summary>
   public class CellSlotMenu : Menu
    {
        public CellSlotMenu(MazeGame game, PlayerControler player)
            : base(game, player)
        {
            btn1 = new BuildTower(game, player);
            btn2 = new Buttons.DestroyWall(game, player);
            btn3 = new Buttons.b_UpgradeTower(game, player);
            isActive = false;
            InitButtons();
        }

        public override void Open(GameHelper.GameObject gobj)
        {
            ((BuildTower)btn1).slot = (Slot)gobj;
            ((Buttons.DestroyWall)btn2).slot = (Slot)gobj;
            ((Buttons.b_UpgradeTower)btn3).slot = (Slot)gobj;

            base.Open(gobj);
        }

        public override void InitButtons()
        {
            game.myScene.Instatiate(btn1);
            game.myScene.Instatiate(btn2);
            game.myScene.Instatiate(btn3);
            base.InitButtons();
        }



    }
}
