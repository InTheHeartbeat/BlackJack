using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Game.Logic;
using BlackJack.Game.Logic.Interfaces;

namespace BlackJack.Game.Base
{
    public abstract class GameConfig
    {
        public int InitialCardsCount;
        public int MaxPlayers;
        public int MinPlayers;

        public double InitialPlayerBankroll;

        public int DecksCount;
        public int FaceCount;
        public int SuitCount;

        public int SecondAceScore;
        public int FirstAceScore;

        public double BlackJackRatio;

        public int CardsCountForNativeBlackJack;

        public int ScoreLimitOfDealerAbilityToTakeCards;

        public int BlackJackNumber;

        public IHandScoreCalculator HandScoreCalculator;

        public GameConfig()
        {
            
        }

        protected GameConfig(int initialCardsCount, int maxPlayers, int minPlayers, double initialPlayerBankroll, int decksCount, int faceCount, int suitCount, int secondAceScore, int firstAceScore, double blackJackRatio, int cardsCountForNativeBlackJack, int scoreLimitOfDealerAbilityToTakeCards, int blackJackNumber, IHandScoreCalculator handScoreCalculator)
        {
            InitialCardsCount = initialCardsCount;
            MaxPlayers = maxPlayers;
            MinPlayers = minPlayers;
            InitialPlayerBankroll = initialPlayerBankroll;
            DecksCount = decksCount;
            FaceCount = faceCount;
            SuitCount = suitCount;
            SecondAceScore = secondAceScore;
            FirstAceScore = firstAceScore;
            BlackJackRatio = blackJackRatio;
            CardsCountForNativeBlackJack = cardsCountForNativeBlackJack;
            ScoreLimitOfDealerAbilityToTakeCards = scoreLimitOfDealerAbilityToTakeCards;
            BlackJackNumber = blackJackNumber;
            HandScoreCalculator = handScoreCalculator;
        }
    }
}
