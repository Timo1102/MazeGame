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
           transform.Position = new Vector3(0, 0, 100);
           transform.Scale = new Vector3(1f, 1f, 1f);
           renderer = new Render3D(this, "Cube");
           

        }

        public override void Update(GameTime gameTime)
        {
             float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

             transform.Rotation = new Vector3(0, i, -0);
            //Position = Forward * i ;
            i+=0.1f;
            
            base.Update(gameTime);
        }

    }
}
