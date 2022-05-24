using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kortspel
{
    internal class Chip: Obj
    {
        int chipValue;
        public Chip(Texture2D img, int chipValue, Vector2 pos):
           base()
        {
            this.pos = pos;
            this.img = img;
            this.chipValue = chipValue;
            scale = 0.5f;
            CreateBoundingBox(this.img);
            SetOrigin(this.img);
        }

        public int GetChipValue()
        {
            return chipValue;
        }

        public override void Draw(SpriteBatch sb)
        {
            imgColor = Color.White;

            sb.Draw(img, pos, null, imgColor, 0.0f, originPoint, 1f, SpriteEffects.None, 0.0f);

        }
    }
}
