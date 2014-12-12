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
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;


        public GameObject(Game game)
            : base(game)
        {
            game.Components.Add(this);
            position = new Vector3(0, 0, 0);
            rotation = new Vector3(0, 0, 0);
            scale = new Vector3(1.0f, 1.0f, 1.0f);

        }


        public override void Update(GameTime gameTime)
        {
            Console.WriteLine("Muhahaha");
            base.Update(gameTime);
        }

    }
}
