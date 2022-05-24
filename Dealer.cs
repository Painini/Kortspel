using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kortspel
{
    public class Dealer : Participator
    {

        //May build on later


        public void DealerFlip(Dealer dealer, Texture2D img)
        {
            Card card = dealer.GetCardsInHand()[dealer.GetCardsInHand().Count - 1];
            card.ChangeFlipStatus(card, img);
            dealer.GetCardsInHand().RemoveAt(1);
            dealer.GetCardsInHand().Add(card);
        }


    }
}
