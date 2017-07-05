using System;

namespace BlackJack.ConsoleOperations
{
    public class ConsoleConfig
    {
        public static ConsoleConfig Config => _instance ?? (_instance = new ConsoleConfig());
        private static ConsoleConfig _instance;

        public readonly ConsoleColor DefaultColor = ConsoleColor.White;

        public readonly ConsoleColor WinnerColor = ConsoleColor.Green;
        public readonly ConsoleColor LoserColor = ConsoleColor.Red;
        public readonly ConsoleColor BlackJackColor = ConsoleColor.Magenta;
        public readonly ConsoleColor StandoffColor = ConsoleColor.DarkCyan;

        public readonly ConsoleColor PullCardColor = ConsoleColor.Blue;
    }
}
