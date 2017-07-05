using System;
using System.Collections.Generic;
using BlackJack.Base;
using BlackJack.Logic;
using BlackJack.Logic.Interfaces;

namespace BlackJack.ConsoleOperations
{
    public class ConsoleGameOperations : IGameOperations
    {
        public int RequestPlayersCount()
        {
            Console.WriteLine(
                $"Select players count ({ConfigProvider.Provider.CurrentConfig.MinPlayers}-{ConfigProvider.Provider.CurrentConfig.MaxPlayers}):");

            int result = 0;
            bool valid = false;

            while (!valid)
            {
                while (!int.TryParse(Console.ReadLine(), out result))
                {
                    Console.WriteLine("Invalid value, please enter a valid numeric value:");
                }

                if (result > ConfigProvider.Provider.CurrentConfig.MaxPlayers ||
                    result < ConfigProvider.Provider.CurrentConfig.MinPlayers)
                {
                    Console.WriteLine(
                        $"Invalid value, please enter a valid numeric value in range ({ConfigProvider.Provider.CurrentConfig.MinPlayers}-{ConfigProvider.Provider.CurrentConfig.MaxPlayers}):");
                }

                if (result <= ConfigProvider.Provider.CurrentConfig.MaxPlayers &&
                    result >= ConfigProvider.Provider.CurrentConfig.MinPlayers)
                {
                    valid = true;
                }
            }
            return result;
        }
        public IEnumerable<IPlayer> GetPlayers(int playerCount)
        {
            List<Player> players = new List<Player>();
            for (int i = 0; i < playerCount; i++)
            {
                players.Add(new Player() {Id = i+1});
            }
            return players;
        }
        public bool RequestContinue()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Continue? (y/n)");

            return RequestYesNo();
        }
        public bool RequestRestart()
        {
            Console.WriteLine();
            Console.WriteLine("Restart? (y/n)");

            return RequestYesNo();
        }
        private bool RequestYesNo()
        {
            string readLine = Console.ReadLine().Replace(" ", "").ToLower();

            while (readLine != "n" && readLine != "y")
            {
                Console.WriteLine("Invalid value, please enter valid value (y/n)");
                readLine = Console.ReadLine().Replace(" ", "").ToLower();
            }
            if (readLine == "n")
            {
                return false;
            }
            if (readLine == "y")
            {
                return true;
            }
            return false;
        }
    }
}
