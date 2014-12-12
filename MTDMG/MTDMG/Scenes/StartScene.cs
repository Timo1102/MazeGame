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

namespace MTDMG.Scenes
{
   public class StartScene : scene
    {
       public GameObjects.background bg;


        public StartScene(Game game) : base(game)
        {
            name = "StartScene";
            bg = new GameObjects.background(game);

            gameobjects.Add(bg);
        }

        public override void SceneObjects()
        {

            base.SceneObjects();
        }

    }
}
