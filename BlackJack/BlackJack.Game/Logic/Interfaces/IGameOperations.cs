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
        
        int RequestPlayersCount();
        IEnumerable<IPlayer> GetPlayers();        
    }
}
