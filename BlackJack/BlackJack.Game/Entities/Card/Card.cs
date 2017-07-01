using BlackJack.Game.Entities.Card.Interfaces;
using BlackJack.Game.Enums;

namespace BlackJack.Game.Entities.Card
{
    public class Card : ICard
    {
        public Face Face { get; set; }
        public Suit Suit { get; set; }
    }
}
