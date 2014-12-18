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
using GameHelper;

namespace MTDMG.GameObjects
{
    public class Cell : GameObject
    {

        
        

        public Cell(MyGame game) : base(game, game.mainCamera)
        {
           renderer = new Render3D(this, "Model/Cell");
        }

        public void SetWalls(bool top, bool bottom, bool left, bool right)
        {
            //foreach (ModelMesh _mesh in renderer.model.Meshes)
            //{
            //    renderer.myMeshes.Add(_mesh);
            //}

            AddMesh(0);
            AddMesh(5);
            AddMesh(6);
            AddMesh(7);
            AddMesh(8);
            if (top)
                AddMesh(1);
            if (bottom)
                AddMesh(2);
            if (left)
                AddMesh(3);
            if (right)
                AddMesh(4);


            Console.WriteLine("NumberofMeshes: " + renderer.myMeshes.Count);
        }

        void AddMesh(int _number)
        {
            renderer.myMeshes.Add(renderer.model.Meshes[_number]);
        }

        public override void Update(GameTime gameTime)
        {
             float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;


            
            base.Update(gameTime);
        }

    }
}
