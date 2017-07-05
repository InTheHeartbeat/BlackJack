using System.Collections.Generic;
using BlackJack.Logic;

namespace BlackJack.Entities.Card
{
    public class Hand
    {
        public List<BlackJack.Entities.Card.Card> Cards { get; set; }
        public int CurrentScore => _scoreCalculator.CalcHandScore(this);

        private readonly HandScoreCalculator _scoreCalculator;

        public Hand(HandScoreCalculator scoreCalculator)
        {
            _scoreCalculator = scoreCalculator;
            Cards = new List<BlackJack.Entities.Card.Card>();
        }
    }
}
