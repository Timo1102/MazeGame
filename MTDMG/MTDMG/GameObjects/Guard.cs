using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameHelper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Timers;

namespace MTDMG.GameObjects
{
    public class Guard : GameObject
    {
        //Timer lTimer = new Timer();

        public enum States
        {
            Start,
            Move, 
            Attack,
            SearchField,
            SearchPash
        }

        public States myState;

        int lTicks = 1;
       
        public int live;
        public PlayerControler player;
        List<CellSlot> myWay = new List<CellSlot>();

        List<CellSlot> wasThere = new List<CellSlot>();
        GameHelper.Graph.Graph<CellSlot> newGraph;
        public Color myColor;

        public float speed = 50;
        GameHelper.Graph.Vertex<CellSlot> LastPosition = null;

        public List<MazeGenerator.Cell> way;
        Vector3 LerpPosition;
        public  GameHelper.Graph.Vertex<CellSlot> myVertex;
        CellSlot startSlot;
        Vector3 nextPosition;

        bool hasPath = false;
        bool canMove = false;
      
        

        public Guard(MazeGame game, PlayerControler _player)
            : base(game, game.mainCamera)
        {
            this.game = game;

            CanClick = true;
            this.player = _player;
            live = Config.GuardLiveRunner;
            this.transform.Position = _player.myBase.transform.Position;
            myVertex = GetVertex(new Vector2(this.transform.Position.X, this.transform.Position.Z));
            myState = States.Start;
        }

        public void GetWay(GameHelper.Graph.Graph<CellSlot> myGraph)
        {

        }

        public virtual void newField()
        {
            myState = States.Move;
        }

        public Vector3 GetRandomPosition()
        {
            Vector3 newPosition;

            if (myVertex.connectedVertices.Count == 1)
            {
                //Dann überprüfe ob schon da gewesen, wenn nicht hingehen
                newPosition = myVertex.connectedVertices[0].data.transform.Position;
                LastPosition = myVertex;
                myVertex = myVertex.connectedVertices[0];
            }
            else
            {
                //Gucke ob schon mal bei einem gewesen
                int rnd;

                if (LastPosition != null)
                {
                    do
                    {

                        rnd = new Random().Next(0, myVertex.connectedVertices.Count);
                        newPosition = myVertex.connectedVertices[rnd].data.transform.Position;

                    } while (LastPosition == myVertex.connectedVertices[rnd]);
                }
                else
                {
                    rnd = new Random().Next(0, myVertex.connectedVertices.Count);
                    newPosition = myVertex.connectedVertices[rnd].data.transform.Position;

                }
               LastPosition = myVertex;
               myVertex = myVertex.connectedVertices[rnd];
            }
            newField();
            return newPosition;
        }
        public GameHelper.Graph.Vertex<GameObjects.CellSlot> GetVertex(GameHelper.Graph.Graph<CellSlot> graph, Vector2 pos)
        {
            foreach (GameHelper.Graph.Vertex<GameObjects.CellSlot> _vertex in graph.vertices)
            {
                //Console.WriteLine("Vergleiche: " + _vertex.data.transform.Position.ToString() + " mit " + pos.ToString());
                if (_vertex.data.transform.Position == new Vector3(pos.X, _vertex.data.transform.Position.Y, pos.Y))
                {
                    return _vertex;
                }
            }
            return null;


        }


        public GameHelper.Graph.Vertex<CellSlot> GetVertex(Vector2 pos)
        {
            return ((Scenes.StartScene)game.myScene).GetVertex(pos);
        }


        public void GetDamage(int damage)
        {
            live -= damage;
            Console.WriteLine("leben: " + live);
           if (live <= 0)
            {
                Dead();
            }
        }

        public void Dead()
        {
          
            GameObject.Destroy(this);
        }
        public override void Tick(object sender, EventArgs e)
        {
            renderer.color = player.myColor.ToVector3();

            switch (myState)
            {
                case States.Start:
                    start();
                    break;
                case States.Attack:
                    Attack();
                    break;
                case States.Move:
                    Move();
                    break;
                case States.SearchField:
                    SearchField();
                    break;
                case States.SearchPash:
                    SearchPath();
                    break;
            }


            //this.transform.Position = GetPosition(lTicks);
            //Console.WriteLine("lticks: " + lTicks);
            base.Tick(sender, e);
        }


        public override void Update(GameTime gameTime)
        {
            if (canMove)
            {
                this.transform.Position = Vector3.Lerp(transform.Position, nextPosition, 0.8f);   
            }
            if (this.transform.Position == nextPosition)
            {
                canMove = false;  
            }
            base.Update(gameTime);
        }

