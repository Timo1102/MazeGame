using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameHelper.Graph
{
    public class Vertex<T>
    {
        public List<Vertex<T>> connectedVertices = new List<Vertex<T>>();

        public int ID;

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

    }
}
