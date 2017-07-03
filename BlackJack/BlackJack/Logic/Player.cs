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
            Hand = new Hand(ConfigProvider.Provider.CurrentConfig.HandScoreCalculator);
            Table = table;
            Bankroll = ConfigProvider.Provider.CurrentConfig.InitialPlayerBankroll;
        }

        public double MakeBet()
        {
            return double.Parse(Console.ReadLine());
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
