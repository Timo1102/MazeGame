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

namespace GameHelper
{
    public class scene : Microsoft.Xna.Framework.GameComponent
    {

        public Game game;
        public scene(Game game)
            : base(game)
        {
            this.game = game;
        }

       public string name;
        public Stack<GameObject> gameobjects = new Stack<GameObject>();

        public virtual void SceneObjects()
        {

        }

        public void Instatiate(GameObject prefab)
        {

            gameobjects.Push(prefab);
        }
    }



}
