using System;
using System.Collections.Generic;
using System.Text;

namespace Kortspel
{
    public class Card
    {
        private int value;
        private string symbol;
        private string color;
        private bool flipped;
        public Card(int value, string symbol, string color, bool flipped)
        {
            this.value = value;
            this.symbol = symbol;
            this.color = color;
            this.flipped = flipped;

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

    }

}
