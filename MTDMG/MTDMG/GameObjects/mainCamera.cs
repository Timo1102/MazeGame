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
            KeyboardState newState = Keyboard.GetState();
            Vector3 movedirection = Vector3.Zero;
            if(newState.IsKeyDown(Keys.W))
            {
                movedirection = new Vector3(0, 0, 1);
            }

            if (newState.IsKeyDown(Keys.A))
            {
                movedirection = new Vector3(-1, 0, 0);
            }

            if (newState.IsKeyDown(Keys.S))
            {
                movedirection = new Vector3(0, 0, -1);
            }

            if (newState.IsKeyDown(Keys.D))
            {
                movedirection = new Vector3(1, 0, 0);
            }

            position += movedirection * 2.0f;
            rotation = new Vector3(0, 0, 0);
            Console.WriteLine("CameraUpdate" + position.ToString());
            base.Update(gameTime);
        }

    }
}
