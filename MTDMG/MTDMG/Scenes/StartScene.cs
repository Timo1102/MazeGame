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
       public Maze myMaze;

       MyGame _game;

        public StartScene(MyGame game) : base(game)
        {
            name = "StartScene";
            this._game = game;
            bg = new GameObjects.Cell(game);
            bg.transform.Position = new Vector3(0, 0, 100);
            bg.transform.Scale = new Vector3(1, 1, 1);

            
            

            myMaze = new Maze(10, 11);

            game.mainCamera.transform.Position = new Vector3(5, 10, 5);
            game.mainCamera.transform.Rotation = new Vector3(1.3f, 0, 0);
            
            GenerateMaze();
        }

        public void GenerateMaze()
        {
            foreach(Cell _cell in myMaze.GetMaze())
            {
                prefab = new GameObjects.Cell(_game);
                prefab.transform.Position = new Vector3(2 * _cell.x, 0, 2 * _cell.y);


                prefab.SetWalls(_cell.GetWallStat(2), _cell.GetWallStat(1), _cell.GetWallStat(3), _cell.GetWallStat(0));
                //              Top, Left,
                //prefab.SetWalls(false,true, false,false);
                gameobjects.Add(prefab);
            }

           
        }


        public override void SceneObjects()
        {

            base.SceneObjects();
        }

    }
}
