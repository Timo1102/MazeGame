﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GameHelper
{
    public class Render3D : Render
    {
        public Model model;
        public List<ModelMesh> myMeshes = new List<ModelMesh>();

        public ModelMesh mesh;
        public Effect meshEffect;
        BasicEffect effect;

        Matrix[] transforms;

        public Render3D(GameObject gameobj, string name) : base(gameobj, name)
        {
            LoadModel(name);
           
            //t2D = new Texture2D(gameObj.game.GraphicsDevice, 1, 1);

            //t2D.SetData<Color>(new Color[] {
            //    Color.Red
            //});
        

            
            foreach (ModelMesh _mesh in model.Meshes)
            {
               
                myMeshes.Add(_mesh);
               


            }
         
            
        }
       
           

        public void LoadModel(string name)
        {
            model = gameObj.game.Content.Load<Model>(name);

            color = ((BasicEffect)model.Meshes[0].Effects[0]).DiffuseColor;
           transforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(transforms);


           

        }
        public void AddMesh(int _number)
        {
            myMeshes.Add(model.Meshes[_number]);
        }

        public virtual void SetEffects(Camera camera, ModelMesh _mesh)
        {
            


            foreach (BasicEffect effect in _mesh.Effects)
            {
                
                effect.EnableDefaultLighting();
                effect.PreferPerPixelLighting = true;
                effect.Projection = camera.Projection;
                effect.View = camera.View;
                effect.World = transforms[_mesh.ParentBone.Index] * gameObj.transform.GetWorldMatrix();
                effect.DiffuseColor = color;
                
                

            }
            
        }


        public void ChangeColor(Color _color, ModelMesh _mesh)
        {
            foreach (BasicEffect _effect in _mesh.Effects)
            {
                _effect.DiffuseColor = _color.ToVector3();
                
            }

        }

        public override void Draw(GameTime gameTime)
        {
            gameObj.game.spriteBatch.Begin();
            GraphicsDevice.DepthStencilState = new DepthStencilState() { DepthBufferEnable = true };
            GraphicsDevice.BlendState = BlendState.Opaque;
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            foreach(ModelMesh _mesh in myMeshes)
            {
            SetEffects(gameObj.mainCamera, _mesh);
                  _mesh.Draw();
            }
            gameObj.game.spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
