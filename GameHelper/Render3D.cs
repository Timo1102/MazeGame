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
        public List<ModelMesh> myMeshes = new List<ModelMesh>();

        public Model model;
        public ModelMesh mesh;
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
        Matrix[] transforms;


        public Render3D(GameObject gameobj, string name) : base(gameobj)
        {
            LoadModel(name);
            colorRGB = Color.Red;
            gameobj.game.Components.Add(this);
           
          
        }
       
           

        public void LoadModel(string name)
        {
            model = gameObj.game.Content.Load<Model>(name);
  
           transforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(transforms);
            
        }

        public void SetEffects(Camera camera, ModelMesh _mesh)
        {


                foreach (BasicEffect effect in _mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = true;
                    effect.Projection = camera.Projection;
                    effect.View = camera.View;
                    effect.World = transforms[_mesh.ParentBone.Index] * gameObj.transform.GetWorldMatrix();
                }
            
        }

        

    }
}
