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
    /// the game
    /// </summary>
    public class myGame : Microsoft.Xna.Framework.Game
    {
        /// <summary>
        /// the active scene
        /// </summary>
        public scene myScene;
        /// <summary>
        /// the main camera
        /// </summary>
        public Camera mainCamera;

        /// <summary>
        /// the graphicdevies
        /// </summary>
        public readonly GraphicsDeviceManager graphics;

        /// <summary>
        /// A colletion of all sprites
        /// </summary>
        public SpriteBatch spriteBatch;

        /// <summary>
        /// Background color
        /// </summary>
        protected Color backgroundColor = new Color(81, 81, 81);
        protected bool applicationLoadCompleteSignalled;
        /// <summary>
        /// checked if mouse down
        /// </summary>
        bool MouseIsDown = false;

        public myGame()
        {
            graphics = new GraphicsDeviceManager(this);
            
            

        }

        protected override void Update(GameTime gameTime)
        {

            if (Mouse.GetState().LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                if (!MouseIsDown)
                {
                    MouseIsDown = true;
                    GameObject toch = CheckTouch(Mouse.GetState().X, Mouse.GetState().Y);
                    if (toch != null)
                        toch.MouseClick();
                    Console.WriteLine("Clisck");
                }
            }

            if (Mouse.GetState().LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released)
            {
                MouseIsDown = false;
            }

            base.Update(gameTime);
        }



        /// <summary>
        /// Check where the mouse ist clicked
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordiante</param>
        /// <returns></returns>
        public virtual GameObject CheckTouch(float x, float y)
        {

            // Vector3 nearsource = new Vector3((float)Mouse.GetState().X, (float)Mouse.GetState().Y, 0f);
            // Vector3 farsource = new Vector3((float)Mouse.GetState().X, (float)Mouse.GetState().Y, 1f);


            Vector3 nearsource = new Vector3(x, y, 0f);
            Vector3 farsource = new Vector3(x, y, 1f);
            Matrix world = Matrix.CreateTranslation(0, 0, 0);


            //Set nearoint
            Vector3 nearPoint = GraphicsDevice.Viewport.Unproject(nearsource,
                    mainCamera.Projection, mainCamera.View, world);

            //Set farpoint
            Vector3 farPoint = GraphicsDevice.Viewport.Unproject(farsource,
                    mainCamera.Projection, mainCamera.View, world);


            //calculate direction
            Vector3 direction = farPoint - nearPoint;
            direction.Normalize();

            //Cast a ray
            Ray ray = new Ray(nearPoint, direction * 50);

            
            //for all object in the scene
            foreach (GameObject gobj in myScene.gamobjectsStack)
            {
                //Console.WriteLine("gibh: " + gobj.renderer.GetType());
                //If its clickable
                if (gobj.CanClick)
                {
                    //If 2D or 3D gameobject
                    if (gobj.renderer.GetType() == typeof(Render2D))
                    {
                        if (((Render2D)gobj.renderer).myRec.Contains((int)x, (int)y))
                        {
                            //gobj.MouseClick();
                            return gobj;
                        }
                    }
                    else
                    {



                        foreach (ModelMesh _mesh in ((Render3D)gobj.renderer).myMeshes)
                        {


                            //If ray intersects a object
                            if (ray.Intersects(gobj.collider) != null)
                            {
                                //return this object
                                return gobj;
                            }
                        }
                    }
                }
            }
            return null;

        }



    }
}
