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

        private Vector3 position;
        private Vector3 rotation;
        private Vector3 scale;

        Matrix WorldMatrix;

        public virtual Vector3 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                UpdateWorldMat();
            }
        }

        public virtual Vector3 Rotation
        {
            get
            {
                return rotation;
            }
            set
            {
                rotation = value;
                UpdateWorldMat();
            }
        }
        public virtual Vector3 Scale
        {
            get {
                return scale;
            }
            set
            {
                scale = value;
                UpdateWorldMat();
            }

        }

        public Vector3 Forward
        {
            get
            {
              return  WorldMatrix.Forward;
            }
            private set { }
        }

        public Vector3 Backward
        {
            get
            {
                return -Forward;
            }
            private set { 
            }
        }

        public Vector3 Left
        {
            get
            {
                return WorldMatrix.Left;
            }
        }

        public Vector3 Right
        {
            get
            {
                return WorldMatrix.Right;
            }
        }

        public Vector3 Down
        {
            get
            {
                return WorldMatrix.Down;
            }
        }

        public Vector3 Up
        {
            get
            {
                return WorldMatrix.Up;
            }
        }

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

        void UpdateWorldMat()
        {
           WorldMatrix = Matrix.CreateScale(scale)
                        * Matrix.CreateRotationX(Rotation.X) *
                         Matrix.CreateRotationY(Rotation.Y)
                        * Matrix.CreateRotationZ(Rotation.Z)
                        * Matrix.CreateTranslation(Position);
        }

        public override void Update(GameTime gameTime)
        {
            
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
                    effect.PreferPerPixelLighting = true;
                    effect.Projection = camera.Projection;
                    effect.View = camera.View;
                    effect.World = WorldMatrix;
          
                }
            }
        }

    }
}
