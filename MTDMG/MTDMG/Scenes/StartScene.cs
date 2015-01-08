using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using GameHelper;
using MazeGenerator;


namespace MTDMG.Scenes
{
   public class StartScene : scene
    {
       public GameObjects.Cell bg;
       GameObjects.Cell prefab;
       GameObjects.Slot slot;
       GameObjects.CellSlot cellSlot;
      GameObjects.Base myBase = null;

     public GameHelper.Graph.Graph<GameObjects.CellSlot> myGraph;

      bool dev_show_cells = true;


       public List<GameObjects.CellSlot> solutionWay;
       public Maze myMaze;
       int x = 35;
       int y = 21;
       MyGame _game;

        public StartScene(MyGame game) : base(game)
       {
           myGraph = new GameHelper.Graph.Graph<GameObjects.CellSlot>();
           this._game = game;
           myMaze = new Maze(x, y);
           game.mainCamera.transform.Position = new Vector3(x - 2, 52, y - 1);
           game.mainCamera.transform.Rotation = new Vector3(1.57f, 0, 0);
           GenerateMaze();
            name = "StartScene";







            solutionWay = new List<GameObjects.CellSlot>();

          //List<GameHelper.Graph.Vertex<GameObjects.CellSlot>> sad =  myGraph.GetWay(GetVertex(new Vector2(myBase.transform.Position.X, myBase.transform.Position.Z)));
           

        }


        //public GameHelper.Graph.Vertex<GameObjects.CellSlot> GetVertex(Vector2 pos)
        //{
        //    foreach (GameHelper.Graph.Vertex<GameObjects.CellSlot> _vertex in myGraph.vertices)
        //    {
        //        if (_vertex.data.transform.Position == new Vector3(pos.X, _vertex.data.transform.Position.Y, pos.Y))
        //        {
        //            return _vertex;
        //        }
        //    }
        //    return null;
        //}

        public void GeneratePath(Vector2 endPos)
        {
            if (myBase == null)
            {
                myBase = new GameObjects.Base(_game);
                myBase.transform.Position = new Vector3(endPos.X, 0, endPos.Y);
                Instatiate(myBase);
           
            }else
            {


          // List<GameHelper.Graph.Vertex<GameObjects.CellSlot>> sad =
            solutionWay.Clear();
            GameHelper.Graph.Vertex<GameObjects.CellSlot> VertexStart = GetVertex(new Vector2(myBase.transform.Position.X, myBase.transform.Position.Z));
            GameHelper.Graph.Vertex<GameObjects.CellSlot> VertexEnd = GetVertex(endPos);

           

      

           
            List<GameHelper.Graph.Vertex<GameObjects.CellSlot>> sad = myGraph.Astern(VertexStart, VertexEnd);

         


           foreach (GameHelper.Graph.Vertex<GameObjects.CellSlot> _vertex in sad)
           {
               solutionWay.Add(_vertex.data);
           }
           List<GameObjects.CellSlot> myWay = new List<GameObjects.CellSlot>();
            myWay.Clear();
            for(int i = solutionWay.Count -1; i >=0; i--)
           {
               myWay.Add(solutionWay[i]);
           }


               myBase.SpawnTarget(myWay);

         }
        }
        public void ResetCellSlotColor()
        {
            foreach (GameHelper.Graph.Vertex<GameObjects.CellSlot> _vertex in myGraph.vertices)
            {
                _vertex.data.ChangeColor(Color.OrangeRed);
            }
        }
   


