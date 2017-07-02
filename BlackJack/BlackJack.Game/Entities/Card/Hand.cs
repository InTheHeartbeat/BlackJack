using System.Collections.Generic;
using BlackJack.Game.Entities.Card.Interfaces;
using BlackJack.Game.Logic.Interfaces;

namespace BlackJack.Game.Entities.Card
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; set; }
        public int CurrentScore => _scoreCalculator.CalcHandScore(this);

        private readonly IHandScoreCalculator _scoreCalculator;

        public Hand(IHandScoreCalculator scoreCalculator)
        {
            _scoreCalculator = scoreCalculator;
            Cards = new List<ICard>();
        }
    }
}
