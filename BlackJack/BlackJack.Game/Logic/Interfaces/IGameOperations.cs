﻿
using System.Collections.Generic;


namespace BlackJack.Game.Logic.Interfaces
{
    public interface IGameOperations
    {        
        int RequestPlayersCount();
        IEnumerable<IPlayer> GetPlayers(int playerCount);
        bool RequestContinue();
        bool RequestRestart();
    }
}
