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

namespace GameHelper
{
    public class GameObject : Microsoft.Xna.Framework.GameComponent
    {
        public string Name;
        public List<GameObject> children = new List<GameObject>();
        public bool isActive;
        public Transform transform;
        public Render3D renderer = null;
        public bool CanClick = false;

        public BoundingBox collider
        {
            get
            {
                return UpdateBoundingBox(renderer.model, transform.GetWorldMatrix());
            }
        }


        public Game game;
        public Camera mainCamera;
        public GameObject(Game game, Camera mainCamera)
            : base(game)
        {
            this.mainCamera = mainCamera;
            transform = new Transform();
            this.game = game;
            game.Components.Add(this);
            isActive = true;
        }

        public void SetActive(bool active)
        {
            isActive = active;
            
        }

        public override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);
        }

        public void AddAsChild(GameObject child)
        {
            children.Add(child);
        }

        public virtual void MouseClick()
        {

        }

        protected BoundingBox UpdateBoundingBox(Model model, Matrix worldTransform)
        {
            // Initialize minimum and maximum corners of the bounding box to max and min values
            Vector3 min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            Vector3 max = new Vector3(float.MinValue, float.MinValue, float.MinValue);

            // For each mesh of the model
            foreach (ModelMesh mesh in model.Meshes)
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
