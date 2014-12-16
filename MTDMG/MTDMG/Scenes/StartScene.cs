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
       public GameObjects.background bg;
   
       public Maze myMaze;



        public StartScene(Game game) : base(game)
        {
            name = "StartScene";

            bg = new GameObjects.background(game);
            bg.transform.Position = new Vector3(0, 0, 100);
            bg.transform.Scale = new Vector3(2, 2, 2);
            
            gameobjects.Add(bg);

            myMaze = new Maze(5, 5);
            GenerateMaze();
        }

        public void GenerateMaze()
        {
            foreach(Cell cell in myMaze.GetMaze())
            {
                if (cell.isSoluteionCell)
                {
                 //   bg = new GameObjects.background(game);
                 //   bg.Position = new Vector3(cell.x * 20,  cell.y * 20, 0);
                 //   gameobjects.Add(bg);
                }
            }
        }


        public override void SceneObjects()
        {

            base.SceneObjects();
        }

    }
}
