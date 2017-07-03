using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Game.Enums;

namespace BlackJack.Game.Logic.Interfaces
{
    interface IPlayerActionHandler
    {
        void HandleAction(IPlayer player, PlayerAction? action);
        void HandleStandoff(IPlayer player);
        void HandleLostPlayer(IPlayer player);
        void HandleWinner(IPlayer player);
        void HandleNativeBlackJackWinner(IPlayer player);
    }
}
