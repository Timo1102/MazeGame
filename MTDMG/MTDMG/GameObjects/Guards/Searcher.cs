using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameHelper;
using Microsoft.Xna.Framework;


namespace MTDMG.GameObjects.Guards
{
    /// <summary>
    /// Searcher
    /// </summary>
    class Searcher :Guard
    {
        public Searcher(MazeGame game, PlayerControler player)
            : base
                (game, player)
        {
          lastVertex =  player.playerGraph.CreateVertex(myVertex.data);
          renderer = new Render3D(this, "Model/Searcher");
          transform.Scale = new Vector3(0.4f, 0.4f, 0.4f);
            IntervallOffset = 0.3f;
        }

        GameHelper.Graph.Vertex<CellSlot> lastVertex;

        public override void newField()
        {
            //Gucken ist das Feld schon da?
            //Wenn ja nichts machen
            ////Wenn nein, dann hinzufügen
               GameHelper.Graph.Vertex<CellSlot> v2 = player.playerGraph.CreateVertex(myVertex.data);
            if (!player.playerGraph.vertices.Contains(myVertex))
            {
               
             
              
                


                player.playerGraph.AddEdge(lastVertex, v2);

            }
            lastVertex = v2;
            base.newField();
        }

        public override void start()
        {
            myState = States.SearchField;
        }
    }
}
