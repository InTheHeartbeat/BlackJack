using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Game.Entities.Card;
using BlackJack.Game.Entities.Card.Interfaces;
using BlackJack.Game.Logic.Interfaces;
using BlackJack.Logic;

namespace BlackJack.Base
{
    public class ConsoleGameOperations : IGameOperations
    {
        public int RequestPlayersCount()
        {
            Console.WriteLine("Select players count:");
            return int.Parse(Console.ReadLine());
        }

        public IEnumerable<IPlayer> GetPlayers(int playerCount)
        {
            List<Player> players = new List<Player>();
            for (int i = 0; i < playerCount; i++)
            {
                players.Add(new Player() {Id = i+1,Lose = false, Hand = new Hand() {Cards = new List<ICard>()} });
            }
            return players;
        }
    }
}
