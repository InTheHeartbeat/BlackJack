using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Game.Entities.Card.Interfaces;
using BlackJack.Game.Entities.House.Interfaces;
using BlackJack.Game.Enums;
using BlackJack.Game.Logic.Interfaces;

namespace BlackJack.Logic
{
    public class Player : IPlayer
    {
        public IHand Hand { get; set; }
        public IReadOnlyTable Table { get; set; }
        public bool Lose { get; set; }
        public int Id { get; set; }
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
