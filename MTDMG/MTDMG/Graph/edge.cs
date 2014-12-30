using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTDMG.Graph
{
    class edge
    {
        public edge(vertex first, vertex second)
        {
            firstVertex = first;
            secondVertex = second;

            first.AddEdge(this);
            second.AddEdge(this);
        }

        public vertex firstVertex, secondVertex;
    }
}
