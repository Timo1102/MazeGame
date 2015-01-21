﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameHelper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Surface.Core;


namespace MTDMG.GameObjects
{
   public class PlayerControler : GameObject
    {
        public PlayerControler(MazeGame game, Keys key, int number)
            : base(game, game.mainCamera)
        {
            myKey = key;
            RessourceCoins = Config.StartGold;
            ID = number;
        }

        private long _id;
        public long ID
        {
            get
            {
                return _id;
            }
            private set
            {
                _id = value;
            }

        }

        public Keys myKey;
        public TagData tagData;
        public GameObjects.Base myBase;
       public Color myColor;

      


       private int ressourceCoins;
       public int RessourceCoins
       {
           get
           {
               return ressourceCoins;
           }
           set
           {
               ressourceCoins = value;
           }
       }

       public override void Tick(object sender, EventArgs e)
       {
           RessourceCoins += Config.GoldPerTick;
           base.Tick(sender, e);
       }

        public void SpwanBase(CellSlot cell)
        {
            if (myBase == null)
            {
                Vector3 pos = cell.transform.Position;

                myBase = new GameObjects.Base((MazeGame)game, this);
                myBase.transform.Position = new Vector3(pos.X, 0, pos.Z);
                myBase.guardColor = this.myColor;
                myBase.myCell = cell;
                ((Scenes.StartScene)game.myScene).Instatiate(myBase);
            }
        }

        public void RegisterPlayer(TagData data)
        {
            
            this.tagData = data;
        }

        public void OpenMenu(GameObject pos)
        {

        }


        public void SpwanTower(Vector3 pos)
        {
            GameObjects.Tower tower;
            tower = new GameObjects.Tower((MazeGame)game, this);
            tower.transform.Position = pos;
            tower.renderer.color = myColor.ToVector3();
            tower.FindSlots();
            //((Scenes.StartScene)game.myScene).InstatiateTower(new Vector2(pos.X, pos.Z), this);
            ((Scenes.StartScene)game.myScene).Instatiate(tower);
            //game.myScene.Instatiate(tower);
        }


    }
}
