using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Game.Entities.Interfaces;

namespace BlackJack.Game.Entities
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; set; }
        public int CurrentScore { get; set; }
    }
}
