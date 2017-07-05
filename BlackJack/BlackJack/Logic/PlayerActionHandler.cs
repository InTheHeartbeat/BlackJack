using BlackJack.Base;
using BlackJack.Entities.House;
using BlackJack.Enums;
using BlackJack.Logic.Interfaces;

namespace BlackJack.Logic
{
    public class PlayerActionHandler
    {
        private Table _table;
        private IGameInformingOperations _informingOperations;

        public PlayerActionHandler(Table table, IGameInformingOperations informingOperations)
        {
            _table = table;
            _informingOperations = informingOperations;
        }


        public void HandleAction(IPlayer player, PlayerAction? action)
        {
            if (action == PlayerAction.Hit)
            {
                HandleHit(player);
            }
            if (action == PlayerAction.Stand)
            {
                HandleStand(player);
            }
        }

        public void HandleLostPlayer(IPlayer player)
        {
            player.Bankroll -= _table.Dealer.GetBetValue(player);
            _informingOperations.OnPlayerLost(player);

            if (player.Bankroll <= 0)
            {
                _table.Players.Remove(player);
                _informingOperations.OnPlayerBankrupt(player);
            }
        }

        public void HandleWinner(IPlayer player)
        {
            player.Bankroll += _table.Dealer.GetBetValue(player);
            _informingOperations.OnPlayerWon(player);
        }

        public void HandleNativeBlackJackWinner(IPlayer player)
        {
            player.Bankroll += _table.Dealer.GetBetValue(player) * ConfigProvider.Provider.CurrentConfig.BlackJackRatio;
            _informingOperations.OnPlayerWonBlackJack(player);
        }

        public void HandleStandoff(IPlayer player)
        {
            _informingOperations.OnPlayerStandoff(player);
        }

        private void HandleStand(IPlayer player)
        {
            _informingOperations.OnPlayerStand(player);
        }

        private void HandleHit(IPlayer player)
        {
            if (player.Hand.CurrentScore < ConfigProvider.Provider.CurrentConfig.BlackJackNumber && !player.Lost)
            {
                _informingOperations.OnHitCard(player);
                player.Hand.Cards.Add(CardsGiver.PullCard(_table, _informingOperations));
                _informingOperations.ShowPlayerScore(player);

                if (player.Hand.CurrentScore > ConfigProvider.Provider.CurrentConfig.BlackJackNumber)
                {
                    player.Lost = true;
                }                                                        
            }
        }        
    }
}
