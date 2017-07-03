using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Game.Base;
using BlackJack.Game.Entities.Card;
using BlackJack.Game.Entities.Card.Interfaces;
using BlackJack.Game.Entities.House.Interfaces;
using BlackJack.Game.Logic.Interfaces;
using BlackJack.Logic;

namespace BlackJack.Base
{
    public class ConsoleGameOperations : IGameOperations
    {
        public int RequestPlayersCount()
        {
            Console.WriteLine(
                $"Select players count ({GameConfigSingleton.Config.MinPlayers}-{GameConfigSingleton.Config.MaxPlayers}):");

            int result = 0;
            bool valid = false;

            while (!valid)
            {
                while (!int.TryParse(Console.ReadLine(), out result))
                {
                    Console.WriteLine("Invalid value, please enter a valid numeric value:");
                }

                if (result > GameConfigSingleton.Config.MaxPlayers || result < GameConfigSingleton.Config.MinPlayers)
                    Console.WriteLine(
                        $"Invalid value, please enter a valid numeric value in range ({GameConfigSingleton.Config.MinPlayers}-{GameConfigSingleton.Config.MaxPlayers}):");
                else
                    valid = true;
            }
            return result;
        }

        public IEnumerable<IPlayer> GetPlayers(int playerCount, IReadOnlyTable table)
        {
            List<Player> players = new List<Player>();
            for (int i = 0; i < playerCount; i++)
            {
                players.Add(new Player(table) {Id = i+1});
            }
            return players;
        }

        public bool RequestContinue()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Continue? (y/n)");            
            string readLine = Console.ReadLine().Replace(" ", "").ToLower();
            while (readLine != "n" && readLine != "y")
            {
                Console.WriteLine("Invalid value, please enter valid value (y/n)");
                readLine = Console.ReadLine().Replace(" ", "").ToLower();
            }
            if (readLine == "n")
                return false;
            if (readLine == "y")
                return true;
            return false;
        }
    }
}
