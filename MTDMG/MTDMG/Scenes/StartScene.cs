﻿using System;
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
    /// <summary>
    /// StartSzene
    /// </summary>
   public class StartScene : scene
    {

       public GameObjects.Cell bg;
       GameObjects.Cell prefab;
       GameObjects.Slot slot;
       GameObjects.CellSlot cellSlot;
      GameObjects.Base myBase = null;
       GameObjects.Menu button;
     public GameHelper.Graph.Graph<GameObjects.CellSlot> myGraph;

      bool dev_show_cells = true;


       public List<GameObjects.CellSlot> solutionWay;
       public Maze myMaze;
       int x = 19;
       int y = 11;
       MazeGame _game;
       public GameObjects.PlayerControler player1;
       public GameObjects.PlayerControler player2;


        public StartScene(MazeGame game) : base((Game)game)
       {
           myGraph = new GameHelper.Graph.Graph<GameObjects.CellSlot>();
           this._game = game;
           myMaze = new Maze(x, y);
           game.mainCamera.transform.Position = new Vector3(x - 2, 27, y - 1);
           game.mainCamera.transform.Rotation = new Vector3(1.57f, 0, 0);

            name = "StartScene";

           GenerateMaze();

            player1 = new GameObjects.PlayerControler(game, Keys.G, 1);
            player2 = new GameObjects.PlayerControler(game, Keys.H, 2);

            player1.myColor = Config.Player1;
            player2.myColor = Config.Player2;

            solutionWay = new List<GameObjects.CellSlot>();

          //List<GameHelper.Graph.Vertex<GameObjects.CellSlot>> sad =  myGraph.GetWay(GetVertex(new Vector2(myBase.transform.Position.X, myBase.transform.Position.Z)));
           

        }



        public void Start()
        {
            Console.WriteLine("asd");

          
        }
       /// <summary>
       /// Get Opposit Player
       /// </summary>
       /// <param name="myPlayer"></param>
       /// <returns>The opposit</returns>
        public GameObjects.PlayerControler GetOpposit(GameObjects.PlayerControler myPlayer)
        {
            if (myPlayer == player1)
            {
                return player2;
            }
            else
            {
                return player1;
            }

        }

       /// <summary>
       /// Returns the PlayerController
       /// </summary>
       /// <returns></returns>
        public GameObjects.PlayerControler GetPlayerController()
        {
            if (Keyboard.GetState().IsKeyDown(player1.myKey))
            {
                return player1;
            }
            if (Keyboard.GetState().IsKeyDown(player2.myKey))
            {
                return player2;
            }

            return null;
        }
       /// <summary>
       /// Gets the player by tag ID
       /// </summary>
       /// <param name="id"></param>
       /// <returns>The Player</returns>
        public GameObjects.PlayerControler GetPlayerController(long id)
        {
            if (player1.ID == id)
            {
                return player1;
            }
            if (player2.ID == id)
            {
                return player2;
            }
            return null;
        }


        public void DestroyWall(GameObjects.Slot pos)
        {
            GameObject.Destroy(pos);
        }

        public void SpawnBase(GameObjects.CellSlot cell, long number)
        {
            if (GetPlayerController(number) != null)
            {
                GetPlayerController(number).SpwanBase(cell);
            }

        }

        public void SpawnBase(GameObjects.CellSlot cell)
        {
           


            if (GetPlayerController() != null)
            {
                GetPlayerController().SpwanBase(cell);
            }

        }
       /// <summary>
       /// Reset the CellSlot Color
       /// </summary>
        public void ResetCellSlotColor()
        {
            foreach (GameHelper.Graph.Vertex<GameObjects.CellSlot> _vertex in myGraph.vertices)
            {
                _vertex.data.ChangeColor(Config.CellColor);
            }
        }

        public void SpwanTower(Vector3 pos)
        {
            //InstatiateTower(new Vector2(pos.X, pos.Z), player1);
        }


       /// <summary>
       /// Gets the Maze Data and Create the Maze Walls
       /// </summary>
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
                Instatiate(prefab);

                //gameobjects.Add(prefab);
            }


            CreateEdges();
           
        }
       /// <summary>
       /// Create Edges for the Graph
       /// </summary>
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
        }

       public GameHelper.Graph.Vertex<GameObjects.CellSlot> GetVertex(Vector2 pos)
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
       /// <summary>
       /// Create a slot for the Walls slots
       /// </summary>
       /// <param name="X"></param>
       /// <param name="Y"></param>
       public void SetSlotCell(float X, float Y)
        {

        
            cellSlot = new GameObjects.CellSlot(_game);
            cellSlot.transform.Position = new Vector3(X, 0.03f, Y);

            cellSlot.transform.Scale = new Vector3(0.9f, 0.9f, 0.9f);
            cellSlot.Name = X.ToString() + "/" + Y.ToString();
            myGraph.CreateVertex(cellSlot).SetPosition(cellSlot.transform.Position);
            Instatiate(cellSlot);
           // gameobjects.Add(cellSlot);
            
        }
       
       /// <summary>
       /// Creates the Slot for the way cells
       /// </summary>
       /// <param name="X"></param>
       /// <param name="Y"></param>
        void SetSlot(float X, float Y)
        {
            slot = new GameObjects.Slot(_game);
            slot.transform.Position = new Vector3(X, 1.03f, Y);
            
            slot.transform.Scale = new Vector3(0.9f, 0.9f, 0.9f);
            slot.Name = X.ToString() + "/" + Y.ToString();

            //InstatiateTower(new Vector2(X, Y), player2);
            Instatiate(slot);
           // gameobjects.Add(slot);
            
        }

       /// <summary>
       /// Instatiate a GameObject
       /// </summary>
       /// <param name="prefab"></param>
 
        public override void Instatiate(GameObject prefab)
        {
            if (prefab != null)
                _game.myScene = this;
            base.Instatiate(prefab);
        }

        public override void SceneObjects()
        {
            
            base.SceneObjects();
        }

       public void InstatiateTower(Vector2 pos, GameObjects.PlayerControler _player)
       {
           Console.WriteLine("genau diese methode wird aufgerufen");
           GameObjects.Tower _tower = new GameObjects.Tower(_game, _player);
           
           _tower.transform.Position = new Vector3(pos.X, 1.03f, pos.Y);
           this.gameobjects.Add(_tower);

          // Instatiate(_tower);
           
       }


    }
}
