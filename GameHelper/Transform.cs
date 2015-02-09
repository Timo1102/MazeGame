using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GameHelper
{
   public class Transform
    {
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
            get
            {
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
                return WorldMatrix.Forward;
            }
            private set { }
        }

        public Vector3 Backward
        {
            get
            {
                return -Forward;
            }
            private set
            {
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

        public Transform()
        {
            position = new Vector3(0, 0, 0);
            rotation = new Vector3(0, 0, 0);
            scale = new Vector3(1.0f, 1.0f, 1.0f);
        }

       public Vector2 ToVector2()
       {
           return new Vector2(Position.X, Position.Z);
       }


        void UpdateWorldMat()
        {
            WorldMatrix = Matrix.CreateScale(scale)
                         * Matrix.CreateRotationX(Rotation.X) *
                          Matrix.CreateRotationY(Rotation.Y)
                         * Matrix.CreateRotationZ(Rotation.Z)
                         * Matrix.CreateTranslation(Position);
        }


        public Matrix GetWorldMatrix()
        {
            return WorldMatrix;
        }
    }
}
