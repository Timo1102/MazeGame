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

        MyGame _game;
        GameObjects.Tower tower;
        public Slot(MyGame game)
            : base(game, game.mainCamera)
        {
            _game = game;
           renderer = new Render3D(this, "Model/Slot");
           renderer.myMeshes.Clear();
           renderer.myMeshes.Add(renderer.model.Meshes[0]);
           CanClick = true;
        }

        public override void MouseClick()
        {
            tower = new GameObjects.Tower(_game);
            tower.transform.Position = this.transform.Position;

            _game.startscene.Instatiate(tower);

            base.MouseClick();
        }


      
    }
}
