using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kortspel
{
    internal class BoundingBoxHandler
    {
        //BoundingBoxHandler class includes methods with logic for Rectangles that envelop objects, making them interactable.
        public void CardHoverLogic(Player player)
        {
                for (int i = 0; i < player.GetCardsInHand().Count; i++)
                {
                    //Hover doesn't work. Will work on later maybe
                    if (player.GetCardsInHand()[i].GetBoundingBox().Contains(MouseReader.mouseState.Position))
                    {
                        player.GetCardsInHand()[i].SetImgColor(Color.White);
                    }
                }    
        }

        public int Click(Obj obj)
        {
            if (MouseReader.LeftClick() && obj.GetBoundingBox().Contains(MouseReader.mouseState.Position))
            {
                return 1;
            }


            else if (MouseReader.RightClick() && obj.GetBoundingBox().Contains(MouseReader.mouseState.Position))
            {
                return 2;
            }

            else
                return 0;

        }

        public void Update()
        {
        }

        
    }
}
