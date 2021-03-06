﻿using BlackJack.Game.Entities.Card.Interfaces;
using BlackJack.Game.Enums;

namespace BlackJack.Game.Logic.Interfaces
{
    public interface IPlayer : ICardHolder
    {        
        double Bankroll { get; set; }
        bool Lost { get; set; }        
        double MakeBet();
        PlayerAction? DoAction();
    }
}
