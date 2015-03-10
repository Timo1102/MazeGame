using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GameHelper
{
    /// <summary>
    /// Render class
    /// </summary>
    public class Render : ObjectComponent
    {


        public Render(GameObject gameobj, string name)
            : base(gameobj)
        {
            gameobj.game.Components.Add(this);
            
        }
       

        Texture2D t2D;
        
        private Color _color;
        
        /// <summary>
        /// Sets the color of the material
        /// </summary>
        public Vector3 color
        {
            get
            {
                return _color.ToVector3();
            }
            set
            {
                _color = new Color(value);
            }
        }

        public Color colorRGB
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;

            }
        }
        

    }
}
