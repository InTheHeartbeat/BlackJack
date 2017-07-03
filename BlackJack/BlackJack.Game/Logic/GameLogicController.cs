using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    public class GameLogicController : IGameLogicController
    {
        public int PlayersCount { get; internal set; }

        private ITable Table { get; }

        private readonly IGameOperations _operations;
        private readonly IGameInformingOperations _informingOperations;

        private readonly IPlayerActionHandler _actionHandler;

        public GameLogicController(IGameOperations operations, IGameInformingOperations informingOperations)
        {
            _operations = operations;
            _informingOperations = informingOperations;

            Table = new Table()
            {
                Dealer = new Dealer(informingOperations, Table)
            };

            _actionHandler = new PlayerActionHandler(Table, _informingOperations);
        }

        public void RunGame()
        {
            InitializePlayers();
            RequestPlayersBets();
            PrepareDeck();
            GiveOutCards();

            TypingCards();
            DealerPlay();

            FinalizeRound();
        }

        private void InitializePlayers()
        {
            RequestPlayersCount();
            Table.Players.AddRange(_operations.GetPlayers(PlayersCount, Table));
        }

        private void RequestPlayersCount()
        {
            PlayersCount = _operations.RequestPlayersCount();
        }

        private void RequestPlayersBets()
        {
            Table.Players.ForEach(player => Table.Dealer.RequestBet(player));
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
            Table.Players.ForEach(_informingOperations.ShowPlayerScore);
        }

        private void GiveCard(ICardHolder holder)
        {
            _informingOperations.OnGiveCard(holder);
            CardsGiver.GiveCard(holder, Table, _informingOperations);
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
        }

        private void TypingCards()
        {
            Dictionary<IPlayer, bool> isStandPlayers = Table.Players.ToDictionary(player => player, player => false);

            while (isStandPlayers.Values.Contains(false))
            {
                foreach (IPlayer player in Table.Players)
                {
                    if (player.Lost)
                        isStandPlayers[player] = true;
                    else if (CheckNativeBlackJack(player))
                        isStandPlayers[player] = true;
                    else if (player.Hand.CurrentScore == 21)
                        isStandPlayers[player] = true;
                    else if (!isStandPlayers[player])
                    {
                        PlayerAction? choosedAction = Table.Dealer.RequestAction(player);
                        _actionHandler.Handle(player, choosedAction);

                        if (choosedAction == PlayerAction.Stand)
                            isStandPlayers[player] = true;
                    }
                }
            }
        }

        private bool CheckNativeBlackJack(IPlayer player)
        {
            if (player.Hand.CurrentScore == 21 && player.Hand.Cards.Count <= 2)
                return true;
            return false;
        }

        private void FinalizeRound()
        {
            Table.Players.Where(CheckNativeBlackJack)
                .ToList()
                .ForEach(HandleNativeBlackJackWinner);

            Table.Players.Where(player => !player.Lost && (player.Hand.CurrentScore > Table.Dealer.Hand.CurrentScore || Table.Dealer.Hand.CurrentScore > 21) && !CheckNativeBlackJack(player))
                .ToList()
                .ForEach(HandleWinner);

            Table.Players.Where(player => !player.Lost && player.Hand.CurrentScore == Table.Dealer.Hand.CurrentScore)
                .ToList()
                .ForEach(HandleStandoff);

            Table.Players.Where(player => player.Lost || (Table.Dealer.Hand.CurrentScore <= 21 && player.Hand.CurrentScore < Table.Dealer.Hand.CurrentScore))
                .ToList()
                .ForEach(HandleLostPlayer);                        
        }

        private void HandleLostPlayer(IPlayer player)
        {
            player.Bankroll -= Table.Dealer.GetBetValue(player);
            _informingOperations.OnPlayerLost(player);
        }

        private void HandleWinner(IPlayer player)
        {
            player.Bankroll += Table.Dealer.GetBetValue(player);
            _informingOperations.OnPlayerWon(player);
        }

        private void HandleNativeBlackJackWinner(IPlayer player)
        {
            player.Bankroll += Table.Dealer.GetBetValue(player) * 1.5;
            _informingOperations.OnPlayerWonBlackJack(player);
        }

        private void HandleStandoff(IPlayer player)
        {
            _informingOperations.OnPlayerStandoff(player);
        }

        private void DealerPlay()
        {
            _informingOperations.ShowDealerHoleCard(Table.Dealer.Hand.Cards.Last());
            _informingOperations.ShowPlayerScore(Table.Dealer);

            while (Table.Dealer.Hand.CurrentScore <= 16)
            {
                GiveCard(Table.Dealer);
                _informingOperations.ShowPlayerScore(Table.Dealer);
            }
        }
    }
}
