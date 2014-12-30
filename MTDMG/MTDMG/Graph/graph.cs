using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MazeGenerator;

namespace MTDMG.Graph
{
    class graph
    {
        public List<vertex> vertices = new List<vertex>();

        public void AddVertex(Cell _cell)
        {
            vertices.Add(new vertex(_cell));
        }

        public void AddConnection(vertex first, vertex second)
        {
            edge newEdge = new edge(first, second);    
        }

    }
}
