﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kortspel
{
    class CardDeckHandler
    {
        Random random = new Random();
        List<Card> cardsToGive;

        public CardDeck shuffleDeck(CardDeck deckToShuffle)
        {
            CardDeck unshuffledDeck = new CardDeck();

            List<int> availablePositions = new List<int>();

            for (int i = 0; i < 51; i++)
                availablePositions.Add(i);
            
            for (int i = 0; i < 51; i++)
            {
                int index = random.Next(0, availablePositions.Count - 1);     
                deckToShuffle.GetDeck()[i] = unshuffledDeck.GetDeck()[index];
                availablePositions.RemoveAt(index);

            }

            deckToShuffle.SetShuffledStatusToTrue();
            return deckToShuffle;
        }

        public List<Card> GiveCards(int amountToGive, CardDeck deck)
        {
            for (int i = 0; i <= amountToGive; i++)
            {
                int randomNumber = random.Next(0, 51);
                try
                {
                    cardsToGive.Add(deck.GetDeck()[randomNumber]);
                    deck.GetDeck()[randomNumber] = null;
                }
                catch (NullReferenceException)
                {
                    i--;
                }
               
            }

            return cardsToGive;
        }

        public void AssignImg(Texture2D[] imgs, CardDeck deck)
        {
            for (int i = 0; i < 52; i++)
            {
                deck.GetDeck()[i].SetImg(imgs[i]);
                deck.GetDeck()[i].SetOrigin(imgs[i]);

            }

            foreach (Card c in deck.GetDeck())
                c.CreateBoundingBox(c.GetImg());
        }

        //Attempt at removing cards that are given out from a deck, so that they cannot appear twice in the same round.

        //public CardDeck RemoveCardsFromDeck(List<Card> cardsToRemove, CardDeck deck)
        //{


        //    CardDeck newDeck = new CardDeck();



        //}


        public CardDeckHandler()
        {

        }

    }
}
