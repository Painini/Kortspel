using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kortspel
{
    public class Player : Participator
    {
        //Player class is meant to hold the cards that blackjackhandler uses to compute different results.
        string name;
        int chipAmount;
        public Player (string name, int chipAmount)
        {
            this.name = name;
            this.chipAmount = chipAmount;
        }

        public int GetChipAmount()
        {
            return chipAmount;
        }

        public void SetChipAmount(int newChipAmount)
        {
            chipAmount = newChipAmount;
        }

    }
}
