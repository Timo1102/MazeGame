using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GameHelper
{
    public static class Config
    {

        public static int GoldPerTick = 1;

//############Color Codes######################

        public static Color CellColor = Color.DarkBlue;

        public static Color Player1 = Color.Red;
        public static Color Player2 = Color.Blue;

//#############Guard Config####################

        
        public static int GuardCostRunner = 10;
        public static int GuardCostDestroyer = 15;
        public static int GuardCostSpion = 5;

        public static int GuardLiveRunner = 100;
        public static int GuardLiveDestroyer = 500;
        public static int GuardLiveSpion = 50;

        //Speziel Config
         public static int GuardDamageDestroyer = 50;

//###########Towwer Config#####################
        public static int TowerCost = 500;
        public static int TowerLive = 1000;

        public static int TowerDamage1 = 50;
        public static int TowerDamage2 = 100;
        public static int TowerDamage3 = 150;

    }
}
