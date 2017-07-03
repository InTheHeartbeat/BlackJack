using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Base;
using BlackJack.Game.Entities.House;
using BlackJack.Game.Logic;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            GameLogicController gameLogicController = new GameLogicController(new ConsoleGameOperations(), new ConsoleGameInformingOperations(), null);
            gameLogicController.RunGame();            
        }
    }
}
