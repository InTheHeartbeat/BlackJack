using System.Collections.Generic;
using BlackJack.Game.Entities.Card.Interfaces;
using BlackJack.Game.Logic.Interfaces;

namespace BlackJack.Game.Entities.House.Interfaces
{
    public interface ITable : IReadOnlyTable
    {
        IDeck Deck { get; set; }
        new IDealer Dealer { get; set; }
        List<IPlayer> Players { get; set; }
    }
}
