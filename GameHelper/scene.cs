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
    public class scene : Microsoft.Xna.Framework.GameComponent
    {
        public scene(Game game)
            : base(game)
        {
        }

       public string name;
        public List<GameObject> gameobjects = new List<GameObject>();

        public virtual void SceneObjects()
        {

        }
    }



}
