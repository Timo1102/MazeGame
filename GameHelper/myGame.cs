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


namespace GameHelper 
{
    public class myGame : Microsoft.Xna.Framework.Game
    {
        public scene myScene;
        public Camera mainCamera;


        public readonly GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;

        
        protected Color backgroundColor = new Color(81, 81, 81);
        protected bool applicationLoadCompleteSignalled;


        public myGame()
        {
            graphics = new GraphicsDeviceManager(this);
        }

        protected override void Update(GameTime gameTime)
        {

            if (Mouse.GetState().LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                CheckTouch(Mouse.GetState().X, Mouse.GetState().Y);
            }



            base.Update(gameTime);
        }



        public virtual void CheckTouch(float x, float y)
        {

        }


    }
}
