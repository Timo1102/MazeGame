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
       public int i = 0;
        public Camera(Game game)
            : base(game)
        {
            
            position = new Vector3(0.0f, 0.0f, -2000.0f);
            rotation = new Vector3(0, 0, 0);
            SetMatrix();
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
            SetMatrix();
        }


        public void SetMatrix()
        {
            Vector3 cameraReference = new Vector3(0, 0, 1);
            Matrix rotationMatrix = Matrix.CreateFromYawPitchRoll(rotation.X, rotation.Y, rotation.Z);
            Vector3 transformedReference = Vector3.Transform(cameraReference, rotationMatrix);
            Vector3 cameraLookat = position + transformedReference;


            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(
            MathHelper.ToRadians(45.0f),
            Game.GraphicsDevice.DisplayMode.AspectRatio, 1.0f, 10000.0f);
           // viewMatrix = Matrix.CreateLookAt(position, rotation, Vector3.Up);
           viewMatrix = Matrix.CreateLookAt(position, cameraLookat, new Vector3(0.0f, 1.0f, 0.0f));
        }

    }
}
