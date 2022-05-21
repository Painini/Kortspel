using System;
using System.Collections.Generic;
using System.Text;

namespace Kortspel
{
    class Player : Participator
    {
        string name;
        int chipAmount;
        public Player (string name, int chipAmount)
        {
            this.name = name;
            this.chipAmount = chipAmount;
        }

    }
}
