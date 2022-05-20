using System;
using System.Collections.Generic;
using System.Text;

namespace Kortspel
{
    class CardDeckHandler
    {
        Random random = new Random();

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

        public CardDeckHandler()
        {

        }

    }
}
