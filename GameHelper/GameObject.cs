using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GameHelper
{
    public class GameObject : Microsoft.Xna.Framework.GameComponent
    {
        public bool isActive;
        public Transform transform;
        public Render3D renderer = null;
        public Model model;

        public Game game;

        public GameObject(Game game)
            : base(game)
        {
            transform = new Transform();
            this.game = game;
            game.Components.Add(this);
            isActive = true;
        }

        public void SetActive(bool active)
        {
            isActive = active;
            
        }

        public override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);
        }

        
    }
}
