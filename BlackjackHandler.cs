using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kortspel
{
    public class BlackjackHandler
    {

        int startingChips;
        int betChips;
        int highestChips;
        int currentChips;
        int playerSum;
        int dealerSum;
        CardDeckHandler deckHandler;

        public int GetBetChips()
        {
            return betChips;
        }
        public int CalcPlayerSum(Player player)
        {
            playerSum = 0;
            foreach (Card c in player.GetCardsInHand())
            {
                playerSum += c.ReturnCardValue();
            }
            return playerSum;
        }

        public int GetPlayerSum()
        {
            return playerSum;
        }

        public int CalcDealerSum(Dealer dealer)
        {
            
            foreach (Card c in dealer.GetCardsInHand())
                dealerSum += c.ReturnCardValue();

            return dealerSum;
        }

        public void CalcSums(Player player, Dealer dealer)
        {
            CalcPlayerSum(player);
            CalcDealerSum(dealer);
        }

        public void GameStartSetup(CardDeck deck, Player player)
        {
            deckHandler = new CardDeckHandler();
            deckHandler.shuffleDeck(deck);
            currentChips = player.GetChipAmount();
            startingChips = 1500;
            if (player.GetChipAmount() < startingChips)
                player.SetChipAmount(startingChips);
        }

        public void Bet(int betChips, Player player)
        {
            
            currentChips = player.GetChipAmount();
            this.betChips += betChips;            
            currentChips -= betChips;
            if (currentChips >= 0)
                player.SetChipAmount(currentChips);
            else
                this.betChips -= betChips;
            
        }

        public void RemoveBet (int betChips, Player player)
        {
            currentChips = player.GetChipAmount();
            this.betChips -= betChips;
            currentChips += betChips;
            if (currentChips <= startingChips)
                player.SetChipAmount(currentChips);
            else
                this.betChips += betChips;
        }

        public void RoundStart(CardDeck deck, Player player, Dealer dealer, Texture2D img)
        {
            player.SetCardsInHand(deckHandler.GiveCards(2, deck));
            dealer.SetCardsInHand(deckHandler.GiveCards(2, deck));
            dealer.DealerFlip(dealer, img);

        }

        public bool PlayerHit(CardDeck deck, Player player, Dealer dealer)
        {
            player.AddCardsToHand(deckHandler.GiveCards(1, deck), player);
            playerSum = CalcPlayerSum(player);

            if (playerSum > 21)
            {
                return true;
            }
            else
                return false;
        }

        public void PlayerStand (CardDeck deck, Dealer dealer, Player player, Texture2D img)
        {
            dealer.DealerFlip(dealer, img);

            while (dealerSum < 17)
            {
                dealer.AddCardsToHand(deckHandler.GiveCards(1, deck), player);
            }
            ResultCalcAndChipExchange(player);
        }
        public void ResultCalcAndChipExchange(Player player)
        {
            if (playerSum > dealerSum && playerSum <= 21)
            {
                currentChips += betChips;
                int wonChips = betChips * 15 / 10;
                currentChips += wonChips;
                if (currentChips > highestChips)
                    highestChips = currentChips;
                player.SetChipAmount(currentChips);
            }
                
        }
    }
}
