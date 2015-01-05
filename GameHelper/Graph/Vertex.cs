using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameHelper.Graph
{
    public class Vertex<T>
    {
        List<Vertex<T>> connectedVertices = new List<Vertex<T>>();


        public T data;
        public int inDegree;
        public int outDegree;

        
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
