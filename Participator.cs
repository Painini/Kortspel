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

        public void AddCardsToHand(List<Card> cards, Player player)
        {
            foreach (Card c in cards)
            {
                player.GetCardsInHand().Add(c);
            }
        }


    }
}
