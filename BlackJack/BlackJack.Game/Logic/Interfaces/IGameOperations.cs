using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Game.Entities.Card.Interfaces;
using BlackJack.Game.Entities.House.Interfaces;

namespace BlackJack.Game.Logic.Interfaces
{
    public interface IGameOperations
    {        
        int RequestPlayersCount();
        IEnumerable<IPlayer> GetPlayers(int playerCount, IReadOnlyTable table);
        bool RequestContinue();
        bool RequestRestart();
    }
}
