using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameHelper;
using Microsoft.Xna.Framework;

namespace MTDMG.GameObjects.Buttons
{
    public class DestroyWall : Button
    {
        PlayerControler player;
        public GameObject slot;
        public DestroyWall(MazeGame game, PlayerControler player)
            : base(game, "Textures/Button2")
        {
            this.player = player;
            this.isActive = false;
            ((Render2D)renderer).SetOrigin = Render2D.Origin.BottomLeft;
            renderer.color = Color.Aquamarine.ToVector3();
            CanClick = true;
            ((Render2D)renderer).Offset = new Rectangle(+10, +10, -20, -20);
        }

        public override void MouseClick()
        {
            ((Scenes.StartScene)game.myScene).DestroyWall((Slot)slot);
            ((Slot)slot).DestroyWall();    
            base.MouseClick();
        }

    }
}
