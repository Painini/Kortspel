using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kortspel
{
    public class CardDeckHandler
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
            cardsToGive = new List<Card>();
            List<Card> listToTakeFrom = new List<Card>();

            for (int i = 0; i < 52; i++)
            {
                listToTakeFrom.Add(deck.GetDeck()[i]);
            }
            for (int i = 0; i < amountToGive; i++)
            {
                
                int randomNumber = random.Next(0, listToTakeFrom.Count - 1);
                cardsToGive.Add(listToTakeFrom[randomNumber]);
                listToTakeFrom.RemoveAt(randomNumber);   
            }
            return cardsToGive;
        }

        public CardDeck AssignImg(Texture2D[] imgs, CardDeck deck)
        {
            for (int i = 0; i < 52; i++)
            {
                deck.GetDeck()[i].SetImg(imgs[i]);
                deck.GetDeck()[i].SetOrigin(imgs[i]);

            }

            foreach (Card c in deck.GetDeck())
                c.CreateBoundingBox(c.GetImg());

            return deck;
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
