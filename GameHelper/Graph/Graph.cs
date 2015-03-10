using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameHelper.Graph
{
    /// <summary>
    /// Graph class
    /// </summary>
    /// <typeparam name="T"></typeparam>
   public class Graph<T> : ICloneable
    {
       /// <summary>
       /// List of all vertices
       /// </summary>
       public List<Vertex<T>> vertices = new List<Vertex<T>>();
       /// <summary>
       /// List of all Edges
       /// </summary>
        List<Edge<T>> edges = new List<Edge<T>>();

       /// <summary>
       /// Poen List for A*Algorithm
       /// </summary>
        public List<Vertex<T>> openList = new List<Vertex<T>>();
       /// <summary>
       /// Close List for A*Algorithm
       /// </summary>
        public List<Vertex<T>> closedList = new List<Vertex<T>>();

       /// <summary>
       /// vertices ID
       /// </summary>
        int id = 0;
       /// <summary>
       /// Get the total number of vertices
       /// </summary>
        public int Count
        {
            get
            {
                return vertices.Count;
            }
        }
       /// <summary>
       /// Clones the Grpah
       /// </summary>
       /// <returns>The graph</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
       /// <summary>
       /// total number of edges in the graph
       /// </summary>
        public int EdgeCount
        {
            get
            {
                return edges.Count;
            }
        }
       /// <summary>
       /// Creates a vertex in the graph
       /// </summary>
       /// <param name="data"></param>
       /// <returns>the vertex</returns>
        public Vertex<T> CreateVertex(T data)
        {
            Vertex<T> myVertex = new Vertex<T>(id);
            id++;
            myVertex.data = data;
            vertices.Add(myVertex);

            return myVertex;
        }



       /// <summary>
       /// Add a edge between two vertices
       /// </summary>
       /// <param name="v1">Start vertex</param>
       /// <param name="v2">End vertex</param>
        public void AddEdge(Vertex<T> v1, Vertex<T> v2)
        {
            edges.Add(new Edge<T>(v1,v2));
            v1.outDegree++;
            v2.inDegree++;
            
        }

       /// <summary>
       /// Get a vertex
       /// </summary>
       /// <param name="start">The data</param>
       /// <returns>the vertex</returns>
        public Vertex<T> GetVertex(T start)
        {


            return vertices.Find(x => x.data.Equals(start));
        }

       /// <summary>
       /// Get all connected vertcies
       /// </summary>
       /// <param name="_vertex">vertex to get all connected vertieces</param>
       /// <returns>all vertieces they are connected to the vertex</returns>
        List<Vertex<T>> GetConnectedVertices(Vertex<T> _vertex)
        {
            List<Vertex<T>> myVertices = new List<Vertex<T>>();
            foreach (Edge<T> _edge in edges)
            {
                if (_edge.BaseVertex == _vertex)
                {
                    myVertices.Add(_edge.TargetVertex);
                }
            }

            return myVertices;
        }
       /// <summary>
       /// Checked if a vertex has a connection
       /// </summary>
       /// <param name="_vertex">a vertex</param>
       /// <returns>true if a connection exist</returns>
       bool HasConnection(Vertex<T> _vertex)
       {
           foreach(Edge<T> _edge in edges)
           {
               if (_edge.BaseVertex == _vertex)
               {
                   return true;
               }

           }
           return false;
       }

       /// <summary>
       /// Get a random way
       /// </summary>
       /// <param name="start">startpoint</param>
       /// <returns></returns>
        public List<Vertex<T>> GetWay(Vertex<T> start)
        {
            List<Vertex<T>> myWay = new List<Vertex<T>>();
            Vertex<T> next = start;
            myWay.Add(start);

            while (next.outDegree > 0)
            {
                Random rnd = new Random();




                int k = GetConnectedVertices(next).Count - 1;

                int j = rnd.Next(0,k);

                myWay.Add(GetConnectedVertices(next)[j]);
                next = GetConnectedVertices(next)[j];
            } 

            return myWay;
        }

       /// <summary>
       /// A*-algorithm
       /// </summary>
       /// <param name="start">startpoint</param>
       /// <param name="end">endpoint</param>
       /// <returns>a shotrt path</returns>
        public List<Vertex<T>> Astern(Vertex<T> start, Vertex<T> end)
        {
            Config.AStarIsFinish = false;
            openList.Add(start);
            start.GetDistanceTo(end);
            while (!closedList.Contains(end) || openList.Count > 0)
            {
                if (openList.Count > 0)
                {
                    Vertex<T> activeVertex = LowestFinOpenList();
                    openList.Remove(activeVertex);
                    closedList.Add(activeVertex);

                    foreach (Vertex<T> _vertex in activeVertex.connectedVertices)
                    {
                        if (!closedList.Contains(_vertex))
                        {
                            if (!openList.Contains(_vertex))
                            {
                                openList.Add(_vertex);
                                _vertex.GetDistanceTo(end);
                                _vertex.parent = activeVertex;
                            }
                            else
                            {
                                if (_vertex.parent != null)
                                {
                                    if (_vertex.parent.g < activeVertex.g)
                                    {
                                        _vertex.parent = activeVertex;
                                    }
                                }
                            }

                        }
                    }
                }

            }

           
            List<Vertex<T>> pathList = new List<Vertex<T>>();
            pathList.Add(end);
            if (end.parent != null)
            {
                Vertex<T> pathVertex = end.parent;
                pathList.Add(pathVertex);
                while (pathVertex != start)
                {
                    if (pathVertex.parent != null)
                    {
                        pathList.Add(pathVertex.parent);
                        pathVertex = pathVertex.parent;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            pathList.Add(start);
            openList.Clear();
            closedList.Clear();
            foreach (Vertex<T> _vertex in vertices)
            {

                _vertex.Reset();
            }
            Config.AStarIsFinish = true;
            return pathList;
        }
       /// <summary>
       /// A* helper method
       /// </summary>
       /// <returns>the lowest wieght of a connection</returns>
        Vertex<T> LowestFinOpenList()
        {
            Vertex<T> lowestF = null;


            if (lowestF == null)
            {
                return openList[0];
            }
            else
            {
                
            }


            foreach (Vertex<T> _vertex in openList)
            {
                
                if (lowestF == null)
                {
                    lowestF = _vertex;
                }
                if (lowestF.F > _vertex.F)
                {
                    lowestF = _vertex;
                }

            }
      
           
            return lowestF;
        }

    }

   
}
