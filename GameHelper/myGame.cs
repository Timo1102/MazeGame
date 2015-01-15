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
    public class myGame : Microsoft.Xna.Framework.Game
    {
        public scene myScene;
        public Camera mainCamera;


        public readonly GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        
        protected Color backgroundColor = new Color(81, 81, 81);
        protected bool applicationLoadCompleteSignalled;


        public myGame()
        {
            graphics = new GraphicsDeviceManager(this);
            
            

        }

        protected override void Update(GameTime gameTime)
        {

            if (Mouse.GetState().LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                CheckTouch(Mouse.GetState().X, Mouse.GetState().Y);
            }



            base.Update(gameTime);
        }




        public virtual void CheckTouch(float x, float y)
        {

            // Vector3 nearsource = new Vector3((float)Mouse.GetState().X, (float)Mouse.GetState().Y, 0f);
            // Vector3 farsource = new Vector3((float)Mouse.GetState().X, (float)Mouse.GetState().Y, 1f);


            Vector3 nearsource = new Vector3(x, y, 0f);
            Vector3 farsource = new Vector3(x, y, 1f);
            Matrix world = Matrix.CreateTranslation(0, 0, 0);



            Vector3 nearPoint = GraphicsDevice.Viewport.Unproject(nearsource,
                    mainCamera.Projection, mainCamera.View, world);

            Vector3 farPoint = GraphicsDevice.Viewport.Unproject(farsource,
                    mainCamera.Projection, mainCamera.View, world);



            Vector3 direction = farPoint - nearPoint;
            direction.Normalize();


            Ray ray = new Ray(nearPoint, direction * 50);

            // Console.WriteLine("Click" + direction);
            Console.WriteLine("aa: " + myScene.gameobjects.Count);
            foreach (GameObject gobj in myScene.gamobjectsStack)
            {


                if (gobj.CanClick)
                {


                    foreach (ModelMesh _mesh in ((Render3D)gobj.renderer).myMeshes)
                    {



                        if (ray.Intersects(gobj.collider) != null)
                        {
                            gobj.MouseClick();
                            return;
                        }
                    }
                }
            }

        }



    }
}
