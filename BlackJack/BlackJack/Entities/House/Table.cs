using System.Collections.Generic;
using BlackJack.Entities.Card;
using BlackJack.Logic.Interfaces;

namespace BlackJack.Entities.House
{
    public class Table
    {
        public Deck Deck {get; set; }
        public IDealer Dealer { get; set; }
        public List<IPlayer> Players { get; set; }

        public Table()
        {
            Players = new List<IPlayer>();
        }
    }
}
