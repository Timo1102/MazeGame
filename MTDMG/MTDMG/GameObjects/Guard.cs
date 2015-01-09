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
        Timer lTimer = new Timer();
        int lTicks = 1;
        static uint MAX_TICKS = 500;
        public int live = 10;
        public PlayerControler player;
        List<CellSlot> myWay = new List<CellSlot>();

        public float speed = 50;

        MyGame game;
        public List<MazeGenerator.Cell> way;
        
        int i = 0;
        public Guard(MyGame game, PlayerControler _player)
            : base(game, game.mainCamera)
        {
            this.game = game;
            renderer = new Render3D(this, "Model/Guard");
            transform.Scale = new Vector3(0.4f, 0.4f, 0.4f);
            CanClick = true;
            this.player = _player;
        }

        public void GetDamage(int damage)
        {
            live -= damage;
            Console.WriteLine("restschaden: " + live);
            if (live <= 0)
            {
                Dead();
            }
        }

        public void Dead()
        {
            Console.WriteLine("Dead");
            
            Dispose();
        }


        public  void InitTimer()
        {
           
            lTimer = new Timer();
            lTimer.Interval = 250;
            lTimer.Elapsed += new ElapsedEventHandler(Timer_Tick);
            lTimer.Start();
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            lTicks++;
            
            if (lTicks <= MAX_TICKS)
            {
               
                
                //do whatever you want to do
            }
        }

        public override void Update(GameTime gameTime)
        {
            //if (lTicks > 0)
            //{
            //    this.transform.Position = Vector3.Lerp(GetPosition(lTicks - 1), GetPosition(lTicks), 0.5f);
            //}
            //else
            //{

            

            this.transform.Position = Vector3.Lerp(transform.Position, GetPosition(lTicks), 0.8f);
            //}

        
            

            

            base.Update(gameTime);
        }

        public void SetWay(List<CellSlot> _list)
        {
            myWay = _list;
        }

        public override void MouseClick()
        {
            game.startscene.ResetCellSlotColor();

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
                    this.Dispose();
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
