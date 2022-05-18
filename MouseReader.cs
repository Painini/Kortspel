using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Kortspel
{
    static class MouseReader
    {
		//Here all of the variables for the MouseReader class are defined.


		public static MouseState mouseState, oldMouseState = Mouse.GetState();

		//The LeftClick function checks if the Left Click button has been pressed and if it has been released.

		public static bool LeftClick()
		{
			return mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released;
		}
		public static bool RightClick()
		{
			return mouseState.RightButton == ButtonState.Pressed && oldMouseState.RightButton == ButtonState.Released;
		}

		//Update is called in the main Update function in Game1.

		public static void Update()
		{
			oldMouseState = mouseState;
			mouseState = Mouse.GetState();

		}
	}
}
