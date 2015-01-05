using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameHelper.Graph
{
   public class Graph<T>
    {
       public List<Vertex<T>> vertices = new List<Vertex<T>>();
        List<Edge<T>> edges = new List<Edge<T>>();

        public int Count
        {
            get
            {
                return vertices.Count;
            }
        }

        public int EdgeCount
        {
            get
            {
                return edges.Count;
            }
        }

        public void CreateVertex(T data)
        {
            Vertex<T> myVertex = new Vertex<T>();
            myVertex.data = data;
            vertices.Add(myVertex);
            
        }

        public void AddEdge(Vertex<T> v1, Vertex<T> v2)
        {
            edges.Add(new Edge<T>(v1,v2));
            
        }

    }
}
