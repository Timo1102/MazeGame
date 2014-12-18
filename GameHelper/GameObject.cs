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
        public List<GameObject> children = new List<GameObject>();
        public bool isActive;
        public Transform transform;
        public Render3D renderer = null;


        public Game game;
        public Camera mainCamera;
        public GameObject(Game game, Camera mainCamera)
            : base(game)
        {
            this.mainCamera = mainCamera;
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

        public void AddAsChild(GameObject child)
        {
            children.Add(child);
        }

        
    }
}
