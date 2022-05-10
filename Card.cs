using System;
using System.Collections.Generic;
using System.Text;

namespace Kortspel
{
    class Card
    {
        int number;
        string symbol;
        string color;
        public Card(int number, string symbol, string color)
        {
            this.number = number;
            this.symbol = symbol;
            this.color = color;
        }
    }
}
