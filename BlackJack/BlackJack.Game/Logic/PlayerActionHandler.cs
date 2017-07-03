using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Game.Base;
using BlackJack.Game.Entities.House;
using BlackJack.Game.Entities.House.Interfaces;
using BlackJack.Game.Enums;
using BlackJack.Game.Logic.Interfaces;

namespace BlackJack.Game.Logic
{
    public class PlayerActionHandler : IPlayerActionHandler
    {
        private ITable _table;
        private IGameInformingOperations _informingOperations;

        public PlayerActionHandler(ITable table, IGameInformingOperations informingOperations)
        {
            _table = table;
            _informingOperations = informingOperations;
        }


        public void HandleAction(IPlayer player, PlayerAction? action)
        {
            switch (action)
            {
                case PlayerAction.Hit:
                    HandleHit(player);
                    break;
                    case PlayerAction.Stand:
                        HandleStand(player);break;
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
                    player.Lost = true;                                                        
            }
        }        
    }
}
