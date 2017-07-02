using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        public void Handle(IPlayer player, PlayerAction action)
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

        private void HandleStand(IPlayer player)
        {
            _informingOperations.OnPlayerStand(player);
        }

        private void HandleHit(IPlayer player)
        {
            if (player.Hand.CurrentScore < 21 && !player.Lose)
            {
                _informingOperations.OnHitCard(player);
                player.Hand.Cards.Add(CardsGiver.PullCard(_table, _informingOperations));
            }
        }
    }
}
