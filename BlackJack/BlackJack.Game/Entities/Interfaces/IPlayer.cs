using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Game.Entities.Enums;

namespace BlackJack.Game.Entities.Interfaces
{
    public interface IPlayer
    {
        IReadOnlyTable Table { get; set; }
        IHand Hand { get; set; }        
        double MakeBet();
        PlayerAction DoAction();
    }
}
