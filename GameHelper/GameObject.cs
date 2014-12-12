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
        public bool isActive;

        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;

        public Model model;

        private Game game;

        public GameObject(Game game)
            : base(game)
        {
            this.game = game;
            game.Components.Add(this);
            isActive = true;
            position = new Vector3(0, 0, 0);
            rotation = new Vector3(0, 0, 0);
            scale = new Vector3(1.0f, 1.0f, 1.0f);
           
        }

        public void SetActive(bool active)
        {
            isActive = active;
            
        }

        public override void Update(GameTime gameTime)
        {
            Console.WriteLine("Muhahaha");
            base.Update(gameTime);
        }

        public void LoadModel(string name)
        {
            model = game.Content.Load<Model>(name);
        }

        public void SetEffects(Camera camera)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.Projection = camera.projectionMatrix;
                    effect.View = camera.viewMatrix;
                }
            }
        }

    }
}
