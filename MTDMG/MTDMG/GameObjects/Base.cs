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
        bool dev_colo = false;

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
            lTimer.Interval = 250;
            lTimer.Elapsed += new ElapsedEventHandler(Timer_Tick);
            lTimer.Start();
        }

        void Timer_Tick(object sender, EventArgs e)
        {
   
        }

        public void SpawnTarget(List<CellSlot> _way)
        {
            
            guard = new GameObjects.Guard(game);
            guard.transform.Position = new Vector3(0, 0, 0);
            game.startscene.Instatiate(guard);
            guard.SetWay(_way);
            if (dev_colo)
            {
                guard.renderer.color = Color.White.ToVector3();
                dev_colo = false;
            }
            else
            {
                guard.renderer.color = Color.Black.ToVector3();
                dev_colo = true;
            }

            guard.InitTimer();
            

        }
    }
}
