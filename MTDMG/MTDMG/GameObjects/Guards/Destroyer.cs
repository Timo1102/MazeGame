using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameHelper;
using Microsoft.Xna.Framework;


namespace MTDMG.GameObjects.Guards
{
    /// <summary>
    /// Destroayer
    /// </summary>
    class Destroyer : Guard
    {
        public Destroyer(MazeGame game, PlayerControler player)
            : base(game, player)
        {
            renderer = new Render3D(this, "Model/Guard");
            transform.Scale = new Vector3(0.4f, 0.4f, 0.4f);
        }

        bool pathIsFound = false;

        public override void SearchPath()
        {


                GameHelper.Graph.Vertex<CellSlot> TowerVertex;
                if (((Scenes.StartScene)game.myScene).GetOpposit(player).towers.Count > 0)
                {

                    Console.WriteLine("is Tower");

                    foreach (CellSlot slot in ((Scenes.StartScene)game.myScene).GetOpposit(player).towers[0].allSlots)
                    {
                        Console.WriteLine("Hat Slots");
                        TowerVertex = GetVertex(player.playerGraph, slot.transform.ToVector2());
                        if (TowerVertex != null)
                        {
                            pathIsFound = true;
                            FindPath(TowerVertex.data);
                            Console.WriteLine("Tower: " + TowerVertex);
                        }
                        else
                        {
                            pathIsFound = false;
                        }

                    }

                    if (!pathIsFound)
                    {
                        myState = States.SearchField;
                    }

                }
                else
                {
                    myState = States.SearchField;
                }
            }

        }
    }


