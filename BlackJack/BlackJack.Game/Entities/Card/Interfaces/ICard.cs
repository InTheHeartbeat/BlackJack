using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Game.Enums;

namespace BlackJack.Game.Entities.Card.Interfaces
{
    public interface ICard
    {
        Face Face { get; set; }
        Suit Suit { get; set; }
    }
}
