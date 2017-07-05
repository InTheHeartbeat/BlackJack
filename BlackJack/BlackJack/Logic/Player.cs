using System;
using BlackJack.Base;
using BlackJack.Entities.Card;
using BlackJack.Enums;
using BlackJack.Logic.Interfaces;

namespace BlackJack.Logic
{
    public class Player : IPlayer
    {
        public int Id { get; set; }
        public Hand Hand { get; set; }        
        public double Bankroll { get; set; }
        public bool Lost { get; set; }

        public Player()
        {
            Hand = new Hand(ConfigProvider.Provider.CurrentConfig.ScoreCalculator);            
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
                {
                    Console.WriteLine(
                        $"Invalid value, please enter a valid numeric value in range (0-{this.Bankroll}):");
                }

                if (result <= this.Bankroll && result > 0)
                {
                    valid = true;
                }
            }
            return result;
        }

        public PlayerAction? DoAction()
        {
            string selectedAction = Console.ReadLine().Replace(" ", "").ToLower();
            if (selectedAction == "h")
            {
                return PlayerAction.Hit;
            }
            if (selectedAction == "s")
            {
                return PlayerAction.Stand;
            }
            return null;
        }
    }
}
