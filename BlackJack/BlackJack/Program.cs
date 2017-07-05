using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Base;
using BlackJack.ConsoleOperations;
using BlackJack.Logic;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to BlackJack!");

            GameLogicController gameLogicController = new GameLogicController(new ConsoleGameOperations(), new ConsoleGameInformingOperations(), null);
            gameLogicController.RunGame();            
        }
    }
}
