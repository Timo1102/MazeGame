using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Surface;
using Microsoft.Surface.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using GameHelper;


namespace MTDMG
{
    /// <summary>
    /// This is the main type for your application.
    /// </summary>
    public class MazeGame : myGame
    {


        public static MazeGame Instance;


        List<GameObject> oldTouches = new List<GameObject>();
        List<GameObject> newTouches = new List<GameObject>();
        List<GameObject> diffTouches = new List<GameObject>();

        private UserOrientation currentOrientation = UserOrientation.Bottom;
        private Matrix screenTransform = Matrix.Identity;
        float i = 0;
        
        private TouchTarget touchTarget;
        /// <summary>
        /// The target receiving all surface input for the application.
        /// </summary>
        protected TouchTarget TouchTarget
        {
            get { return touchTarget; }
        }
        /// <summary>
        /// Default constructor.
        /// </summary>
        public MazeGame() : base()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            
            Content.RootDirectory = "Content";
        }

        #region Initialization

        /// <summary>
        /// Moves and sizes the window to cover the input surface.
        /// </summary>
        private void SetWindowOnSurface()
        {
            System.Diagnostics.Debug.Assert(Window != null && Window.Handle != IntPtr.Zero,
                "Window initialization must be complete before SetWindowOnSurface is called");
            if (Window == null || Window.Handle == IntPtr.Zero)
                return;

            // Get the window sized right.
            Program.InitializeWindow(Window);
            // Set the graphics device buffers.
            graphics.PreferredBackBufferWidth = Program.WindowSize.Width;
            graphics.PreferredBackBufferHeight = Program.WindowSize.Height;
            graphics.ApplyChanges();
            // Make sure the window is in the right location.
            Program.PositionWindow();
        }

        /// <summary>
        /// Initializes the surface input system. This should be called after any window
        /// initialization is done, and should only be called once.
        /// </summary>
        private void InitializeSurfaceInput()
        {
            System.Diagnostics.Debug.Assert(Window != null && Window.Handle != IntPtr.Zero,
                "Window initialization must be complete before InitializeSurfaceInput is called");
            if (Window == null || Window.Handle == IntPtr.Zero)
                return;
            System.Diagnostics.Debug.Assert(touchTarget == null,
                "Surface input already initialized");
            if (touchTarget != null)
                return;

            // Create a target for surface input.
            touchTarget = new TouchTarget(Window.Handle, EventThreadChoice.OnBackgroundThread);
            touchTarget.EnableInput();
        }

        #endregion

        #region Overridden Game Methods

        /// <summary>
        /// Allows the app to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
           // this.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / 10.0f);
            //init Camera
            mainCamera = new GameObjects.mainCamera(this, mainCamera);

           
            myScene = new Scenes.StartScene(this);
            RasterizerState stat = new RasterizerState();
   

            GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;


            GraphicsDevice.BlendState = BlendState.Opaque;
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;

            GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;

            IsMouseVisible = true; // easier for debugging not to "lose" mouse
            SetWindowOnSurface();
            InitializeSurfaceInput();

            // Set the application's orientation based on the orientation at launch
            currentOrientation = ApplicationServices.InitialOrientation;

            // Subscribe to surface window availability events
            ApplicationServices.WindowInteractive += OnWindowInteractive;
            ApplicationServices.WindowNoninteractive += OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable += OnWindowUnavailable;

            // Setup the UI to transform if the UI is rotated.
            // Create a rotation matrix to orient the screen so it is viewed correctly
            // when the user orientation is 180 degress different.
            Matrix inverted = Matrix.CreateRotationZ(MathHelper.ToRadians(180)) *
                       Matrix.CreateTranslation(graphics.GraphicsDevice.Viewport.Width,
                                                 graphics.GraphicsDevice.Viewport.Height,
                                                 0);

