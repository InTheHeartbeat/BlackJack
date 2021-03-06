﻿using BlackJack.Game.Entities.Card.Interfaces;
using BlackJack.Game.Entities.House;
using BlackJack.Game.Enums;

namespace BlackJack.Game.Logic.Interfaces
{
    public interface IDealer : ICardHolder
    {        
        void RequestBet(IPlayer player);
        PlayerAction? RequestAction(IPlayer player);
        double GetBetValue(IPlayer player);
    }
}
