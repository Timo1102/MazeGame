using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameHelper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MTDMG.GameObjects
{
    public class Tower : GameObject
    {
        public int Radius = 2;
        List<GameObjects.CellSlot> allSlots = new List<GameObjects.CellSlot>();
        PlayerControler player;
        Guard target;
        public int damage;
        public int Cost;
        public int NextCost;
        public int Life;

        int level;
        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
                SetValue(value);
            }
        }



        public Tower(MazeGame game, PlayerControler player)
            : base(game, game.mainCamera)
        {
            renderer = new Render3D(this, "Model/Tower");
            transform.Scale = new Vector3(0.3f, 0.6f, 0.3f);
            CanClick = true;
            this.player = player;
            Level = 1;
           
            

        }


        void SetValue(int i)
        {
            switch (i)
            {
                case 1:
                    damage = Config.TowerDamage1;
                    Cost = Config.TowerCost1;
                    NextCost = Config.TowerCost2;
                    Life = Config.TowerLife1;
                    break;
                case 2:
                    damage = Config.TowerDamage2;
                    Cost = Config.TowerCost2;
                    NextCost = Config.TowerCost3;
                    Life = Config.TowerLife2;
                    break;
                case 3:
                    damage = Config.TowerDamage3;
                    Cost = Config.TowerCost3;
                    Life = Config.TowerLife3;
                    break;
            }

        }

        public void Upgrade()
        {
            if(Level<Config.TowerMaxLevel)
            Level++;
        }

        public override void MouseClick()
        {
            Console.WriteLine("Klick on Tower");
            ((Scenes.StartScene)game.myScene).ResetCellSlotColor();
            allSlots.Clear();
            FindSlots();

            foreach (var _cell in allSlots)
            {
                _cell.renderer.color = Color.Beige.ToVector3();
            }
           
            base.MouseClick();
        }

        public override void Update(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.V))
            {
                FindSlots();
                ((Scenes.StartScene)game.myScene).ResetCellSlotColor();
                foreach (var _cell in allSlots)
                {
                    _cell.renderer.color = Color.Beige.ToVector3();
                }
            }


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
           

            if(((Scenes.StartScene)game.myScene).GetVertex(new Vector2(npos.X + spos.X, npos.Y+spos.Y)) != null)
            {
                allSlots.Add(((Scenes.StartScene)game.myScene).GetVertex(new Vector2(npos.X + spos.X, npos.Y + spos.Y)).data);
            }
        }



    }
}
