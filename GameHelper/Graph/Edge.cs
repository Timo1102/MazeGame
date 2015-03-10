using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameHelper.Graph
{

    /// <summary>
    /// Edge class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Edge<T>
    {

        /// <summary>
        /// How many Towers are in range
        /// </summary>
        public int weight;
        public Vertex<T> BaseVertex;
        public Vertex<T> TargetVertex;

        /// <summary>
        /// Add Edge to the graph
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public Edge(Vertex<T> v1, Vertex<T> v2)
        {
            BaseVertex = v1;
            TargetVertex = v2;
            v1.AddConnection(v2);
            v2.AddConnection(v1);
    }


    }
}