        public void SetWay(List<CellSlot> _list)
        {
            myWay = _list;
        }

        public override void MouseClick()
        {
            ((Scenes.StartScene)game.myScene).ResetCellSlotColor();
            foreach (CellSlot _slot in myWay)
            {
                _slot.ChangeColor(Color.YellowGreen);
            }
            base.MouseClick();
        }

        public virtual void start()
        {
            myState = States.SearchPash;
        }

        public virtual void SearchField()
        {
            LerpPosition = GetRandomPosition();
            
        }
        public virtual void SearchPath()
        {
            Console.WriteLine("Search Path");
            if (player.playerGraph.vertices.Count > 0)
            {
                FindPath(newGraph.vertices[new Random().Next(0, newGraph.vertices.Count)].data);
            }
            else
            {
                myState = States.SearchField;
            }
        }
        public virtual void Attack()
        {
            Console.WriteLine("Attack");
        }
        public virtual void Move()
        {
            if (hasPath)
            {
                lTicks++;
                nextPosition = GetPosition(lTicks);
                Console.WriteLine("neue Position: " + nextPosition + "  l: " + lTicks);
                


            }
            else
            {
                nextPosition = LerpPosition;
                myState = States.SearchField;
            }
            canMove = true;
        }


       public void FindPath(CellSlot goal)
        {
            newGraph = new GameHelper.Graph.Graph<CellSlot>();
            newGraph = (GameHelper.Graph.Graph<CellSlot>)player.playerGraph.Clone();

            Console.WriteLine("Werde ein Path finden: " + player.playerGraph.vertices.Count + " edges: " + player.playerGraph.EdgeCount);
            if (newGraph.vertices.Count > 2)
            {
                
                
               // GameHelper.Graph.Vertex<CellSlot> v1 = player.playerGraph.vertices[new Random().Next(0, player.playerGraph.vertices.Count)];

                //GameHelper.Graph.Vertex<CellSlot> v1 = ((Scenes.StartScene)game.myScene).GetVertex(myVertex.data.transform.ToVector2());
                //GameHelper.Graph.Vertex<CellSlot> v2 = ((Scenes.StartScene)game.myScene).GetVertex(goal.transform.ToVector2());

                //GameHelper.Graph.Vertex<CellSlot> v1 = GetVertex(this.transform.ToVector2());
                //GameHelper.Graph.Vertex<CellSlot> v2 = GetVertex(goal.transform.ToVector2());

                GameHelper.Graph.Vertex<CellSlot> v1 = GetVertex(newGraph, this.transform.ToVector2());
                GameHelper.Graph.Vertex<CellSlot> v2 = GetVertex(newGraph, goal.transform.ToVector2());



                //List<GameHelper.Graph.Vertex<GameObjects.CellSlot>> sad = ((Scenes.StartScene)game.myScene).myGraph.Astern(v1, v2);
                List<GameHelper.Graph.Vertex<GameObjects.CellSlot>> sad = newGraph.Astern(v1,v2);

                List<CellSlot> solutionWay = new List<CellSlot>();
                foreach (GameHelper.Graph.Vertex<GameObjects.CellSlot> _vertex in sad)
                {
                    solutionWay.Add(_vertex.data);
                }
                myWay.Clear();
                for (int i = solutionWay.Count - 1; i >= 0; i--)
                {
                    myWay.Add(solutionWay[i]);
                }
                Console.WriteLine("myWay: " + myWay.Count + " sol: " + solutionWay.Count + " sad: " + sad.Count );
                sad.Clear();
                solutionWay.Clear();
                hasPath = true;
                newGraph = null;
                myState = States.Move;
            }
            else
            {
                myState = States.SearchField;
            }
        }



        Vector3 GetPosition(int i)
        {
            Console.WriteLine("myWay: " + myWay.Count);
          
            if (myWay.Count > 0 && i < myWay.Count)
            {



                if (i >= myWay.Count - 1)
                {
                    hasPath = false;
                    lTicks = 0;
                    myState = States.Attack;
                }
                else
                {
                    myWay[i].EnterSlot(this);
                }
                if (i >= 1)
                {
                    myWay[i - 1].LeaveSlot(this);
                }

                myVertex = GetVertex(new Vector2(myWay[i].transform.Position.X, myWay[i].transform.Position.Z));
                return new Vector3(myWay[i].transform.Position.X, 0, myWay[i].transform.Position.Z);
            }
            myState = States.SearchField;
            return new Vector3(0,0,0);
        }
    }
}
