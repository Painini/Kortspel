using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kortspel
{
    internal class BoundingBoxHandler
    {

        public void CardHoverLogic(Player player)
        {
            for (int i = 0; i < player.GetCardsInHand().Count; i++)
            {
                //Hover doesn't work
                if (player.GetCardsInHand()[i].GetBoundingBox().Contains(MouseReader.mouseState.Position))
                {
                    player.GetCardsInHand()[i].SetImgColor(Color.White);
                }              
            }
        }

        public void Update()
        {
            
        }

        
    }
}
