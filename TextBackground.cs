using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kortspel
{
    internal class TextBackground : Obj
    {
        Color textColor;
        public string text;

        public TextBackground(Texture2D img, Vector2 pos, string text):
           base()
        {
            this.pos = pos;
            this.img = img;
            this.text = text;
            scale = 0.5f;
            CreateBoundingBox(this.img);
            SetOrigin(this.img);
        }


        public void Update(Player player, BlackjackHandler blackjackHandler)
        {
            char firstLetter = text[0];
            if (firstLetter == 'Y')
            {
                text = "Your Chips:" + player.GetChipAmount().ToString();
            }

            if (firstLetter == 'B')
            {
                text = "Bet Chips:" + blackjackHandler.GetBetChips().ToString();
            }
        }
        public void Draw(SpriteBatch sb, SpriteFont font)
        {
            imgColor = Color.White;
            textColor = Color.Black;

            sb.Draw(img, pos, null, imgColor, 0.0f, originPoint, 1f, SpriteEffects.None, 0.0f);

            float x = bb.X - (font.MeasureString(text).X / 2);
            float y = bb.Y - (font.MeasureString(text).Y / 2);

            sb.DrawString(font, text, new Vector2(x, y), textColor);
        }


    }
}
