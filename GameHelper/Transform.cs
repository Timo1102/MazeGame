using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GameHelper
{
    /// <summary>
    /// transformation calss
    /// </summary>
   public class Transform
    {
       /// <summary>
       /// Position of the gameobject
       /// </summary>
        private Vector3 position;
       /// <summary>
       /// Rotation of the gameobject
       /// </summary>
        private Vector3 rotation;
       /// <summary>
       /// scale of the gameobject
       /// </summary>
        private Vector3 scale;

       /// <summary>
       /// Worldmatrix
       /// </summary>
        Matrix WorldMatrix;

       /// <summary>
       /// gets or sets the Position
       /// </summary>
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

       /// <summary>
       /// Gets or sets the Roation
       /// </summary>
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
       /// <summary>
       /// Gets or Sets the scale
       /// </summary>
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
       /// <summary>
       /// Forward vector
       /// </summary>
        public Vector3 Forward
        {
            get
            {
                return WorldMatrix.Forward;
            }
            private set { }
        }
       /// <summary>
       /// Backward vector
       /// </summary>
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
       /// <summary>
       /// Left Vector
       /// </summary>
        public Vector3 Left
        {
            get
            {
                return WorldMatrix.Left;
            }
        }
       /// <summary>
       /// Right Vector
       /// </summary>
        public Vector3 Right
        {
            get
            {
                return WorldMatrix.Right;
            }
        }
       /// <summary>
       /// Down Vector
       /// </summary>
        public Vector3 Down
        {
            get
            {
                return WorldMatrix.Down;
            }
        }
       /// <summary>
       /// Up Vector
       /// </summary>
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

       /// <summary>
       /// Get a 2D vector
       /// </summary>
       /// <returns></returns>
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
