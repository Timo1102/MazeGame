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
    public class GameObject : Microsoft.Xna.Framework.GameComponent
    
    {
        public string Name;
        public List<GameObject> children = new List<GameObject>();
        public bool isActive;
        public Transform transform;
        public float IntervallOffset = 1;
        public Render renderer = null;
        public bool CanClick = false;

        Timer lTimer = new Timer();



        public BoundingBox collider
        {
            get
            {
                if(renderer.GetType() == typeof(Render3D))
                return UpdateBoundingBox(((Render3D)renderer).model, transform.GetWorldMatrix());

                return new BoundingBox();
            }
        }


        public myGame game;
        public Camera mainCamera;
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

        public void SetActive(bool active)
        {
            isActive = active;
            
        }

        public override void Update(GameTime gameTime)
        {
            


            base.Update(gameTime);
        }

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

        public virtual void Tick(object sender, EventArgs e)
        {
           

           
        }



        public void AddAsChild(GameObject child)
        {
            children.Add(child);
        }

        public virtual void MouseClick()
        {

        }

        public virtual void MouseClick(long number)
        {
            
        }

        public virtual void MousePressed(long number)
        {

        }

        public virtual void MouseReleased()
        {

        }

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
