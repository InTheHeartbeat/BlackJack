using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Game.Entities.Interfaces
{
    public interface ICardHolder
    {
        IHand Hand { get; set; }
    }
}
