using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Game.Entities.Card.Interfaces;
using BlackJack.Game.Entities.House.Interfaces;
using BlackJack.Game.Enums;
using BlackJack.Game.Logic.Interfaces;

namespace BlackJack.Game.Logic
{
    public class Dealer : IDealer
    {
        public IHand Hand { get; set; }
        public ITable Table { get; set; }

        private readonly IGameOperations _operations;

        public Dealer(IGameOperations operations)
        {
            _operations = operations;
        }
        
        public void RequestBet(IPlayer player)
        {
            _operations.RequestBet(player);
            player.MakeBet();
        }

        public PlayerAction RequestAction(IPlayer player)
        {
            _operations.RequestAction(player);
            return player.DoAction();
        }
    }
}
