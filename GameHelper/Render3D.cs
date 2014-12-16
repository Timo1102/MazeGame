using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GameHelper
{
    public class Render3D : ObjectComponent
    {
        public Model model;
        public Render3D(GameObject gameobj, string name) : base(gameobj)
        {
            LoadModel(name);
        }
       

        public void LoadModel(string name)
        {
            model = gameObj.game.Content.Load<Model>(name);
        }

        public void SetEffects(Camera camera)
        {
            
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = true;
                    effect.Projection = camera.Projection;
                    effect.View = camera.View;
                    effect.World = gameObj.transform.GetWorldMatrix();

                }
            }
        }

    }
}
