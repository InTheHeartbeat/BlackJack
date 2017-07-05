using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Game.Base;
using BlackJack.Game.Entities.Card;
using BlackJack.Game.Entities.Card.Interfaces;
using BlackJack.Game.Entities.House.Interfaces;
using BlackJack.Game.Enums;
using BlackJack.Game.Logic;
using BlackJack.Game.Logic.Interfaces;

namespace BlackJack.Logic
{
    public class Player : IPlayer
    {
        public int Id { get; set; }
        public IHand Hand { get; set; }
        public IReadOnlyTable Table { get; set; }
        public double Bankroll { get; set; }
        public bool Lost { get; set; }

        public Player(IReadOnlyTable table)
        {
            Hand = new Hand(ConfigProvider.Provider.CurrentConfig.ScoreCalculator);
            Table = table;
            Bankroll = ConfigProvider.Provider.CurrentConfig.InitialPlayerBankroll;
        }

        public double MakeBet()
        {
            double result = 0;
            bool valid = false;

            while (!valid)
            {
                while (!double.TryParse(Console.ReadLine(), out result))
                {
                    Console.WriteLine("Invalid value, please enter a valid numeric value:");
                }

                if (result > this.Bankroll || result < 0)
                    Console.WriteLine(
                        $"Invalid value, please enter a valid numeric value in range (0-{this.Bankroll}):");
                else
                    valid = true;
            }
            return result;
        }

        public PlayerAction? DoAction()
        {
            string selectedAction = Console.ReadLine().Replace(" ", "").ToLower();
            if (selectedAction == "h")            
                return PlayerAction.Hit;            
            if(selectedAction == "s")
                return PlayerAction.Stand;
            return null;
        }
    }
}
