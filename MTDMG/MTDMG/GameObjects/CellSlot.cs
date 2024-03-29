﻿using System;
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

        
        MazeGame _game;
        long playerNumberMenu;
        bool isUsed = false;

        public Guard target;

        public CellSlot(MazeGame game)
            : base(game, game.mainCamera)
        {
            _game = game;
           renderer = new Render3D(this, "Model/CellSlot");
           ((Render3D)renderer).myMeshes.Clear();
           ((Render3D)renderer).myMeshes.Add(((Render3D)renderer).model.Meshes[0]);
           renderer.color = Color.DarkBlue.ToVector3();

           CanClick = true;
        }

        public override void MouseClick()
        {
            if (((Scenes.StartScene)game.myScene).GetPlayerController() != null)
            ((Scenes.StartScene)game.myScene).GetPlayerController().SpwanBase(this);
        }


        public override void MouseClick(long number)
        {
            if (((Scenes.StartScene)game.myScene).GetPlayerController(number) != null)
            {
                ((Scenes.StartScene)game.myScene).GetPlayerController(number).SpwanBase(this);

            }
        }

        public override void MouseReleased()
        {

            base.MouseReleased();
        }


        public void ChangeColor(Color _color)
        {
            this.renderer.color = _color.ToVector3();
        }

        public void EnterSlot(Guard _guard)
        {
            target = _guard;
        }

        public void LeaveSlot(Guard _guard)
        {
            target = null;
        }

    }
}
