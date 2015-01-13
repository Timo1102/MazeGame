using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameHelper
{



   public class GameManager 

   {

        
        public bool isPause
        {
            get
            {
                return isPause;
            }
            private set
            {
                isPause = value;
            }
        }

        public static GameManager instance;

        public GameManager(myGame game)
        {
            if (instance == null)
                instance = this;
        }





        public void Pause()
        {
           
        }

        public void Pause(bool pause)
        {
           
        }


        public void Start()
        {
           
        }

    }
}
