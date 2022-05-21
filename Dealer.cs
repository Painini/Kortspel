using System;
using System.Collections.Generic;
using System.Text;

namespace Kortspel
{
    class Dealer : Participator
    {

        //May build on later


        public void DealerFlip()
        {
            Card card = cardsInHand[cardsInHand.Count - 1];
            card.ChangeFlipStatus(card);
            cardsInHand.RemoveAt(1);
            cardsInHand.Add(card);
        }


    }
}
