﻿using System.Collections.Generic;
using BlackJack.Game.Entities.Card.Interfaces;
using BlackJack.Game.Logic;
using BlackJack.Game.Logic.Interfaces;

namespace BlackJack.Game.Entities.Card
{
    public class Hand
    {
        public List<Card> Cards { get; set; }
        public int CurrentScore => _scoreCalculator.CalcHandScore(this);

        private readonly HandScoreCalculator _scoreCalculator;

        public Hand(HandScoreCalculator scoreCalculator)
        {
            _scoreCalculator = scoreCalculator;
            Cards = new List<Card>();
        }
    }
}
