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
        int id = 0;


        public List<Vertex<T>> openList = new List<Vertex<T>>();
        public List<Vertex<T>> closedList = new List<Vertex<T>>();

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
        public Vertex<T> CreateVertex(T data)
        {
            Vertex<T> myVertex = new Vertex<T>(id);
            id++;
            myVertex.data = data;
            vertices.Add(myVertex);

            return myVertex;
        }




        public void AddEdge(Vertex<T> v1, Vertex<T> v2)
        {
            edges.Add(new Edge<T>(v1,v2));
            v1.outDegree++;
            v2.inDegree++;
            
        }

        public Vertex<T> GetVertex(T start)
        {


            return vertices.Find(x => x.data.Equals(start));
        }

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


        public List<Vertex<T>> Astern(Vertex<T> start, Vertex<T> end)
        {
            openList.Add(start);
            start.GetDistanceTo(end);
            while (!closedList.Contains(end) || openList.Count > 0)
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
                            if (_vertex.parent.g < activeVertex.g)
                            {
                                _vertex.parent = activeVertex;
                            }
                        }

                    }
                }


            }

           
            List<Vertex<T>> pathList = new List<Vertex<T>>();
            pathList.Add(end);
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

            pathList.Add(start);
            return pathList;
        }

        Vertex<T> LowestFinOpenList()
        {
            Vertex<T> lowestF = null;
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
            openList.Remove(lowestF);
            return lowestF;
        }

    }

   
}
