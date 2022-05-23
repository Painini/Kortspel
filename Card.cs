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
        bool isHovering;

        public Card(int value, string symbol, bool flipped):
            base ()
        {
            this.value = value;
            this.symbol = symbol;
            this.flipped = flipped;
            CreateRectangle();
        }

        public int ReturnCardValue()
        {
            if (flipped == false)
                return value;
            else
                return 0;
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

            if (isHovering)
            {
                imgColor = Color.White;
            }

            sb.Draw(img, bb, imgColor);
        }

        

    }

}