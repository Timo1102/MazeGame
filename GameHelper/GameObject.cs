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
using System.Timers;

namespace GameHelper
{
    /// <summary>
    /// Gameobject class
    /// </summary>
    public class GameObject : Microsoft.Xna.Framework.GameComponent
    
    {
        /// <summary>
        /// Name of the gameobject
        /// </summary>
        public string Name;
        /// <summary>
        /// Childs from the gameobject
        /// </summary>
        public List<GameObject> children = new List<GameObject>();
        /// <summary>
        /// returns true is a gamobject is active
        /// </summary>
        public bool isActive;
        /// <summary>
        /// transfomration of a Gameobject
        /// </summary>
        public Transform transform;
        /// <summary>
        /// How often is tick called
        /// </summary>
        public float IntervallOffset = 1;
        /// <summary>
        /// A render class
        /// </summary>
        public Render renderer = null;
        /// <summary>
        /// if true a gameobject is clickable
        /// </summary>
        public bool CanClick = false;

        /// <summary>
        /// A timer
        /// </summary>
        Timer lTimer = new Timer();


        /// <summary>
        /// returns a collider
        /// </summary>
        public BoundingBox collider
        {
            get
            {
                if(renderer.GetType() == typeof(Render3D))
                return UpdateBoundingBox(((Render3D)renderer).model, transform.GetWorldMatrix());

                return new BoundingBox();
            }
        }

        /// <summary>
        /// The active game
        /// </summary>
        public myGame game;

        /// <summary>
        /// Camera to render this gameobject
        /// </summary>
        public Camera mainCamera;

        /// <summary>
        /// Instantiate the gamobject
        /// </summary>
        /// <param name="game"></param>
        /// <param name="mainCamera"></param>
        public GameObject(myGame game, Camera mainCamera)
            : base(game)
        {
            this.mainCamera = mainCamera;
            transform = new Transform();
            this.game = game;
            game.Components.Add(this);
            isActive = true;
         
            InitTimer();
        }

        /// <summary>
        /// change the gameobject isActive
        /// </summary>
        /// <param name="active">true if the gameobject should be seen in the game</param>
        public void SetActive(bool active)
        {
            isActive = active;
            
        }

        public override void Update(GameTime gameTime)
        {
            


            base.Update(gameTime);
        }

        /// <summary>
        /// Initiate a timer
        /// </summary>
        public void InitTimer()
        {

            lTimer = new Timer();
            lTimer.Interval = Config.TickIntervall * IntervallOffset;
            lTimer.Elapsed += new ElapsedEventHandler(Tick);
            StartTimer();
            lTimer.Start();
        }

        public virtual void StartTimer()
        {

            
        }

        /// <summary>
        /// Is called every intervall
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void Tick(object sender, EventArgs e)
        {
           

           
        }


        /// <summary>
        /// Adds a child
        /// </summary>
        /// <param name="child"></param>
        public void AddAsChild(GameObject child)
        {
            children.Add(child);
        }

        /// <summary>
        /// called if a mouseclick on the gameobject
        /// </summary>
        public virtual void MouseClick()
        {

        }

        /// <summary>
        /// called if a touch on the gameobject
        /// </summary>
        /// <param name="number"></param>
        public virtual void MouseClick(long number)
        {
            
        }


        public virtual void MousePressed(long number)
        {

        }

        public virtual void MouseReleased()
        {

        }

        /// <summary>
        /// Destroyed a gameobject
        /// </summary>
        /// <param name="gameobject"></param>
        public static void Destroy(GameObject gameobject)
        {
            gameobject.game.Components.Remove(gameobject);
            gameobject.game.Components.Remove(gameobject.renderer);
            gameobject.renderer.Dispose();
            gameobject.game.myScene.gameobjects.Remove(gameobject);
            gameobject.Dispose();
            gameobject.isActive = false;
         
            
            //gameobject = null;

        }
        /// <summary>
        /// Update the Collider
        /// </summary>
        /// <param name="model"></param>
        /// <param name="worldTransform"></param>
        /// <returns></returns>
        protected BoundingBox UpdateBoundingBox(Model model, Matrix worldTransform)
        {
            // Initialize minimum and maximum corners of the bounding box to max and min values
            Vector3 min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            Vector3 max = new Vector3(float.MinValue, float.MinValue, float.MinValue);

            // For each mesh of the model
            foreach (ModelMesh mesh in ((Render3D)renderer).myMeshes)
            {
                foreach (ModelMeshPart meshPart in mesh.MeshParts)
                {
                    // Vertex buffer parameters
                    int vertexStride = meshPart.VertexBuffer.VertexDeclaration.VertexStride;
                    int vertexBufferSize = meshPart.NumVertices * vertexStride;

                    // Get vertex data as float
                    float[] vertexData = new float[vertexBufferSize / sizeof(float)];
                    meshPart.VertexBuffer.GetData<float>(vertexData);

                    // Iterate through vertices (possibly) growing bounding box, all calculations are done in world space
                    for (int i = 0; i < vertexBufferSize / sizeof(float); i += vertexStride / sizeof(float))
                    {
                        Vector3 transformedPosition = Vector3.Transform(new Vector3(vertexData[i], vertexData[i + 1], vertexData[i + 2]), worldTransform);

                        min = Vector3.Min(min, transformedPosition);
                        max = Vector3.Max(max, transformedPosition);
                    }
                }
            }

            // Create and return bounding box
            return new BoundingBox(min, max);
        }



    }
}