            if (currentOrientation == UserOrientation.Top)
            {
                screenTransform = inverted;
            }

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per app and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your application content here
        }

        /// <summary>
        /// UnloadContent will be called once per app and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the app to run logic such as updating the world,
        /// checking for collisions, gathering input and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (ApplicationServices.WindowAvailability != WindowAvailability.Unavailable)
            {
                if (ApplicationServices.WindowAvailability == WindowAvailability.Interactive)
                {
                    // TODO: Process touches, 
                    // use the following code to get the state of all current touch points.
                     ReadOnlyTouchPointCollection touches = touchTarget.GetState();
                    
                     if (touches.Count > 0)
                     {
                         foreach (TouchPoint _touchpoint in touches)
                         {
                             if (_touchpoint.IsTagRecognized)
                             {
                                 GameObject _obj = CheckTouch(_touchpoint.X, _touchpoint.Y, _touchpoint);
                                 diffTouches.Add(_obj);


                                 if (oldTouches.Contains(_obj))
                                 {
                                     _obj.MousePressed(_touchpoint.Tag.Value);
                                 }
                                 else
                                 {
                                     _obj.MouseClick(_touchpoint.Tag.Value);
                                     oldTouches.Add(_obj);
                                 }    
                             }
                             else
                             {

                                 CheckTouch(_touchpoint.X, _touchpoint.Y);
                             }
                         }

                         //Veratbeitung
                         List<GameObject> objToRemove = new List<GameObject>();
                         foreach (GameObject nObj in oldTouches)
                         {
                             if (!diffTouches.Contains(nObj))
                             {
                                 objToRemove.Add(nObj);
                             }

                         }
                         foreach (GameObject dObj in objToRemove)
                         {
                             dObj.MouseReleased();
                             oldTouches.Remove(dObj);
                         }

                         objToRemove.Clear();
                         diffTouches.Clear();
                     }


                }

                if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.L))
                {
                    
                    ((Scenes.StartScene)myScene).InstatiateTower(new Vector2(5, 5), ((Scenes.StartScene)myScene).player1);
                }
               
               
       
                // TODO: Add your update logic here
            }

            base.Update(gameTime);
        }


        /// <summary>
        /// Checktouch with tags
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="touch"></param>
        /// <returns></returns>
        public GameObject CheckTouch(float x, float y, TouchPoint touch)
        {
            TagData data = touch.Tag;


           return base.CheckTouch(x, y);
        }




        /// <summary>
        /// This is called when the app should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (!applicationLoadCompleteSignalled)
            {
                // Dismiss the loading screen now that we are starting to draw
                ApplicationServices.SignalApplicationLoadComplete();
                applicationLoadCompleteSignalled = true;
            }

            //TODO: Rotate the UI based on the value of screenTransform here if desired
            
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            //foreach (GameObject obj in startscene.gameobjects)
            //{
                
            //    if (obj.isActive)
            //    {
            //        if (obj.renderer != null && obj.renderer.model != null)
            //        {
                      
            //            //Matrix[] transforms = new Matrix[obj.renderer.model.Bones.Count];
            //            //obj.renderer.model.CopyAbsoluteBoneTransformsTo(transforms);
            //            //foreach (ModelMesh mesh in obj.renderer.model.Meshes)
            //            //{
            //            //    foreach (BasicEffect effect in mesh.Effects)
            //            //    {

            //            //        effect.EnableDefaultLighting();
            //            //        effect.PreferPerPixelLighting = true;
            //            //        effect.Projection = mainCamera.Projection;
            //            //        effect.View = mainCamera.View;
            //            //        effect.World = transforms[mesh.ParentBone.Index] * obj.transform.GetWorldMatrix();
            //            //        //effect.DiffuseColor = color;

            //                //}
                            

            //           // }
               
            //            foreach (ModelMesh _mesh in obj.renderer.myMeshes)
            //            {
            //                obj.renderer.SetEffects(mainCamera, _mesh);
            //                _mesh.Draw();

            //            }

            //        }
            //    }
            //}

            //TODO: Add your drawing code here
            //TODO: Avoid any expensive logic if application is neither active nor previewed

            base.Draw(gameTime);
        }

        

        #endregion

        #region Application Event Handlers

        /// <summary>
        /// This is called when the user can interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowInteractive(object sender, EventArgs e)
        {
            //TODO: Enable audio, animations here

            //TODO: Optionally enable raw image here
            touchTarget.EnableImage(ImageType.Normalized);
        }

        /// <summary>
        /// This is called when the user can see but not interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowNoninteractive(object sender, EventArgs e)
        {
            //TODO: Disable audio here if it is enabled

            //TODO: Optionally enable animations here
        }

        /// <summary>
        /// This is called when the application's window is not visible or interactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowUnavailable(object sender, EventArgs e)
        {
            //TODO: Disable audio, animations here

            //TODO: Disable raw image if it's enabled
        }

        #endregion

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Release managed resources.
                IDisposable graphicsDispose = graphics as IDisposable;
                if (graphicsDispose != null)
                {
                    graphicsDispose.Dispose();
                }
                if (touchTarget != null)
                {
                    touchTarget.Dispose();
                    touchTarget = null;
                }
            }

            // Release unmanaged Resources.

            // Set large objects to null to facilitate garbage collection.

            base.Dispose(disposing);
        }

        #endregion

        
    }
}
