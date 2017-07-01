using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Game.Entities.Interfaces
{
    public interface IHand
    {
        IList<ICard> Cards { get; set; }
        int CurrentScore { get; set; }
    }
}
