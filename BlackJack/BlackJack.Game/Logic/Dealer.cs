using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Game.Base;
using BlackJack.Game.Entities.Card;
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

        private Dictionary<IPlayer, double> _playerPairBet;

        public Dealer(IGameInformingOperations informingOperations, ITable table)
        {
            _informingOperations = informingOperations;
            Table = table;
            Hand = new Hand(ConfigProvider.Provider.CurrentConfig.HandScoreCalculator);
            _playerPairBet = new Dictionary<IPlayer, double>();
        }
        
        public void RequestBet(IPlayer player)
        {
            _informingOperations.OnRequestBet(player);
            _playerPairBet.Add(player,player.MakeBet());
        }

        public PlayerAction? RequestAction(IPlayer player)
        {
            _informingOperations.OnRequestAction(player);
            return player.DoAction();
        }

        public double GetBetValue(IPlayer player)
        {
            return _playerPairBet[player];
        }
    }
}
