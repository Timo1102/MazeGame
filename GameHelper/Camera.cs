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

       public float near;
       public float far;


        //Attributes
        private Vector3 cameraLookAt;     //look at vector
        private Matrix rotationMatrix;



       



        public Matrix Projection
        {
            get;
            protected set;
        }

        public Matrix View
        {
            get
            {
                return Matrix.CreateLookAt(transform.Position, cameraLookAt, Vector3.Up);
            }
        }




        //Constructor
        public Camera(Game game, Camera mainCamera)
            : base(game, mainCamera)
        {
            near = 0.01f;
            far = 10000f;

            UpdateProjectionMatrix();
          
        }

       private  void UpdateProjectionMatrix()
       {
            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, Game.GraphicsDevice.Viewport.AspectRatio, near, far);
       }


        private void UpdateLookAt()
        {

             rotationMatrix = Matrix.CreateRotationX(transform.Rotation.X) *
                                    Matrix.CreateRotationY(transform.Rotation.Y) *
                                    Matrix.CreateRotationZ(transform.Rotation.Z);

            Vector3 lookAtOffset = Vector3.Transform(
                                   Vector3.UnitZ, rotationMatrix);


            cameraLookAt = transform.Position + lookAtOffset;
        }

        public override void Update(GameTime gameTime)
        {

            UpdateLookAt();
            base.Update(gameTime);
        }



    }
}
