using System.Collections.Generic;
using System.Linq;
using BlackJack.Base;
using BlackJack.ConsoleOperations;
using BlackJack.Entities.Card;
using BlackJack.Entities.Card.Interfaces;
using BlackJack.Entities.House;
using BlackJack.Enums;

namespace BlackJack.Logic
{
    public class GameLogicController
    {
        public int PlayersCount { get; internal set; }

        private Table Table { get; }

        private readonly ConsoleGameOperations _operations;
        private readonly ConsoleGameInformingOperations _informingOperations;

        private readonly PlayerActionHandler _actionHandler;

        public GameLogicController(ConsoleGameOperations operations, ConsoleGameInformingOperations informingOperations, GameConfig config)
        {
            if (config != null)
            {
                ConfigProvider.Provider.CurrentConfig = config;
            }

            Table = new Table();

            _operations = operations;
            _informingOperations = informingOperations;            
            _actionHandler = new PlayerActionHandler(Table, _informingOperations);            
        }

        public void RunGame()
        {
            while (true)
            {
                InitializePlayers();
                while (true)
                {
                    if (Table.Players.Count > 0)
                    {
                        PrepareTable();

                        RequestPlayersBets();
                        GiveOutCards();

                        PlayersPlay();
                        DealerPlay();

                        FinalizeRound();

                        if (!_operations.RequestContinue())
                        {
                            break;
                        }
                    }

                    if (Table.Players.Count <= 0)
                    {
                        break;
                    }                    
                }

                if (!_operations.RequestRestart())
                {
                    break;
                }                
            }
        }
        
        private void InitializePlayers()
        {
            RequestPlayersCount();
            Table.Players.Clear();
            Table.Players.AddRange(_operations.GetPlayers(PlayersCount));
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

            foreach (Player player in Table.Players)
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

        private void PlayersPlay()
        {
            List<PlayerState> playerStates = Table.Players
                .Select(player => new PlayerState() {Stand = false, Player = player})
                .ToList();

            while (playerStates.Any(state=>!state.Stand))
            {
                CheckPlayersOutOfGame(playerStates.Where(state=>!state.Stand));
                TypingCardsToActivePlayers(playerStates.Where(state=>!state.Stand));
            }
        }

        private void CheckPlayersOutOfGame(IEnumerable<PlayerState> playerStates)
        {
            foreach (PlayerState state in playerStates)
            {
                state.Stand = state.Player.Lost || CheckNativeBlackJack(state.Player) ||
                              state.Player.Hand.CurrentScore == ConfigProvider.Provider.CurrentConfig.BlackJackNumber;
            }
        }

        private void TypingCardsToActivePlayers(IEnumerable<PlayerState> playerStates)
        {
            foreach (PlayerState state in playerStates)
            {
                PlayerAction? choosedAction = Table.Dealer.RequestAction(state.Player);
                _actionHandler.HandleAction(state.Player, choosedAction);

                if (choosedAction == PlayerAction.Stand)
                {
                    state.Stand = true;
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

        private bool CheckNativeBlackJack(Player player)
        {
            if (player.Hand.CurrentScore == ConfigProvider.Provider.CurrentConfig.BlackJackNumber &&
                player.Hand.Cards.Count <= ConfigProvider.Provider.CurrentConfig.CardsCountForNativeBlackJack)
            {
                return true;
            }
            return false;
        }
    }
}
