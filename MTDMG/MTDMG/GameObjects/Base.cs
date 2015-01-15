﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameHelper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MTDMG.GameObjects
{
   public class Base : GameObject
    {

       List<CellSlot> solutionWay;
        bool dev_colo = false;
        public PlayerControler player;
        public int guardCount = 20;
        bool isSpwaned = false;
       public CellSlot myCell;
        GameObjects.Guard guard;
        public Color guardColor;
        MazeGame game;
        public Base(MazeGame game, PlayerControler player) : base(game, game.mainCamera)
        {
            this.game = game;
            CanClick = true;
            this.player = player;
            renderer = new Render3D(this, "Cube");
            transform.Scale = new Vector3(0.1f, 0.1f, 0.1f);
            renderer.color = player.myColor.ToVector3();
        }

        public override void Tick(object sender, EventArgs e)
        {
            isSpwaned = false;
            if (((Scenes.StartScene)game.myScene).GetOpposit(player).myBase != null && dev_colo)
            {
                SpawnTarget(((Scenes.StartScene)game.myScene).GetVertex(new Vector2(((Scenes.StartScene)game.myScene).GetOpposit(player).myBase.transform.Position.X, ((Scenes.StartScene)game.myScene).GetOpposit(player).myBase.transform.Position.Z)).data);
               // SpawnTarget(((Scenes.StartScene)game.myScene).GetVertex(new Vector2(0, 0)).data);


            }


            base.Tick(sender, e);
        }


        public override void Update(GameTime gameTime)
        {
            if (((Scenes.StartScene)game.myScene).GetPlayerController() == player && Keyboard.GetState().IsKeyDown(Keys.S) )
            {
               // SpawnTarget(((Scenes.StartScene)game.myScene).GetVertex(new Vector2(((Scenes.StartScene)game.myScene).GetOpposit(player).myBase.transform.Position.X, ((Scenes.StartScene)game.myScene).GetOpposit(player).myBase.transform.Position.Z)).data);
             
            }
            base.Update(gameTime);
        }

        public void SpawnTarget(CellSlot Goal)
        {
            if (player.RessourceCoins > Config.GuardCostRunner)
            {
                player.RessourceCoins -= Config.GuardCostRunner;
                guard = new GameObjects.Guard(game, player);
                guard.transform.Position = new Vector3(this.transform.Position.X, 0, this.transform.Position.Z);

                game.myScene.Instatiate(guard);


                guard.renderer.color = guardColor.ToVector3();
                guard.SetWay(GetWay(Goal));
            }

        }

       

        public List<CellSlot> GetWay(CellSlot Goal)
        {
           solutionWay = new List<CellSlot>();
           
            GameHelper.Graph.Vertex<GameObjects.CellSlot> VertexStart = ((Scenes.StartScene)game.myScene).GetVertex(new Vector2(this.transform.Position.X, this.transform.Position.Z));
            GameHelper.Graph.Vertex<GameObjects.CellSlot> VertexEnd = ((Scenes.StartScene)game.myScene).GetVertex(new Vector2(Goal.transform.Position.X, Goal.transform.Position.Z));


             List<GameHelper.Graph.Vertex<GameObjects.CellSlot>> sad = ((Scenes.StartScene)game.myScene).myGraph.Astern(VertexStart, VertexEnd);
             



                    foreach (GameHelper.Graph.Vertex<GameObjects.CellSlot> _vertex in sad)
                    {
                        solutionWay.Add(_vertex.data);
                    }
                    List<GameObjects.CellSlot> myWay = new List<GameObjects.CellSlot>();
                    myWay.Clear();
                    for (int i = solutionWay.Count - 1; i >= 0; i--)
                    {
                        myWay.Add(solutionWay[i]);
                    }
                    sad.Clear();
                    solutionWay.Clear();
                    Console.WriteLine("Start to End: " + VertexStart.data.transform.Position + " zu " + VertexEnd.data.transform.Position);

            return myWay;
        }


        public override void MouseClick()
        {
            //solutionWay.Clear();
            if (((Scenes.StartScene)game.myScene).GetOpposit(player).myBase != null)
            {
                if (!isSpwaned)
                {
                    SpawnTarget(((Scenes.StartScene)game.myScene).GetVertex(new Vector2(((Scenes.StartScene)game.myScene).GetOpposit(player).myBase.transform.Position.X, ((Scenes.StartScene)game.myScene).GetOpposit(player).myBase.transform.Position.Z)).data);
                    isSpwaned = true;
                }
            }
            base.MouseClick();
        }
            


    }
}
