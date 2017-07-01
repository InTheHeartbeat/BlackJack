using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Game.Base
{
    public class GameConfigSingleton
    {
        public static GameConfigSingleton Config => _instance ?? (_instance = new GameConfigSingleton());
        private static GameConfigSingleton _instance;

        public readonly int InitialCardsCount = 2;
    }
}
