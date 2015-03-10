using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameHelper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MTDMG.GameObjects
{
    /// <summary>
    /// Players Base
    /// </summary>
   public class Base : GameObject
    {

       List<CellSlot> solutionWay;
        bool dev_colo = false;
        public PlayerControler player;
        public int guardCount = 20;
        bool isSpwaned = false;
       public CellSlot myCell;
        GameObjects.Guard guard;
        public int Health;
       //GuardColor
        public Color guardColor;
        MazeGame game;


        //Guard types
        GameObjects.Guards.Runner Runner;
        GameObjects.Guards.Searcher Searcher;
        GameObjects.Guards.Destroyer Destroyer;
        public Base(MazeGame game, PlayerControler player) : base(game, game.mainCamera)
        {
            this.game = game;
            CanClick = true;
            this.player = player;
            renderer = new Render3D(this, "Cube");
            transform.Scale = new Vector3(0.1f, 0.1f, 0.1f);
            renderer.color = player.myColor.ToVector3();
            Health = Config.BaseHealth;
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
        public void GetDamage()
        {
            Health--;
            if (Health <= 0)
            {
                Dead(); 
            }
        }

        public void Dead()
        {
            Console.WriteLine("Spieler ist tot");
            Destroy(this);
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
            
           
        }

        public void SpawnSearcher()
        {
            if (player.RessourceCoins > Config.GuardCostSpion)
            {

                if (Config.AStarIsFinish)
                {
                    Searcher = new Guards.Searcher(game, player);
                    Searcher.transform.Position = this.transform.Position;
                    game.myScene.Instatiate(Searcher);
                    Searcher.renderer.color = guardColor.ToVector3();
                    player.RessourceCoins -= Config.GuardCostSpion;
                }
            }
        }


        public void SpawnRunner()
        {
            if (player.RessourceCoins > Config.GuardCostRunner)
            {

                if (Config.AStarIsFinish)
                {
                    Runner = new Guards.Runner(game, player);
                    Runner.transform.Position = this.transform.Position;
                    game.myScene.Instatiate(Runner);
                    Runner.renderer.color = guardColor.ToVector3();
                    player.RessourceCoins -= Config.GuardCostRunner;
                }
            }
        }
        public void SpawnDestroyer()
        {
            if (player.RessourceCoins > Config.GuardCostDestroyer)
            {
                if (Config.AStarIsFinish)
                {
                    Console.WriteLine("asdasdasd");
                    Destroyer = new Guards.Destroyer(game, player);
                    Destroyer.transform.Position = this.transform.Position;
                    game.myScene.Instatiate(Destroyer);
                    Destroyer.renderer.color = guardColor.ToVector3();
                    player.RessourceCoins -= Config.GuardCostDestroyer;
                }
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
                   
            return myWay;
        }


        public override void MouseClick()
        {
            if (((Scenes.StartScene)game.myScene).GetPlayerController() != null && ((Scenes.StartScene)game.myScene).GetPlayerController() == player)
                ((Scenes.StartScene)game.myScene).GetPlayerController().OpenBaseMenu();
        }
            


    }
}
