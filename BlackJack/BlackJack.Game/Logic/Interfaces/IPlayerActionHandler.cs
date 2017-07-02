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
        void Handle(IPlayer player, PlayerAction action);
    }
}
