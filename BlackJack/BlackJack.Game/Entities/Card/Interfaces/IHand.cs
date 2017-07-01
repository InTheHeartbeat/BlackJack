using System.Collections.Generic;

namespace BlackJack.Game.Entities.Card.Interfaces
{
    public interface IHand
    {
        IList<ICard> Cards { get; set; }
        int CurrentScore { get; set; }
    }
}
