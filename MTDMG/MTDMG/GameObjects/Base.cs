using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameHelper;
using Microsoft.Xna.Framework;
using System.Timers;
namespace MTDMG.GameObjects
{
    class Base : GameObject
    {

        Timer lTimer = new Timer();
        int lTicks = 0;
        static uint MAX_TICKS = 50;


        public int guardCount = 20;
        GameObjects.Guard guard;

        MyGame game;
        public Base(MyGame game) : base(game, game.mainCamera)
        {
            this.game = game;
            transform.Position = new Vector3(0, 0, 0);

        }
        public void InitTimer()
        {

            lTimer = new Timer();
            lTimer.Interval = 500;
            lTimer.Elapsed += new ElapsedEventHandler(Timer_Tick);
            lTimer.Start();
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            lTicks++;
            if (lTicks <= guardCount)
            {

                SpawnTarget();
                //do whatever you want to do
            }
        }

        public void SpawnTarget()
        {

            guard = new GameObjects.Guard(game);
            guard.transform.Position = new Vector3(0, 0, 0);
            guard.InitTimer();
            game.startscene.Instatiate(guard);

        }
    }
}
