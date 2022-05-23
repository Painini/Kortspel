using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kortspel
{
    public class Card: Obj
    {
        private int value;
        private string symbol;
        private bool flipped;
        private Color imgColor;
        private Vector2 originPoint;

        public Card(int value, string symbol, bool flipped):
            base ()
        {
            this.value = value;
            this.symbol = symbol;
            this.flipped = flipped;
            scale = 0.3f;    

        }

        public Vector2 GetPos()
        {
            return pos;
        }

        public void SetPos(Vector2 newPos)
        {
            pos = newPos;
        }

        public void SetImgColor(Color color)
        {
            imgColor = color;
        }

        public Rectangle GetBoundingBox()
        {
            return bb;
        }

        public int ReturnCardValue()
        {
            if (!flipped)
                return value;
            else
                return 0;
        }

        public void SetScale(float scale)
        {
            this.scale = scale;
        }

        public void SetImg(Texture2D img)
        {
            this.img = img;
        }
        public Texture2D GetImg()
        {
            return img;
        }

        public void SetOrigin(Texture2D img)
        {
            originPoint = new Vector2(img.Width / 2, img.Height / 2);
        }

        public void ChangeFlipStatus(Card card)
        {
            if (card.flipped == true)
            {
                flipped = false;
            }
            else
                flipped = true;
        }

        public override void Update()
        {

        }




        public override void Draw(SpriteBatch sb)
        {
            imgColor = Color.AntiqueWhite;


            sb.Draw(img, pos, null, imgColor, 0.0f, originPoint, scale, SpriteEffects.None, 0.0f);
        }

        public override void CreateRectangle(Texture2D img)
        {
            bb = new Rectangle((int)originPoint.X, (int)originPoint.Y, img.Width, img.Height);
        }

    }

}