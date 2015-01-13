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
   public class Slot : GameObject
    {

        MazeGame _game;
        GameObjects.Tower tower;
        bool isUsed = false;

        public Slot(MazeGame game)
            : base(game, game.mainCamera)
        {
            _game = game;
           renderer = new Render3D(this, "Model/Slot");
           renderer.color = Color.Gray.ToVector3();
           renderer.myMeshes.Clear();
           renderer.myMeshes.Add(renderer.model.Meshes[0]);
           CanClick = true;
        }

        public override void MouseClick()
        {

            ((Scenes.StartScene)game.myScene).SpwanTower(this.transform.Position);
            if (Keyboard.GetState().IsKeyDown(Keys.B))
            {
                ((Scenes.StartScene)game.myScene).DestroyWall(this);
            }

            base.MouseClick();
        }


      
    }
}
