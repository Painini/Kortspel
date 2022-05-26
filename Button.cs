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
            scale = 1f;
            CreateBoundingBox();
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

        public void SetOrigin(int width, int height)
        {
            originPoint = new Vector2(width / 2, height / 2);
        }

        public void CreateBoundingBox()
        {
            int width = 200;
            int height = 100;
            bb = new Rectangle((int)pos.X, (int)pos.Y, width, height);

            SetOrigin(width, height);

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
            
            sb.Draw(img, bb, null, imgColor, 0.0f, originPoint, SpriteEffects.None, 0.0f);

            float x = bb.X + 60 - (font.MeasureString(text).X / 2);
            float y = bb.Y + 30 - (font.MeasureString(text).Y / 2);

            sb.DrawString(font, text, new Vector2(x, y), textColor);
        }







    }
}
