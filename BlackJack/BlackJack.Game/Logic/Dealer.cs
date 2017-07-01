using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Game.Entities.Card.Interfaces;
using BlackJack.Game.Entities.House.Interfaces;
using BlackJack.Game.Logic.Interfaces;

namespace BlackJack.Game.Logic
{
    public class Dealer : IDealer
    {
        public IHand Hand { get; set; }
        public ITable Table { get; set; }
        public void RequestBet(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public void RequestAction(IPlayer player)
        {
            throw new NotImplementedException();
        }
    }
}
