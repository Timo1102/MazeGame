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
        

        public background(Game game) : base(game)
        {
            position = new Vector3(10, 10, 0);
            LoadModel("Cube");
        }

        public override void Update(GameTime gameTime)
        {
            Console.WriteLine("Background wird gemalt");
            base.Update(gameTime);
        }

    }
}
