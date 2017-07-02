using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Game.Entities.Card.Interfaces;

namespace BlackJack.Game.Logic.Interfaces
{
    public interface IGameInformingOperations
    {
        void OnRequestBet(IPlayer player);
        void OnRequestAction(IPlayer player);
        void OnPullCard(ICard pullCard);
        void OnPullHoleCard(ICard pullCard);        
        void OnHitCard(IPlayer player);
        void OnPlayerStand(IPlayer player);
        void OnGiveCard(ICardHolder holder);
    }
}
