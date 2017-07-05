using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Game.Logic;
using BlackJack.Game.Logic.Interfaces;

namespace BlackJack.Game.Base
{
    public class GameConfig
    {
        public int InitialCardsCount = 2;

        public int MinPlayers = 1;
        public int MaxPlayers = 7;

        public int InitialPlayerBankroll = 100;

        public int DecksCount = 1;
        public int FaceCount = 13;
        public int SuitCount = 4;

        public int SecondAceScore = 1;
        public int FirstAceScore = 11;

        public double BlackJackRatio = 1.5;

        public int CardsCountForNativeBlackJack = 2;

        public int ScoreLimitOfDealerAbilityToTakeCards = 16;

        public int BlackJackNumber = 21;

        public HandScoreCalculator ScoreCalculator = new HandScoreCalculator();

        public GameConfig()
        {

        }
    }
}
