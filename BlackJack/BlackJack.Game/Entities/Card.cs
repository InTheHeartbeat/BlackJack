using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Game.Entities.Enums;
using BlackJack.Game.Entities.Interfaces;

namespace BlackJack.Game.Entities
{
    public class Card : ICard
    {
        public Face Face { get; set; }
        public Suit Suit { get; set; }
    }
}
