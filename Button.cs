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
        Color textColor;
        public string text;


        //Fortsätt här sen
        public Button(Texture2D img, Vector2 pos, string text):
            base()
        {
            this.pos = pos;
            this.img = img;
            this.text = text;
            scale = 0.5f;
            CreateBoundingBox(this.img);
            SetOrigin(this.img);
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

        public void Draw(SpriteBatch sb, SpriteFont font)
        {
            imgColor = Color.White;
            textColor = Color.Black;
            //if (isHovering)
            //{
            //    if (MouseReader.mouseState.LeftButton == ButtonState.Released && MouseReader.oldMouseState.LeftButton == ButtonState.Pressed)
            //    {
            //        imgColor = Color.Gray;
            //    }
                
            //}
            
            sb.Draw(img, pos, null, imgColor, 0.0f, originPoint, 0.3f, SpriteEffects.None, 0.0f);

            float x = bb.X - (font.MeasureString(text).X / 2);
            float y = bb.Y - (font.MeasureString(text).Y / 2);

            sb.DrawString(font, text, new Vector2(x, y), textColor);
        }







    }
}
