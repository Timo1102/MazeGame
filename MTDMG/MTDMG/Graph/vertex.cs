using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MazeGenerator;

namespace MTDMG.Graph
{
    class vertex
    {
        public vertex(Cell _cell)
        {
            myCell = _cell;
        }

        Cell myCell;
        public List<edge> edges = new List<edge>();

        public void AddEdge(edge _edge)
        {
            edges.Add(_edge);
        }

    }
}
