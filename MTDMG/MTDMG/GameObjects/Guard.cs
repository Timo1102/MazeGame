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
    class Guard : GameObject
    {
        Timer lTimer = new Timer();
        int lTicks = 1;
        static uint MAX_TICKS = 50;


        public float speed = 50;

        MyGame game;
        public List<MazeGenerator.Cell> way;
        int i = 0;
        public Guard(MyGame game)
            : base(game, game.mainCamera)
        {
            this.game = game;
            renderer = new Render3D(this, "Model/Guard");
            transform.Scale = new Vector3(0.4f, 0.4f, 0.4f);
            
        }

        public  void InitTimer()
        {
           
            lTimer = new Timer();
            lTimer.Interval = 500;
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
            this.transform.Position = Vector3.Lerp(transform.Position, GetPosition(lTicks), 0.5f);
            //}

        
            

            

            base.Update(gameTime);
        }

           

        Vector3 GetPosition(int i)
        {
            if (game.startscene.solutionWay.Count > 0)
            {
                int k = game.startscene.solutionWay.Count - i;
                if (i >= game.startscene.solutionWay.Count)
                {
                    this.Dispose();
                }
                int h = k;

                return new Vector3(2 * game.startscene.solutionWay[h].x-1, 0, 2 * game.startscene.solutionWay[h].y-1);
            }
            return new Vector3(0,0,0);
        }
    }
}