        public void GenerateMaze()
{
            for (int i = 1; i <= (this.x -2) * 2; i += 2)
            {
                for (int j = 1; j <= (y-1) * 2; j +=2)
                {
                    SetSlot(i, j);
                }
            }


            foreach (Cell _cell in myMaze.GetMaze())
            {
                prefab = new GameObjects.Cell(_game);
                prefab.transform.Position = new Vector3(2 * _cell.x, 0, 2 * _cell.y);
                if (dev_show_cells)
                {
                    SetSlotCell(2 * _cell.x, 2 * _cell.y);
                }
                // prefab.transform.Position = new Vector3(2 * _cell.x, 2 * _cell.y, 50);
                //prefab.transform.Rotation = new Vector3(-1.57f, 0, 0);

                prefab.SetWalls(_cell.GetWallStat(2), _cell.GetWallStat(1), _cell.GetWallStat(3), _cell.GetWallStat(0));
                //              Top, Left,
                //prefab.SetWalls(false,true, false,false);
                //Wall Slots
                if (_cell.GetWallStat(2) && _cell.y != y - 1)
                {
                    SetSlot(2 * _cell.x, 2 * _cell.y + 1);
          
                }
                if (_cell.GetWallStat(1) && _cell.x != x-2)
                {
                    SetSlot(2 * _cell.x + 1, 2 * _cell.y);

                }
                //Cells slots
                if (!_cell.GetWallStat(2) && _cell.y != y - 1 && dev_show_cells)
                {
                    SetSlotCell(2 * _cell.x, 2 * _cell.y + 1);

                }
                if (!_cell.GetWallStat(1) && _cell.x != x - 2 && dev_show_cells)
                {
                    SetSlotCell(2 * _cell.x + 1, 2 * _cell.y);

                }


                gameobjects.Push(prefab);
            }


            CreateEdges();
           
        }

        void CreateEdges()
        {
           

            foreach (Cell _cell in myMaze.GetMaze())
            {
               GameHelper.Graph.Vertex<GameObjects.CellSlot> myVertex = GetVertex(new Vector2(2 * _cell.x, 2* _cell.y));


                if (!_cell.GetWallStat(2) && _cell.y != y - 1)
                {
                    GameHelper.Graph.Vertex<GameObjects.CellSlot> myVertex2 = GetVertex(new Vector2(2 * _cell.x, 2 * _cell.y + 1));
                    if (myVertex2 != null)
                    {
                        myGraph.AddEdge(myVertex, myVertex2);
                    }
                    GameHelper.Graph.Vertex<GameObjects.CellSlot> myVertex3 = GetVertex(new Vector2(2 * _cell.x, 2 * _cell.y + 2));
                    myGraph.AddEdge(myVertex2, myVertex3);
                }

                if (!_cell.GetWallStat(1) && _cell.x != x - 2)
                {
                    GameHelper.Graph.Vertex<GameObjects.CellSlot> myVertex2 = GetVertex(new Vector2(2 * _cell.x + 1, 2 * _cell.y));
                    if (myVertex2 != null)
                    {
                        myGraph.AddEdge(myVertex, myVertex2);
                    }
                    GameHelper.Graph.Vertex<GameObjects.CellSlot> myVertex3 = GetVertex(new Vector2(2 * _cell.x + 2, 2 * _cell.y));
                    myGraph.AddEdge(myVertex2, myVertex3);
                }
            }
            Console.WriteLine("Edges: " + myGraph.EdgeCount);
        }

        GameHelper.Graph.Vertex<GameObjects.CellSlot> GetVertex(Vector2 pos)
        {
            foreach (GameHelper.Graph.Vertex<GameObjects.CellSlot> _vertex in myGraph.vertices)
            {
                //Console.WriteLine("Vergleiche: " + _vertex.data.transform.Position.ToString() + " mit " + pos.ToString());
                if (_vertex.data.transform.Position == new Vector3(pos.X, _vertex.data.transform.Position.Y, pos.Y))
                {
                    return _vertex;
                }
            }
            return null;


        }

        void SetSlotCell(float X, float Y)
        {

        
            cellSlot = new GameObjects.CellSlot(_game);
            cellSlot.transform.Position = new Vector3(X, 0.03f, Y);

            cellSlot.transform.Scale = new Vector3(0.9f, 0.9f, 0.9f);
            cellSlot.Name = X.ToString() + "/" + Y.ToString();
            myGraph.CreateVertex(cellSlot).SetPosition(cellSlot.transform.Position);

            gameobjects.Push(cellSlot);

        }
       

        void SetSlot(float X, float Y)
        {
            slot = new GameObjects.Slot(_game);
            slot.transform.Position = new Vector3(X, 1.03f, Y);
            
            slot.transform.Scale = new Vector3(0.9f, 0.9f, 0.9f);
            slot.Name = X.ToString() + "/" + Y.ToString();
            gameobjects.Push(slot);
            
        }




        public override void SceneObjects()
        {

            base.SceneObjects();
        }

    }
}
