using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTDMG.GameObjects.Menus
{
  public  class BaseMenu : Menu
    {
        public BaseMenu(MazeGame game, PlayerControler player)
            : base(game, player)
        {
            btn1 = new Buttons.b_b_Searcher(game, player);
            btn2 = new b_b_Runner(game, player);
            btn3 = new Buttons.b_b_Destroyer(game, player);
            isActive = false;
            InitButtons();
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
