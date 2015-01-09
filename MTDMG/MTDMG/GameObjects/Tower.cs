using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameHelper;
using Microsoft.Xna.Framework;

namespace MTDMG.GameObjects
{
    class Tower : GameObject
    {
        public int Radius = 2;
        List<GameObjects.CellSlot> allSlots = new List<GameObjects.CellSlot>();
        PlayerControler player;
        Guard target;
        public int damage = 2;

        public Tower(MyGame game, PlayerControler player)
            : base(game, game.mainCamera)
        {
            renderer = new Render3D(this, "Model/Tower");
            transform.Scale = new Vector3(0.3f, 0.6f, 0.3f);
            CanClick = true;
            this.player = player;

    
            

        }




        public override void MouseClick()
        {
            ((MyGame)game).startscene.ResetCellSlotColor();
            foreach (var _cell in allSlots)
            {
                _cell.renderer.color = Color.Beige.ToVector3();
            }
           
            base.MouseClick();
        }

        public override void Update(GameTime gameTime)
        {
            if (target == null)
            {
                FindTarget();
            }

            base.Update(gameTime);
        }
        void FindTarget()
        {
            foreach (var _guard in allSlots)
            {
                if (_guard.target != null && _guard.target.player != player)
                {
                    target = _guard.target;
                    ShootTarget();
                    target = null;
                }
            }
        }

        void ShootTarget()
        {
            target.renderer.color = Color.Red.ToVector3();
            target.GetDamage(damage);
        }

        public void FindSlots()
        {

            for (int i = -Radius; i <= Radius; i++)
            {
                for (int j = -Radius; j <= Radius; j++)
                {
                    FindCellSlots(new Vector2(i , j));
                }
            }

        }

        void FindCellSlots(Vector2 spos)
        {
            Vector2 npos = new Vector2(this.transform.Position.X, this.transform.Position.Z);


            if(((MyGame)game).startscene.GetVertex(new Vector2(npos.X + spos.X, npos.Y+spos.Y)) != null)
            {
                allSlots.Add(((MyGame)game).startscene.GetVertex(new Vector2(npos.X + spos.X, npos.Y + spos.Y)).data);
            }
        }



    }
}
