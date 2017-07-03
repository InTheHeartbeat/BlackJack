using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Game.Base;
using BlackJack.Game.Entities.Card.Interfaces;
using BlackJack.Game.Enums;
using BlackJack.Game.Logic.Interfaces;

namespace BlackJack.Game.Logic
{
    public class HandScoreCalculator : IHandScoreCalculator
    {
        private readonly object _locker = new object();

        public int CalcHandScore(IHand hand)
        {
            lock (_locker)
            {
                if (hand.Cards.Any(card => card.Face == Face.Ace))
                    return CalcSoftHandScore(hand.Cards);
                else
                    return CalcHardHandScore(hand.Cards);
            }
        }

        private int CalcSoftHandScore(IList<ICard> hand)
        {
            int score = CalcHardHandScore(hand);

            if ((score + ConfigProvider.Provider.CurrentConfig.FirstAceScore) <= ConfigProvider.Provider.CurrentConfig.BlackJackNumber)
                score += ConfigProvider.Provider.CurrentConfig.FirstAceScore;
            else
                score += ConfigProvider.Provider.CurrentConfig.SecondAceScore;
            return score;
        }

        private int CalcHardHandScore(IList<ICard> hand)
        {
            int score = 0;

            foreach (ICard card in hand)
            {
                switch (card.Face)
                {
                    case Face.Two:
                        score += 2;
                        break;
                    case Face.Three:
                        score += 3;
                        break;
                    case Face.Four:
                        score += 4;
                        break;
                    case Face.Five:
                        score += 5;
                        break;
                    case Face.Six:
                        score += 6;
                        break;
                    case Face.Seven:
                        score += 7;
                        break;
                    case Face.Eight:
                        score += 8;
                        break;
                    case Face.Nine:
                        score += 9;
                        break;
                    case Face.Ten:
                        score += 10;
                        break;
                    case Face.Jack:
                        score += 10;
                        break;
                    case Face.Queen:
                        score += 10;
                        break;
                    case Face.King:
                        score += 10;
                        break;
                }

            }
            return score;
        }

    }
}
