using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kortspel
{

    //Some things that are in both Button and Card will be missing rom Obj, as Obj is might be used for more objects in the future (chips).
    public abstract class Obj
    {
        protected Texture2D img;
        protected Vector2 pos;
        protected Color color;
        protected Rectangle bb;
        protected float scale;


        public Obj()   
        {
        }

        public virtual void Update()
        {

        }

        public virtual void Draw(SpriteBatch sb)
        {

        }

        public virtual void CreateRectangle(Texture2D img)
        {
            bb = new Rectangle((int)pos.X, (int)pos.Y, img.Width, img.Height);
        }

    }
}
