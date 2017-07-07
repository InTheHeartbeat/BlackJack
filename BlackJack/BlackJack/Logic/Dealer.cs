using System.Collections.Generic;
using BlackJack.Base;
using BlackJack.ConsoleOperations;
using BlackJack.Entities.Card;
using BlackJack.Entities.Card.Interfaces;
using BlackJack.Entities.House;
using BlackJack.Enums;

namespace BlackJack.Logic
{
    public class Dealer : ICardHolder
    {
        public int Id { get; set; }        
        public Hand Hand { get; set; }
        public Table Table { get; set; }

        private readonly ConsoleGameInformingOperations _informingOperations;

        private Dictionary<Player, double> _playerPairBet;

        public Dealer(ConsoleGameInformingOperations informingOperations, Table table)
        {
            _informingOperations = informingOperations;
            Table = table;
            Hand = new Hand(ConfigProvider.Provider.CurrentConfig.ScoreCalculator);
            _playerPairBet = new Dictionary<Player, double>();
        }
        
        public void RequestBet(Player player)
        {
            _informingOperations.OnRequestBet(player);
            _playerPairBet.Add(player,player.MakeBet());
        }

        public PlayerAction? RequestAction(Player player)
        {
            _informingOperations.OnRequestAction(player);
            return player.DoAction();
        }

        public double GetBetValue(Player player)
        {
            return _playerPairBet[player];
        }
    }
}
