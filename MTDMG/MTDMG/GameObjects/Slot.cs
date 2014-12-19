using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using GameHelper;

namespace MTDMG.GameObjects 
{
    class Slot : GameObject
    {
        


        public Slot(MyGame game)
            : base(game, game.mainCamera)
        {
           renderer = new Render3D(this, "Model/Slot");
           renderer.myMeshes.Clear();
           renderer.myMeshes.Add(renderer.model.Meshes[0]);
           CanClick = true;
        }

        public override void MouseClick()
        {
           
            
            base.MouseClick();
        }


      
    }
}
