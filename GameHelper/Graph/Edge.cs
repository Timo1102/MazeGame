using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameHelper.Graph
{
    public class Edge<T>
    {


        public int weight;
        public Vertex<T> BaseVertex;
        public Vertex<T> TargetVertex;


        public Edge(Vertex<T> v1, Vertex<T> v2)
        {
            BaseVertex = v1;
            TargetVertex = v2;
            v1.AddConnection(v2);
            v2.AddConnection(v1);
    }


    }
}
