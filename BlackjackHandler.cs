using System;
using System.Collections.Generic;
using System.Text;

namespace Kortspel
{
    public class BlackjackHandler
    {

        int startingChips;
        int currentChips;
        int betChips;
        int highestChips;
        int playerSum;
        int dealerSum;
        Player player;
        Dealer dealer;


        CardDeck deck;
        CardDeckHandler deckHandler;

        public void CalcPlayerSum()
        {
            foreach (Card c in player.GetCardsInHand())
                playerSum += c.ReturnCardValue();
        }

        public void CalcDealerSum()
        {
            foreach (Card c in dealer.GetCardsInHand())
                dealerSum += c.ReturnCardValue();
        }

        public void CalcSums()
        {
            CalcPlayerSum();
            CalcDealerSum();
        }

        public void GameStartSetup(string playerName)
        {
            deck = new CardDeck();
            deckHandler = new CardDeckHandler();
            deckHandler.shuffleDeck(deck);

            startingChips = 100;
            if (currentChips <= startingChips)
            currentChips = startingChips;
            player = new Player(playerName, currentChips);
            dealer = new Dealer();

        }

        public void Bet(int betChips)
        {
            this.betChips = betChips;
            currentChips -= betChips;
        }

        public void RoundStart()
        {
            player.SetCardsInHand(deckHandler.GiveCards(2, deck));
            dealer.SetCardsInHand(deckHandler.GiveCards(2, deck));
            dealer.DealerFlip();

            CalcSums();
        }

        public void PlayerHit()
        {
            player.SetCardsInHand(deckHandler.GiveCards(1, deck));
            CalcPlayerSum();

            if (playerSum > 21)
            {
                ResultCalcAndChipExchange();
            }

        }

        public void PlayerStand ()
        {
            dealer.DealerFlip();

            while (dealerSum < 17)
            {
                dealer.SetCardsInHand(deckHandler.GiveCards(1, deck));
            }
            ResultCalcAndChipExchange();
        }
        //Continue working here later
        public bool ResultCalcAndChipExchange()
        {
            if (playerSum > dealerSum && playerSum <= 21)
            {
                currentChips += betChips;
                int wonChips = betChips * 15 / 10;
                currentChips += wonChips;
                if (currentChips > highestChips)
                    highestChips = currentChips;
                return true;
            }
            else
                return false;
        }
    }
}
