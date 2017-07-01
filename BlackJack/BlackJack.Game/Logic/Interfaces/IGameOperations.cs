using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Game.Entities.Card.Interfaces;

namespace BlackJack.Game.Logic.Interfaces
{
    public interface IGameOperations
    {
        void OnRequestBet(IPlayer player);
        void OnRequestAction(IPlayer player);
        int RequestPlayersCount();
        IEnumerable<IPlayer> GetPlayers();
        void OnPullCard(ICard pullCard);
        void OnPullHoleCard(ICard pullCard);
    }
}
