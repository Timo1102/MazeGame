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

namespace MTDMG.GameObjects 
{
   public class Slot : GameObject
    {

        MazeGame _game;
        public GameObjects.Tower tower;
        bool isUsed = false;
        long playerControlerNumber = 0;
        public Slot(MazeGame game)
            : base(game, game.mainCamera)
        {
            _game = game;
           renderer = new Render3D(this, "Model/Slot");
           renderer.color = Color.Gray.ToVector3();
          ((Render3D)renderer).myMeshes.Clear();
          ((Render3D)renderer).myMeshes.Add(((Render3D)renderer).model.Meshes[0]);
           CanClick = true;
        }

        public override void MouseClick()
        {
            if (((Scenes.StartScene)game.myScene).GetPlayerController() != null)
            ((Scenes.StartScene)game.myScene).GetPlayerController().OpenCellSlotMenu(this);



            base.MouseClick();
        }

        public override void MouseClick(long number)
        {
            if (((Scenes.StartScene)game.myScene).GetPlayerController(number) != null)
            {
                playerControlerNumber = number;
                ((Scenes.StartScene)game.myScene).GetPlayerController(number).OpenCellSlotMenu(this);
            }

      
            base.MouseClick(number);
        }

        public override void MouseReleased()
        {
            Console.WriteLine("asdasd released");
            if (playerControlerNumber != 0)
            {
                ((Scenes.StartScene)game.myScene).GetPlayerController(playerControlerNumber).CellSlotMenu.Close();
            }
            else
            {
                ((Scenes.StartScene)game.myScene).GetPlayerController().CellSlotMenu.Close();
            }
            base.MouseReleased();
        }

        public void DestroyWall()
        {

            ((Scenes.StartScene)game.myScene).SetSlotCell(this.transform.Position.X, this.transform.Position.Z);
            foreach(var _cell in game.Components)
            {
                

                if (_cell.GetType() == typeof(Cell))
                {
                    

                    GameHelper.Graph.Vertex<GameObjects.CellSlot> myVertex = ((Scenes.StartScene)game.myScene).GetVertex(new Vector2(this.transform.Position.X, this.transform.Position.Z));
                    GameHelper.Graph.Vertex<GameObjects.CellSlot> myVertex2 = null;


                     //((Cell)_cell).transform.Position = new Vector3(((Cell)_cell).transform.Position.X, 100, ((Cell)_cell).transform.Position.Z);
                    Cell _dCell = ((Cell)_cell);
                    if (_dCell.transform.Position == new Vector3(this.transform.Position.X - 1, 0, this.transform.Position.Z))
                    {
                        _dCell.RemoveMesh(2);
                         myVertex2 = ((Scenes.StartScene)game.myScene).GetVertex(new Vector2(_dCell.transform.Position.X, _dCell.transform.Position.Z));


                    }
                    if (_dCell.transform.Position == new Vector3(this.transform.Position.X + 1, 0, this.transform.Position.Z))
                    {
                        _dCell.RemoveMesh(3);
                        myVertex2 = ((Scenes.StartScene)game.myScene).GetVertex(new Vector2(_dCell.transform.Position.X, _dCell.transform.Position.Z));
                    }
                    if (_dCell.transform.Position == new Vector3(this.transform.Position.X, 0, this.transform.Position.Z -1 ))
                    {
                       _dCell.RemoveMesh(1);
                       myVertex2 = ((Scenes.StartScene)game.myScene).GetVertex(new Vector2(_dCell.transform.Position.X, _dCell.transform.Position.Z));
                    }
                    if (_dCell.transform.Position == new Vector3(this.transform.Position.X, 0, this.transform.Position.Z + 1))
                    {
                       _dCell.RemoveMesh(4);
                        myVertex2 = ((Scenes.StartScene)game.myScene).GetVertex(new Vector2(_dCell.transform.Position.X, _dCell.transform.Position.Z));
                    }

                    if (_dCell.transform.Position == new Vector3(this.transform.Position.X - 1, 0, this.transform.Position.Z - 1))
                    {
                       _dCell.RemoveMesh(5);
                       
                    }
                    if (_dCell.transform.Position == new Vector3(this.transform.Position.X - 1, 0, this.transform.Position.Z + 1))
                    {
                        _dCell.RemoveMesh(8);
                    }

                    if (_dCell.transform.Position == new Vector3(this.transform.Position.X + 1, 0, this.transform.Position.Z - 1))
                    {
                     _dCell.RemoveMesh(7);    
                    }
                    if (_dCell.transform.Position == new Vector3(this.transform.Position.X + 1, 0, this.transform.Position.Z + 1))
                    {
                         _dCell.RemoveMesh(6);
                    }

                    if (myVertex2 != null)
                    {
                        ((Scenes.StartScene)game.myScene).myGraph.AddEdge(myVertex, myVertex2);
                    }
                }
            }

            
        }

      
    }
}
