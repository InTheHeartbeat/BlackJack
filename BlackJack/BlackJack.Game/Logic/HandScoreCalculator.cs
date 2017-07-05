using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Game.Base;
using BlackJack.Game.Entities.Card;
using BlackJack.Game.Entities.Card.Interfaces;
using BlackJack.Game.Enums;
using BlackJack.Game.Logic.Interfaces;

namespace BlackJack.Game.Logic
{
    public class HandScoreCalculator
    {
        private readonly object _locker = new object();

        public int CalcHandScore(Hand hand)
        {
            lock (_locker)
            {
                if (hand.Cards.Any(card => card.Face == Face.Ace))
                {
                    return CalcSoftHandScore(hand.Cards);
                }
                return CalcHardHandScore(hand.Cards);
            }
        }

        private int CalcSoftHandScore(List<Card> hand)
        {
            int score = CalcHardHandScore(hand);

            if ((score + ConfigProvider.Provider.CurrentConfig.FirstAceScore) <=
                ConfigProvider.Provider.CurrentConfig.BlackJackNumber)
            {
                return score + ConfigProvider.Provider.CurrentConfig.FirstAceScore;
            }

            if ((score + ConfigProvider.Provider.CurrentConfig.FirstAceScore) >
                ConfigProvider.Provider.CurrentConfig.BlackJackNumber)
            {
                return score + ConfigProvider.Provider.CurrentConfig.SecondAceScore;
            }

            return score;
        }

        private int CalcHardHandScore(List<Card> hand)
        {
            int score = 0;

            foreach (Card card in hand)
            {
                if (card.Face == Face.Two)
                {
                    score += 2;
                }
                if (card.Face == Face.Three)
                {
                    score += 3;
                }
                if (card.Face == Face.Four)
                {
                    score += 4;
                }
                if (card.Face == Face.Five)
                {
                    score += 5;
                }
                if (card.Face == Face.Six)
                {
                    score += 6;
                }
                if (card.Face == Face.Seven)
                {
                    score += 7;
                }
                if (card.Face == Face.Eight)
                {
                    score += 8;
                }
                if (card.Face == Face.Nine)
                {
                    score += 9;
                }
                if (card.Face == Face.Ten || card.Face == Face.Jack || card.Face == Face.Queen ||
                    card.Face == Face.King)
                {
                    score += 10;
                }
            }
            return score;
        }
    }
}
