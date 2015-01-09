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
        public PlayerControler(MyGame game, Keys key)
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
       public Color guardColor;


        public void SpwanBase(Vector2 pos)
        {
            

            myBase = new GameObjects.Base((MyGame)game, this);
            myBase.transform.Position = new Vector3(pos.X, 0, pos.Y);
            myBase.guardColor = this.guardColor;
            ((MyGame)game).startscene.Instatiate(myBase);
        }

        public void SpwanTower(Vector3 pos)
        {
            GameObjects.Tower tower;
            tower = new GameObjects.Tower((MyGame)game, this);
            tower.transform.Position = pos;
            tower.renderer.color = guardColor.ToVector3();
            tower.FindSlots();
            ((MyGame)game).startscene.Instatiate(tower);
        }


    }
}
