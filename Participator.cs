using System;
using System.Collections.Generic;
using System.Text;

namespace Kortspel
{
    public abstract class Participator
    {
        List<Card> cardsInHand;

        public List<Card> GetCardsInHand()
        {
            return cardsInHand;
        }

        public void SetCardsInHand(List<Card> cards)
        {

            cardsInHand = cards;
        }

        public void AddCardsToHand(List<Card> cards, Participator participator)
        {
            foreach (Card c in cards)
            {
                participator.GetCardsInHand().Add(c);
            }
        }

        public void RemoveCardsFromHand()
        {
            cardsInHand.Clear();
        }

    }
}
