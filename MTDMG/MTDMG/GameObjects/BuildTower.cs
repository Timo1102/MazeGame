using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameHelper;
using Microsoft.Xna.Framework;

namespace MTDMG.GameObjects
{
    class BuildTower : Button 
    {
        public BuildTower(MazeGame game)
            : base(game, "Textures/Button1")
        {
            CanClick = true;
            isActive = true;
            //this.transform.Scale = new Vector3(0.5f, 0.5f, 0);
           // this.transform.Scale = new Vector3(0.5f, 0.5f, 0.5f);
        }


        public override void MouseClick()
        {
            Console.WriteLine("Click on Button BuildTower");
            this.transform.Position = new Vector3(Microsoft.Xna.Framework.Input.Mouse.GetState().X, Microsoft.Xna.Framework.Input.Mouse.GetState().Y, 0);
            base.MouseClick();
        }

        public override void Update(GameTime gameTime)
        {
           // 
            base.Update(gameTime);
        }

    }
}
