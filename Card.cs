using System;
using System.Collections.Generic;
using System.Text;

namespace Kortspel
{
    class Card
    {
        private int value;
        private string symbol;
        private string color;
        public Card(int value, string symbol, string color)
        {
            this.value = value;
            this.symbol = symbol;
            this.color = color;
        }

        public int ReturnCardValue()
        {
            return value;
        }

    }

}
