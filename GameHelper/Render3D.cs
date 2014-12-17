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
        private Color _color;
        public Vector3 color
        {
            get
            {
                return _color.ToVector3();
            }
            set
            {
                _color = new Color(value);
            }
        }

        public Color colorRGB
        {
            get
            {
                return _color;
            }
            set 
            {
                _color = value;

            }
        }
        


        public Render3D(GameObject gameobj, string name) : base(gameobj)
        {
            LoadModel(name);
            colorRGB = Color.Red;
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
                    effect.DiffuseColor = color;

                }
            }
        }

    }
}
