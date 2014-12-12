using System;
using System.Collections.Generic;
using System.Linq;
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
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class background : GameObject
    {

        float i = 0;
        public background(Game game) : base(game)
        {
            position = new Vector3(0, 0, 0);
            scale = new Vector3(2.5f, 2.5f, 2.5f);
            LoadModel("Cube");
        }

        public override void Update(GameTime gameTime)
        {

          
            Console.WriteLine("Background wird gemalt");
            
            base.Update(gameTime);
        }

    }
}
