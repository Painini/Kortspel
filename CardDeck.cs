using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kortspel
{
    public class CardDeck
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
                deck[i] = new Card(i, "hearts", true);
            }
            for (int i = 12; i < 25; i++)
            {
                deck[i] = new Card(i, "diamonds", true);
            }
            for (int i = 25; i < 38; i++)
            {
                deck[i] = new Card(i, "spades", true);
            }
            for (int i = 38; i < 52; i++)
            {
                deck[i] = new Card(i, "clubs", true);
            }
        }



        //Attempt at removing cards that are given out from a deck, so that they cannot appear twice in the same round.

        //public CardDeck(List<Card> cardsToRemove)
        //{


        //    for (int i = 0; i < 12; i++)
        //    {
        //        deck[i] = new Card(i, "hearts", "red");
        //    }

        //    for (int i = 12; i < 25; i++)
        //    {
        //        deck[i] = new Card(i, "diamonds", "red");
        //    }

        //    for (int i = 25; i < 38; i++)
        //    {
        //        deck[i] = new Card(i, "spades", "black");
        //    }

        //    for (int i = 38; i < 52; i++)
        //    {
        //        deck[i] = new Card(i, "clubs", "black");
        //    }
       // }
    }
}
