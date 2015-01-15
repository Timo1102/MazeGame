using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GameHelper.Graph
{
    public class Vertex<T>
    {
        public List<Vertex<T>> connectedVertices = new List<Vertex<T>>();

        public int ID;
        public Vector2 position;

        public float g = 1;
        public float h = 0;

         Vertex<T> _parent;

         public Vertex<T> parent
         {
             get
             {
                 return _parent;
             }
             set
             {
                 _parent = value;
                 g += value.g;
             }
         }

        public float F
        {
            get
            {
                return g + h;
            }
        }


        public Vertex(int ID)
        {
            this.ID = ID;
            inDegree = 0;
            outDegree = 0;
    }

        public T data;
        public int inDegree;
        public int outDegree;

        public int Degree
        {
            get
            {
                return inDegree + outDegree;
            }
        }
        
        T GetData()
        {
            return data;
        }

        public void AddConnection(Vertex<T> v)
        {
            connectedVertices.Add(v);
            

        }

        public void Reset()
        {
            _parent = null;
            h = 0;
            g = 1;
        }

        public void SetPosition(Vector3 _pos)
        {
            position = new Vector2(_pos.X, _pos.Z);
        }

        public void GetDistanceTo(Vertex<T> EndVertex)
        {
            float x = this.position.X - EndVertex.position.X;
            float y = this.position.Y - EndVertex.position.Y;
            h = x + y;
        }

        

    }
}
