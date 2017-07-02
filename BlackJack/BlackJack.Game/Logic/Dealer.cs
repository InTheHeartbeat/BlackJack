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
        public int Id { get; set; }        
        public IHand Hand { get; set; }
        public ITable Table { get; set; }

        private readonly IGameInformingOperations _informingOperations;

        public Dealer(IGameInformingOperations informingOperations)
        {
            _informingOperations = informingOperations;
        }
        
        public void RequestBet(IPlayer player)
        {
            _informingOperations.OnRequestBet(player);
            player.MakeBet();
        }

        public PlayerAction? RequestAction(IPlayer player)
        {
            _informingOperations.OnRequestAction(player);
            return player.DoAction();
        }
    }
}
