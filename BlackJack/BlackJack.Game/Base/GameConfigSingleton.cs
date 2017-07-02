using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Game.Logic;
using BlackJack.Game.Logic.Interfaces;

namespace BlackJack.Game.Base
{
    public class GameConfigSingleton
    {
        public static GameConfigSingleton Config => _instance ?? (_instance = new GameConfigSingleton());
        private static GameConfigSingleton _instance;

        public readonly int InitialCardsCount = 2;
        public readonly int MaxPlayers = 7;
        public readonly int MinPlayers = 1;

        public readonly IHandScoreCalculator HandScoreCalculator = new HandScoreCalculator();
    }
}
