using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Game.Base;
using BlackJack.Game.Entities.Card;
using BlackJack.Game.Entities.Card.Interfaces;
using BlackJack.Game.Entities.House;
using BlackJack.Game.Entities.House.Interfaces;
using BlackJack.Game.Enums;
using BlackJack.Game.Logic.Interfaces;

namespace BlackJack.Game.Logic
{
    public class GameLogicController :IGameLogicController
    {
        public ITable Table { get; }
        public int PlayersCount { get; internal set; }

        private IGameOperations _operations;
        private IGameInformingOperations _informingOperations;

        private IPlayerActionHandler _actionHandler;

        public GameLogicController(IGameOperations operations, IGameInformingOperations informingOperations)
        {
            _operations = operations;
            _informingOperations = informingOperations;            

            Table = new Table()
            {
                Dealer = new Dealer(informingOperations),
                Deck = new Deck()
            };

            _actionHandler = new PlayerActionHandler(Table, _informingOperations);
        }

        public void RunGame()
        {
            InitializePlayers();   
            RequestPlayersBets();
            PrepareDeck();
            GiveOutCards();

            
        }
        private void InitializePlayers()
        {
            RequestPlayersCount();
            Table.Players.AddRange(_operations.GetPlayers());
        }
        private void RequestPlayersCount()
        {
            PlayersCount = _operations.RequestPlayersCount();
        }
        private void RequestPlayersBets()
        {
            Table.Players.ForEach(player=>Table.Dealer.RequestBet(player));
        }

        private void PrepareDeck()
        {
            Table.Deck = new Deck();
        }

        private void GiveOutCards()
        {
            for (int i = 0; i < GameConfigSingleton.Config.InitialCardsCount; i++)
            {                  
                Table.Players.ForEach(GiveCard);                
                GiveCard(Table.Dealer);
            }
        }

        private void GiveCard(ICardHolder holder)
        {
            CardsGiver.GiveCard(holder, Table, _informingOperations);
        }
        private void TypingCards()
        {
            for (int i = 0; i < Table.Players.Count; i++)
            {
                _informingOperations.OnChoicePlayerAction(Table.Players[i]);
                PlayerAction choosedAction = Table.Dealer.RequestAction(Table.Players[i]);
                _actionHandler.Handle(Table.Players[i], choosedAction);
            }
        }
    }
}
