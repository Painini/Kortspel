using System;
using System.Collections.Generic;
using System.Text;

namespace Kortspel
{
    internal static class GamestateHandler
    {

        static public Gamestate.Gamestates ChangeGameState(Gamestate.Gamestates currentState, Gamestate.Gamestates newState)
        {
            currentState = newState;
            return currentState;
        }

    }
}
