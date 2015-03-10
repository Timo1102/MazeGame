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
    /// <summary>
    /// Camera class
    /// </summary>
   public class Camera : GameObject
    {
       /// <summary>
       /// far plane
       /// </summary>
       public float near;
       /// <summary>
       /// near plane
       /// </summary>
       public float far;


        //Attributes
       /// <summary>
       /// Look at vektor
       /// </summary>
        private Vector3 cameraLookAt; 
       
       /// <summary>
       /// the rotationmatrix
       /// </summary>
        private Matrix rotationMatrix;



       


       /// <summary>
       /// Gets and sets the Projection matrix
       /// </summary>
        public Matrix Projection
        {
            get;
            protected set;
        }
       /// <summary>
       /// Get the viewMatrix
       /// </summary>
        public Matrix View
        {
            get
            {
                return Matrix.CreateLookAt(transform.Position, cameraLookAt, Vector3.Up);
            }
        }




      
       /// <summary>
       /// Sets the near and farplane
       /// </summary>
       /// <param name="game"></param>
       /// <param name="mainCamera"></param>
        public Camera(myGame game, Camera mainCamera)
            : base(game, mainCamera)
        {
            near = 0.01f;
            far = 10000f;

            UpdateProjectionMatrix();
          
        }
       /// <summary>
       /// Update the projection matrix
       /// </summary>
       private  void UpdateProjectionMatrix()
       {
            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, Game.GraphicsDevice.Viewport.AspectRatio, near, far);
       }

       /// <summary>
       /// Update the look at vector
       /// </summary>
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
