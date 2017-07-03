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

        public GameLogicController(IGameOperations operations, IGameInformingOperations informingOperations, GameConfig config)
        {
            if (config != null)
                ConfigProvider.Provider.CurrentConfig = config;

            Table = new Table();

            _operations = operations;
            _informingOperations = informingOperations;            
            _actionHandler = new PlayerActionHandler(Table, _informingOperations);            
        }

        public void RunGame()
        {
            InitializePlayers();
            while (true)
            {
                PrepareTable();

                RequestPlayersBets();                
                GiveOutCards();

                TypingCards();
                DealerPlay();

                FinalizeRound();

                if(!_operations.RequestContinue())
                    break;                
            }
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

        private void PrepareTable()
        {            
            Table.Dealer = new Dealer(_informingOperations, Table);
            Table.Deck = new Deck();

            foreach (IPlayer player in Table.Players)
            {
                player.Lost = false;
                player.Hand.Cards.Clear();                
            }
        }

        private void GiveOutCards()
        {
            for (int i = 0; i < ConfigProvider.Provider.CurrentConfig.InitialCardsCount; i++)
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
                    else if (player.Hand.CurrentScore == ConfigProvider.Provider.CurrentConfig.BlackJackNumber)
                        isStandPlayers[player] = true;
                    else if (!isStandPlayers[player])
                    {
                        PlayerAction? choosedAction = Table.Dealer.RequestAction(player);
                        _actionHandler.HandleAction(player, choosedAction);

                        if (choosedAction == PlayerAction.Stand)
                            isStandPlayers[player] = true;
                    }
                }
            }
        }

        private void DealerPlay()
        {
            _informingOperations.ShowDealerHoleCard(Table.Dealer.Hand.Cards.Last());
            _informingOperations.ShowPlayerScore(Table.Dealer);

            while (Table.Dealer.Hand.CurrentScore <= ConfigProvider.Provider.CurrentConfig.ScoreLimitOfDealerAbilityToTakeCards)
            {
                GiveCard(Table.Dealer);
                _informingOperations.ShowPlayerScore(Table.Dealer);
            }
        }

        private bool CheckNativeBlackJack(IPlayer player)
        {
            if (player.Hand.CurrentScore == ConfigProvider.Provider.CurrentConfig.BlackJackNumber && player.Hand.Cards.Count <= ConfigProvider.Provider.CurrentConfig.CardsCountForNativeBlackJack)
                return true;
            return false;
        }

        private void FinalizeRound()
        {
            Table.Players.Where(CheckNativeBlackJack)
                .ToList()
                .ForEach(_actionHandler.HandleNativeBlackJackWinner);

            Table.Players.Where(player => !player.Lost && (player.Hand.CurrentScore > Table.Dealer.Hand.CurrentScore || Table.Dealer.Hand.CurrentScore > ConfigProvider.Provider.CurrentConfig.BlackJackNumber) && !CheckNativeBlackJack(player))
                .ToList()
                .ForEach(_actionHandler.HandleWinner);

            Table.Players.Where(player => !player.Lost && player.Hand.CurrentScore == Table.Dealer.Hand.CurrentScore)
                .ToList()
                .ForEach(_actionHandler.HandleStandoff);

            Table.Players.Where(player => player.Lost || (Table.Dealer.Hand.CurrentScore <= ConfigProvider.Provider.CurrentConfig.BlackJackNumber && player.Hand.CurrentScore < Table.Dealer.Hand.CurrentScore))
                .ToList()
                .ForEach(_actionHandler.HandleLostPlayer);                        
        }                
    }
}
