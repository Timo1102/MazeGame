using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameHelper;

namespace MTDMG.GameObjects
{
    public class Menu : GameObject
    {
        public PlayerControler player;
        public GameObject gobj;
        public Menu(MazeGame game, PlayerControler player)
            : base(game, game.mainCamera)
        {
            renderer = new Render2D(this, "Textures/test", Render2D.Origin.Center);
            //CanClick = true;

        }

        public virtual void Open(GameObject gobj)
        {
            this.isActive = true;
            this.transform.Position = new Microsoft.Xna.Framework.Vector3(Microsoft.Xna.Framework.Input.Mouse.GetState().X, Microsoft.Xna.Framework.Input.Mouse.GetState().Y,0) ;
            
            this.gobj = gobj;
            SetButtons();
            
        }
        public void SetButtons()
        {
            if(btn1 != null)
            {
               
            btn1.transform.Position = this.transform.Position;
             btn1.isActive = true;
            }

            if (btn2 != null)
                {
            btn2.transform.Position = this.transform.Position;
                             btn2.isActive = true;
            }
            if (btn3 != null)
                {
            btn3.transform.Position = this.transform.Position;
                             btn3.isActive = true;
            }
            if (btn4 != null)
                {
            btn4.transform.Position = this.transform.Position;
            btn4.isActive = true;
                }
        }


        public virtual void InitButtons()
        {


        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public Button btn1;
        public Button btn2;
        public Button btn3;
        public Button btn4;

        public override void MouseClick()
        {
            Console.WriteLine("asdasdasdasda");
            base.MouseClick();
        }

    }
}
