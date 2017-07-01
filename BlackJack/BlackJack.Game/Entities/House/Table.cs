

using System.Collections.Generic;
using BlackJack.Game.Entities.Card.Interfaces;
using BlackJack.Game.Entities.House.Interfaces;
using BlackJack.Game.Logic.Interfaces;

namespace BlackJack.Game.Entities.House
{
    public class Table : ITable
    {
        public IDeck Deck {get; set; }
        public IDealer Dealer { get; set; }
        public List<IPlayer> Players { get; set; }

        public Table()
        {
            Players = new List<IPlayer>();
        }
    }
}
