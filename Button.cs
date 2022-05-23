using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Kortspel
{
    public class Button: Obj
    {
        bool isHovering;
        SpriteFont font;
        Color imgColor;
        Color textColor;
        public string text;


        //Fortsätt här sen
        public Button(Texture2D img ,Vector2 pos):
            base()
        {
            this.pos = pos;
            this.img = img;
            CreateRectangle();
        }

        public void SetButtColor(Color color)
        {
            imgColor = color;
        }

        public void SetPos(Vector2 newPos)
        {
            pos = newPos;
        }

        public Vector2 GetPos()
        {
            return pos;
        }

        public void SetPos(string newText)
        {
            text = newText;
        }

        public void Update(GameTime gameTime)
        {
            Rectangle mouseRectangle = new Rectangle(MouseReader.mouseState.X, MouseReader.mouseState.Y, 1, 1);

            isHovering = false;

            if(mouseRectangle.Intersects(bb))
            {
                isHovering = true;

            }

        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            imgColor = Color.White;
            textColor = Color.Black;

            if (isHovering)
            {
                imgColor = Color.Gray;
            }

            sb.Draw(img, bb, imgColor);

            float x = (bb.X + (bb.Width / 2)) - (font.MeasureString(text).X / 2);
            float y = (bb.Y + (bb.Height / 2)) - (font.MeasureString(text).Y / 2);

            sb.DrawString(font, text, new Vector2(x, y), textColor);
        }







    }
}
