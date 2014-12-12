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
    class mainCamera : Camera
    {
        int i = 0;

        public mainCamera(Game game)
            : base(game)
        {

        }

        public override void Update(GameTime gameTime)
        {
            i++;
            position = new Vector3(0, 0 + i , -5000.0f +i);
            rotation = new Vector3(0, 0, 0);
            Console.WriteLine("CameraUpdate" + position.ToString());
            base.Update(gameTime);
        }

    }
}
