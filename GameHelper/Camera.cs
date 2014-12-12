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



   public class Camera : GameObject
    {
        
       public Matrix projectionMatrix;
       public Matrix viewMatrix;

        public Camera(Game game)
            : base(game)
        {
            position = new Vector3(0.0f, 0.0f, -2000.0f);
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(
            MathHelper.ToRadians(45.0f),
            Game.GraphicsDevice.DisplayMode.AspectRatio, 1.0f, 10000.0f);
            viewMatrix = Matrix.CreateLookAt(position, Vector3.Zero, Vector3.Up);
        }


    }
}
