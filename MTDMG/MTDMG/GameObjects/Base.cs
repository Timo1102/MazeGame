using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameHelper;
using Microsoft.Xna.Framework;
using System.Timers;
namespace MTDMG.GameObjects
{
   public class Base : GameObject
    {

        Timer lTimer = new Timer();
        int lTicks = 0;
        static uint MAX_TICKS = 50;
        bool dev_colo = false;
        public PlayerControler player;
        public int guardCount = 20;
        GameObjects.Guard guard;
        public Color guardColor;
        MazeGame game;
        public Base(MazeGame game, PlayerControler player) : base(game, game.mainCamera)
        {
            this.game = game;
            
            this.player = player;
            renderer = new Render3D(this, "Cube");
            transform.Scale = new Vector3(0.1f, 0.1f, 0.1f);
            renderer.color = player.myColor.ToVector3();
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
            
            guard = new GameObjects.Guard(game, player);
            guard.transform.Position = new Vector3(this.transform.Position.X, 0, this.transform.Position.Z);
           
            game.myScene.Instatiate(guard);

          
            guard.renderer.color = guardColor.ToVector3();
            guard.SetWay(_way);
            guard.InitTimer();

        }
    }
}
