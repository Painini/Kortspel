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

        public void AssignValues(CardDeck deck)
        {
            deck.GetDeck()[0].SetValue(1);
            deck.GetDeck()[1].SetValue(2);
            deck.GetDeck()[2].SetValue(3);
            deck.GetDeck()[3].SetValue(4);
            deck.GetDeck()[4].SetValue(5);
            deck.GetDeck()[5].SetValue(6);
            deck.GetDeck()[6].SetValue(7);
            deck.GetDeck()[7].SetValue(8);
            deck.GetDeck()[8].SetValue(9);
            deck.GetDeck()[9].SetValue(10);
            deck.GetDeck()[10].SetValue(10);
            deck.GetDeck()[11].SetValue(10);
            deck.GetDeck()[12].SetValue(10);

            deck.GetDeck()[13].SetValue(1);
            deck.GetDeck()[14].SetValue(2);
            deck.GetDeck()[15].SetValue(3);
            deck.GetDeck()[16].SetValue(4);
            deck.GetDeck()[17].SetValue(5);
            deck.GetDeck()[18].SetValue(6);
            deck.GetDeck()[19].SetValue(7);
            deck.GetDeck()[20].SetValue(8);
            deck.GetDeck()[21].SetValue(9);
            deck.GetDeck()[22].SetValue(10);
            deck.GetDeck()[23].SetValue(10);
            deck.GetDeck()[24].SetValue(10);
            deck.GetDeck()[25].SetValue(10);

            deck.GetDeck()[26].SetValue(1);
            deck.GetDeck()[27].SetValue(2);
            deck.GetDeck()[28].SetValue(3);
            deck.GetDeck()[29].SetValue(4);
            deck.GetDeck()[30].SetValue(5);
            deck.GetDeck()[31].SetValue(6);
            deck.GetDeck()[32].SetValue(7);
            deck.GetDeck()[33].SetValue(8);
            deck.GetDeck()[34].SetValue(9);
            deck.GetDeck()[35].SetValue(10);
            deck.GetDeck()[36].SetValue(10);
            deck.GetDeck()[37].SetValue(10);
            deck.GetDeck()[38].SetValue(10);

            deck.GetDeck()[39].SetValue(1);
            deck.GetDeck()[40].SetValue(2);
            deck.GetDeck()[41].SetValue(3);
            deck.GetDeck()[42].SetValue(4);
            deck.GetDeck()[43].SetValue(5);
            deck.GetDeck()[44].SetValue(6);
            deck.GetDeck()[45].SetValue(7);
            deck.GetDeck()[46].SetValue(8);
            deck.GetDeck()[47].SetValue(9);
            deck.GetDeck()[48].SetValue(10);
            deck.GetDeck()[49].SetValue(10);
            deck.GetDeck()[50].SetValue(10);
            deck.GetDeck()[51].SetValue(10);
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
