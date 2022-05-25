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
        private Texture2D underImg;


        public Card(string symbol, bool flipped):
            base ()
        {
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

        public int ReturnCardValue()
        {
            if (flipped)
                return value;
            else
                return 0;
        }

        public void SetValue(int value)
        {
            this.value = value;
        }

        public void SetImg(Texture2D img)
        {
            this.img = img;
        }
        public Texture2D GetImg()
        {
            return img;
        }



        public void ChangeFlipStatus(Card card, Texture2D img)
        {
            if (card.flipped == true)
            {
                flipped = false;
                underImg = card.GetImg();
                card.SetImg(img);
            }
            else
            {
                flipped = true;
                card.SetImg(underImg);
            }
                
        }

        public void Update(Card[] cardArray)
        {
        }




        public override void Draw(SpriteBatch sb)
        {
            imgColor = Color.AntiqueWhite;

            
            sb.Draw(img, pos, null, imgColor, 0.0f, originPoint, scale, SpriteEffects.None, 0.0f);
        }

    }

}