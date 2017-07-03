using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Game.Logic;
using BlackJack.Game.Logic.Interfaces;

namespace BlackJack.Game.Base
{
    public class DefaultGameConfig : GameConfig
    {
        public DefaultGameConfig()
        {
            this.InitialCardsCount = 2;

            this.MinPlayers = 1;
            this.MaxPlayers = 7;

            this.InitialPlayerBankroll = 100;

            this.DecksCount = 1;
            this.FaceCount = 13;
            this.SuitCount = 4;

            this.SecondAceScore = 1;
            this.FirstAceScore = 11;

            this.BlackJackRatio = 1.5;

            this.CardsCountForNativeBlackJack = 2;

            this.ScoreLimitOfDealerAbilityToTakeCards = 16;

            this.BlackJackNumber = 21;

            this.HandScoreCalculator = new HandScoreCalculator();
        }
    }
}
