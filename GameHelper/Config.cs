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
        public static int StartGold = 1000;

        public static int TickIntervall = 250;
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
        public static int TowerCost1 = 500;
        public static int TowerCost2 = 500;
        public static int TowerCost3 = 500;

        public static int TowerLife1 = 1000;
        public static int TowerLife2 = 1000;
        public static int TowerLife3 = 1000;


        public static int TowerDamage1 = 50;
        public static int TowerDamage2 = 100;
        public static int TowerDamage3 = 150;

        public static int TowerMaxLevel = 3;

    }
}
