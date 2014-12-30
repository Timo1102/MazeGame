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
      GameObjects.Base myBase;


      bool dev_show_cells = false;


       public List<MazeGenerator.Cell> solutionWay;
       public Maze myMaze;
       int x = 35;
       int y = 21;
       MyGame _game;

        public StartScene(MyGame game) : base(game)
       {
          
           this._game = game;
           myMaze = new Maze(x, y);
           game.mainCamera.transform.Position = new Vector3(x - 2, 52, y - 1);
           game.mainCamera.transform.Rotation = new Vector3(1.57f, 0, 0);
           GenerateMaze();
            name = "StartScene";


   



            solutionWay = myMaze.solutionWay;


            Instatiate(myBase = new GameObjects.Base(game));
            myBase.InitTimer();
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


            

           
        }




        void SetSlotCell(float X, float Y)
        {
            cellSlot = new GameObjects.CellSlot(_game);
            cellSlot.transform.Position = new Vector3(X, 0.03f, Y);

            cellSlot.transform.Scale = new Vector3(0.9f, 0.9f, 0.9f);
            cellSlot.Name = X.ToString() + "/" + Y.ToString();
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
