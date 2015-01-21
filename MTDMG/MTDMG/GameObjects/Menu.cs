using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameHelper;

namespace MTDMG.GameObjects
{
    class Menu : GameObject
    {
        public Menu(MazeGame game)
            : base(game, game.mainCamera)
        {
            renderer = new Render2D(this, "Textures/test");
            //CanClick = true;
            btn1 = new BuildTower(game);
           
        }

        public void Init()
        {
            ((Scenes.StartScene)game.myScene).Instatiate(btn1);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            btn1.transform.Position = this.transform.Position;
            base.Update(gameTime);
        }

        public Button btn1;
        public Button btn2;
        public Button btn3;
        public Button btn4;

        public override void MouseClick()
        {
            Console.WriteLine("asdasdasdasda");
            base.MouseClick();
        }

    }
}
