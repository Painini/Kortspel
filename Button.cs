using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Kortspel
{
    public class Button
    {
        Rectangle buttDim;
        Vector2 buttPosition;
        bool isHovering;
        SpriteFont font;
        Texture2D texture;
        Color buttColor;
        Color textColor;
        public string buttText;


        //Fortsätt här sen
        public Button(Vector2 position, Texture2D texture)
        {
            buttPosition = position;
            this.texture = texture;
            CreateRectangle();
        }

        public void SetButtColor(Color color)
        {
            buttColor = color;
        }

        public void SetPos(Vector2 newPos)
        {
            buttPosition = newPos;
        }

        public Vector2 GetPos()
        {
            return buttPosition;
        }

        public void SetPos(string newText)
        {
            buttText = newText;
        }

        public void CreateRectangle()
        {
            buttDim = new Rectangle((int)buttPosition.X, (int)buttPosition.Y, texture.Width, texture.Height);
        }

        public void Update(GameTime gameTime)
        {
            Rectangle mouseRectangle = new Rectangle(MouseReader.mouseState.X, MouseReader.mouseState.Y, 1, 1);

            isHovering = false;

            if(mouseRectangle.Intersects(buttDim))
            {
                isHovering = true;

            }

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            buttColor = Color.White;
            textColor = Color.Black;

            if (isHovering)
            {
                buttColor = Color.Gray;
            }

            spriteBatch.Draw(texture, buttDim, buttColor);

            float x = (buttDim.X + (buttDim.Width / 2)) - (font.MeasureString(buttText).X / 2);
            float y = (buttDim.Y + (buttDim.Height / 2)) - (font.MeasureString(buttText).Y / 2);

            spriteBatch.DrawString(font, buttText, new Vector2(x, y), textColor);
        }







    }
}
