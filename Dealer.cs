using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kortspel
{
    public class Dealer : Participator
    {
        Card card;
        //May build on later


        public void DealerFlip(Dealer dealer, Texture2D img)
        {
            card = dealer.GetCardsInHand()[dealer.GetCardsInHand().Count - 1];
            card.ChangeFlipStatus(card, img);
            card.SetScale(0.3f);
            dealer.GetCardsInHand().RemoveAt(1);
            dealer.GetCardsInHand().Add(card);

        }


    }
}
