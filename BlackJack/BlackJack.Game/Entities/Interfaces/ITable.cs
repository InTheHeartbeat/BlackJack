using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Game.Entities.Interfaces
{
    public interface ITable : IReadOnlyTable
    {
        IHand Hand { get; set; }
        new IDealer Dealer { get; set; }
        List<IPlayer> Players { get; set; }
    }
}
