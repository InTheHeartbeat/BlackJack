using System.Collections.Generic;
using System.Linq;
using BlackJack.Base;
using BlackJack.Entities.Card;
using BlackJack.Enums;

namespace BlackJack.Logic
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
            return hand.Where(card=>card.Face != Face.Ace).Sum(card=>(int)card.Face);
        }
    }
}
