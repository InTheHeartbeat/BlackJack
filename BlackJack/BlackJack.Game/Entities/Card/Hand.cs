using System.Collections.Generic;
using BlackJack.Game.Entities.Card.Interfaces;

namespace BlackJack.Game.Entities.Card
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; set; }
        public int CurrentScore { get; set; }
    }
}
