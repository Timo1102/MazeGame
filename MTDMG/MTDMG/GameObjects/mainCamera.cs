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
    class mainCamera : Camera
    {
        private MouseState prevMouseState;
        private MouseState currentMouseState;
        private float cameraSpeed;
        private Vector3 mouseRotationBuffer;   
        public mainCamera(Game game)
            : base(game)
        {
            prevMouseState = Mouse.GetState();
            this.cameraSpeed = 50.0f;
        }

        public override void Update(GameTime gameTime)
        {
            //Delta time
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Nur wenn rechte maustaste gedrückt wird
            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                //Set mouse in the middle of the screen;
              //  Mouse.SetPosition(Game.Window.ClientBounds.Width / 2, Game.Window.ClientBounds.Height / 2);
                //Get current MouseState
                currentMouseState = Mouse.GetState();
                //Set Mouse invisible
                Game.IsMouseVisible = false;



                Vector3 moveVector = Vector3.Zero;

            

                //Handle basic key movement
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                    moveVector = -Forward; 
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                    moveVector = Forward; 
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                    moveVector = -Left;
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                    moveVector = Left;
                if (Keyboard.GetState().IsKeyDown(Keys.Q))
                    moveVector = Up;
                if (Keyboard.GetState().IsKeyDown(Keys.E))
                    moveVector = -Up;

                //Set Camera Position
                if (moveVector != Vector3.Zero)
                {
                    moveVector.Normalize();
                    moveVector *= cameraSpeed * dt;
                    Position += moveVector;
                }

                //Change in mouse position
                //x and y
                float deltaX;
                float deltaY;

                //Handle mouse movement
                if (currentMouseState != prevMouseState)
                {
                    //Get the change in mouse position
                    deltaX = Mouse.GetState().X - (Game.GraphicsDevice.Viewport.Width / 2);
                    deltaY = Mouse.GetState().Y - (Game.GraphicsDevice.Viewport.Height / 2);

                    //This is used to buffer against use input.
                    mouseRotationBuffer.X -= 0.01f * deltaX * dt;
                    mouseRotationBuffer.Y -= 0.01f * deltaY * dt;

                    if (mouseRotationBuffer.Y < MathHelper.ToRadians(-75.0f))
                        mouseRotationBuffer.Y = mouseRotationBuffer.Y - (mouseRotationBuffer.Y - MathHelper.ToRadians(-75.0f));
                    if (mouseRotationBuffer.Y > MathHelper.ToRadians(90.0f))
                        mouseRotationBuffer.Y = mouseRotationBuffer.Y - (mouseRotationBuffer.Y - MathHelper.ToRadians(90.0f));


                    Rotation = new Vector3(-MathHelper.Clamp(mouseRotationBuffer.Y, MathHelper.ToRadians(-75.0f),
                                 MathHelper.ToRadians(90.0f)), MathHelper.WrapAngle(mouseRotationBuffer.X), 0);

                    deltaX = 0;
                    deltaY = 0;
                    
                }
                Mouse.SetPosition(Game.Window.ClientBounds.Width / 2, Game.Window.ClientBounds.Height / 2);
                prevMouseState = currentMouseState;

               
            }

            if (Mouse.GetState().RightButton == ButtonState.Released)
            {
                Game.IsMouseVisible = true;
            }
            base.Update(gameTime);
        }




    }
}
