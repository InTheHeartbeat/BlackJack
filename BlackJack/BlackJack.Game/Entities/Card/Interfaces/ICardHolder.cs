using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Game.Entities.Card.Interfaces
{
    public interface ICardHolder
    {
        int Id { get; set; }
        IHand Hand { get; set; }
    }
}
