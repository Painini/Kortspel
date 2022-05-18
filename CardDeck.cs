using System;
using System.Collections.Generic;
using System.Text;

namespace Kortspel
{
    class CardDeck
    {
        private Card[] deck = new Card[52];
        private bool shuffled = false;


        public bool GetShuffledStatus()
        {
            return shuffled;
        }

        public void SetShuffledStatusToTrue()
        {
            shuffled = true;
        }

        public Card[] GetDeck()
        {
            return deck;
        }
        public CardDeck()
        {
            for (int i = 0; i < 12; i++)
            {
                deck[i] = new Card(i, "hearts", "red");
            }
            for (int i = 12; i < 25; i++)
            {
                deck[i] = new Card(i, "diamonds", "red");
            }
            for (int i = 25; i < 38; i++)
            {
                deck[i] = new Card(i, "spades", "black");
            }
            for (int i = 38; i < 52; i++)
            {
                deck[i] = new Card(i, "clubs", "black");
            }
        }

    }
}
