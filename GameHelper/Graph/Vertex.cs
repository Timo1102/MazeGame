using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GameHelper.Graph
{
    /// <summary>
    /// Vertex class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Vertex<T>
    {
        /// <summary>
        /// all connected vertices 
        /// </summary>
        public List<Vertex<T>> connectedVertices = new List<Vertex<T>>();
        /// <summary>
        /// a id
        /// </summary>
        public int ID;
        /// <summary>
        /// position in the graph
        /// </summary>
        public Vector2 position;

        /// <summary>
        /// wieght
        /// </summary>
        public float g = 1;
        /// <summary>
        /// offset of the weight
        /// </summary>
        public float h = 0;
        /// <summary>
        /// parent vertex for the A*-algorithm
        /// </summary>
         Vertex<T> _parent;

        /// <summary>
        /// Returns the parent
        /// </summary>
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
        /// <summary>
        /// calculate a float number, based on the offset and weight
        /// </summary>
        public float F
        {
            get
            {
                return g + h;
            }
        }

        /// <summary>
        /// Set ID and In and Out degree
        /// </summary>
        /// <param name="ID"></param>
        public Vertex(int ID)
        {
            this.ID = ID;
            inDegree = 0;
            outDegree = 0;
    }
        /// <summary>
        /// The data
        /// </summary>
        public T data;

 
        public int inDegree;
        public int outDegree;

        /// <summary>
        /// Number of all connection
        /// </summary>
        public int Degree
        {
            get
            {
                return inDegree + outDegree;
            }
        }
        
        /// <summary>
        /// Get the data
        /// </summary>
        /// <returns>the data</returns>
        T GetData()
        {
            return data;
        }

        /// <summary>
        /// Add a connection between this and an other vertex
        /// </summary>
        /// <param name="v"></param>
        public void AddConnection(Vertex<T> v)
        {
            connectedVertices.Add(v);
            

        }

        /// <summary>
        /// Reset all variables
        /// </summary>
        public void Reset()
        {
            _parent = null;
            h = 0;
            g = 1;
        }

        /// <summary>
        /// Set the Position
        /// </summary>
        /// <param name="_pos"></param>
        public void SetPosition(Vector3 _pos)
        {
            position = new Vector2(_pos.X, _pos.Z);
        }

        /// <summary>
        /// calculate a distance between this and an other point
        /// </summary>
        /// <param name="EndVertex"></param>
        public void GetDistanceTo(Vertex<T> EndVertex)
        {
            float x = this.position.X - EndVertex.position.X;
            float y = this.position.Y - EndVertex.position.Y;
            h = x + y;
        }

        

    }
}
