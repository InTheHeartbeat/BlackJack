using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Game.Entities.Interfaces
{
    public interface IDealer : IPlayer
    {
        new ITable Table { get; set; }
        void RequestBet(IPlayer player);
        void RequestAction(IPlayer player);
    }
}
