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

        int lTicks = 0;
       
        public int live;
        public PlayerControler player;
        List<CellSlot> myWay = new List<CellSlot>();

        public Color myColor;

        public float speed = 50;


        public List<MazeGenerator.Cell> way;
        Vector3 LerpPosition;
    
        public Guard(MazeGame game, PlayerControler _player)
            : base(game, game.mainCamera)
        {
            this.game = game;
            renderer = new Render3D(this, "Model/Guard");
            transform.Scale = new Vector3(0.4f, 0.4f, 0.4f);
            transform.Position = GetPosition(lTicks);
            CanClick = true;
            this.player = _player;
            live = Config.GuardLiveRunner;
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
            lTicks++;
            LerpPosition = GetPosition(lTicks);
            renderer.color = player.myColor.ToVector3();
            //this.transform.Position = GetPosition(lTicks);
            //Console.WriteLine("lticks: " + lTicks);
            base.Tick(sender, e);
        }


        public override void Update(GameTime gameTime)
        {
            //if (lTicks > 0)
            //{
            //    this.transform.Position = Vector3.Lerp(GetPosition(lTicks - 1), GetPosition(lTicks), 0.5f);
            //}
            //else
            //{



            this.transform.Position = Vector3.Lerp(transform.Position, LerpPosition, 0.8f);
            
            //}

        
            

            

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

           

        Vector3 GetPosition(int i)
        {
           

            if (myWay.Count > 0)
            {
                


                if (i >= myWay.Count -1)
                {
                    GameObject.Destroy(this);
                    return new Vector3(0, 0, 0);
                }
                myWay[i].EnterSlot(this);
                if (i >= 1)
                {
                    myWay[i - 1].LeaveSlot(this);
                }
               

                return new Vector3(myWay[i].transform.Position.X, 0, myWay[i].transform.Position.Z);
            }
            return new Vector3(0,0,0);
        }
    }
}
