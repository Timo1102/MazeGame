using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameHelper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace MTDMG.GameObjects
{
   public class PlayerControler : GameObject
    {
        public PlayerControler(MazeGame game, Keys key)
            : base(game, game.mainCamera)
        {
            myKey = key;
        }

        private int _id;
        public int ID
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


        public void SpwanBase(Vector2 pos)
        {
            

            myBase = new GameObjects.Base((MazeGame)game, this);
            myBase.transform.Position = new Vector3(pos.X, 0, pos.Y);
            myBase.guardColor = this.myColor;
            ((Scenes.StartScene)game.myScene).Instatiate(myBase);
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
