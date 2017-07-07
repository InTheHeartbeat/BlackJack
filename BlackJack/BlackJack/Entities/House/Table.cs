using System.Collections.Generic;
using BlackJack.Entities.Card;
using BlackJack.Logic;


namespace BlackJack.Entities.House
{
    public class Table
    {
        public Deck Deck {get; set; }
        public Dealer Dealer { get; set; }
        public List<Player> Players { get; set; }

        public Table()
        {
            Players = new List<Player>();
        }
    }
}
