﻿using System;
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
    /// <summary>
    /// scene class
    /// </summary>
    public class scene : Microsoft.Xna.Framework.GameComponent
    {

        public Game game;
        public scene(Game game)
            : base(game)
        {
            this.game = game;
        }

       public string name;
        public List<GameObject> gameobjects = new List<GameObject>();
        public Stack<GameObject> gamobjectsStack = new Stack<GameObject>();
        public virtual void SceneObjects()
        {

        }
        /// <summary>
        /// Add gameobject to the scene
        /// </summary>
        /// <param name="prefab"></param>
        public virtual void Instatiate(GameObject prefab)
        {
            gamobjectsStack.Push(prefab);
            gameobjects.Add(prefab);
        }
    }



}
