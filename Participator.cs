using System;
using System.Collections.Generic;
using System.Text;

namespace Kortspel
{
    abstract class Participator
    {
        public List<Card> cardsInHand;


        //Fråga jonas: Kan jag använda Participator.GetCardsInHand universallt genom att ge metoden en parameter med participatorn?
        public List<Card> GetCardsInHand()
        {
            return cardsInHand;
        }

        public void SetCardsInHand(List<Card> cards)
        {
            cardsInHand = cards;
        }
    }
}
