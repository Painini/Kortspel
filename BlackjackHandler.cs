using System;
using System.Collections.Generic;
using System.Text;

namespace Kortspel
{
    public class BlackjackHandler
    {

        int startingChips;
        int currentChips;
        int highestChips;
        int playerSum;
        int dealerSum;

        CardDeck deck;
        CardDeckHandler deckHandler;



        public void GameStartSetup()
        {
            deck = new CardDeck();
            deckHandler = new CardDeckHandler();
            deckHandler.shuffleDeck(deck);

            startingChips = 100;
            currentChips = startingChips;


        }


        public void DealerInitialCardsHandler()
        {


            
        }
    }
}
