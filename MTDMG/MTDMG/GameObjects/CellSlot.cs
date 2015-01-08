using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using GameHelper;

namespace MTDMG.GameObjects
{
   public class CellSlot : GameObject
    {

        
        MyGame _game;
    
        bool isUsed = false;

        public CellSlot(MyGame game)
            : base(game, game.mainCamera)
        {
            _game = game;
           renderer = new Render3D(this, "Model/CellSlot");
           renderer.myMeshes.Clear();
           renderer.myMeshes.Add(renderer.model.Meshes[0]);
           renderer.color = Color.OrangeRed.ToVector3();

           CanClick = true;
        }

        public override void MouseClick()
        {

            MyGame.Instance.startscene.GeneratePath(new Vector2(this.transform.Position.X, this.transform.Position.Z));
        }



        public void ChangeColor(Color _color)
        {
            this.renderer.color = _color.ToVector3();
        }

        public void EnterSlot(Guard _guard)
        {

        }

        public void LeaveSlot(Guard _guard)
        {

        }

    }
}
