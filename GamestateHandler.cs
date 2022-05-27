using System;
using System.Collections.Generic;
using System.Text;

namespace Kortspel
{
    internal static class GamestateHandler
    {
        //Changes Gamestate.
        static public Gamestate.Gamestates ChangeGameState(Gamestate.Gamestates currentState, Gamestate.Gamestates newState)
        {
            currentState = newState;
            return currentState;
        }

    }
}
