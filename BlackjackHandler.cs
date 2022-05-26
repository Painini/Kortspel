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
        int previousChipAmount = 1500;
        CardDeckHandler deckHandler;
        List<Card> listToTakeFrom;



        public void FillListWithDeck(CardDeck deck)
        {
            listToTakeFrom = new List<Card>();
            foreach (Card c in deck.GetDeck())
            {
                listToTakeFrom.Add(c);
            }
        }
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

        public int CalcDealerSum(Dealer dealer)
        {
            dealerSum = 0;
            foreach (Card c in dealer.GetCardsInHand())
                dealerSum += c.ReturnCardValue();

            return dealerSum;
        }

        public int GetPlayerSum()
        {
            return playerSum;
        }

        public int GetDealerSum()
        {
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
            startingChips = previousChipAmount;
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

        public void RemoveBet(int betChips, Player player)
        {
            currentChips = player.GetChipAmount();
            this.betChips -= betChips;
            currentChips += betChips;



            if (currentChips <= previousChipAmount)
                player.SetChipAmount(currentChips);
            else
                this.betChips += betChips;
        }

        public void RoundStart(CardDeck deck, Player player, Dealer dealer, Texture2D img)
        {
        

            player.SetCardsInHand(deckHandler.GiveCards(2, listToTakeFrom));
            dealer.SetCardsInHand(deckHandler.GiveCards(2, listToTakeFrom));
            dealer.DealerFlip(dealer, img);

        }

        public bool PlayerHit(Player player)
        {
            player.AddCardsToHand(deckHandler.GiveCards(1, listToTakeFrom), player);
            playerSum = CalcPlayerSum(player);

            if (ResultChipExchange(player))
            {
                return false;
            }
            else
                return true;
        }


        //Fix PlayerStand method being caught in endless loop - Fixed
        //Fix PlayerStand giving a card to Player !!! / Card gets added to player before PlayerStand is called. Issue must be in Game1.
        //PlayerStand needed to call "CalcDealerSum" after flipping the card. CalcDealerSum also needed to reset dealerSum before doing calculations.
        public bool PlayerStand(Dealer dealer, Texture2D img, Player player)
        {
            dealer.DealerFlip(dealer, img);
            CalcDealerSum(dealer);

            while (dealerSum < 17)
            {
                dealer.AddCardsToHand(deckHandler.GiveCards(1, listToTakeFrom), dealer);
                CalcDealerSum(dealer);
            }
            if (ResultChipExchange(player))
            {
                return true;
            }
            else
                return false;
        }
        //Betchips does not set itself to zero.
        public bool ResultChipExchange(Player player)
        {
            if ((playerSum > dealerSum && playerSum <= 21) || dealerSum > 21)
            {
                currentChips += betChips;
                int wonChips = betChips * 15 / 10;
                currentChips += wonChips;
                previousChipAmount = currentChips;
                if (currentChips > highestChips)
                    highestChips = currentChips;
                player.SetChipAmount(currentChips);
                betChips = 0;
                return true;
                

            }
            else
            {
                betChips = 0;
                return false;
            }
                
            
        }
    }
}
