using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Game.Entities.Card.Interfaces;
using BlackJack.Game.Logic.Interfaces;

namespace BlackJack.Base
{
    public class ConsoleGameInformingOperations : IGameInformingOperations
    {
        public void OnRequestBet(IPlayer player)
        {
            Console.WriteLine($"Player #{player.Id}, please make a your bet:");
        }

        public void OnRequestAction(IPlayer player)
        {
            Console.WriteLine($"Player #{player.Id} ({player.Hand.CurrentScore} score), please choose action (S)tand or (H)it:");
        }

        public void OnPullCard(ICard pullCard)
        {
            Console.WriteLine($"Pulled card it {pullCard.Face} {pullCard.Suit}");
            Console.WriteLine();
        }

        public void OnPullHoleCard(ICard pullCard)
        {
            Console.WriteLine($"Pulled card it *hole card*");
            Console.WriteLine();
        }       

        public void OnHitCard(IPlayer player)
        {
            Console.WriteLine($"Player #{player.Id} ({player.Hand.CurrentScore} score), decided to choose *hit*");
        }

        public void OnPlayerStand(IPlayer player)
        {
            Console.WriteLine($"Player #{player.Id} ({player.Hand.CurrentScore} score), decided to choose *stand*");
        }

        public void OnGiveCard(ICardHolder holder)
        {
            Console.WriteLine($"{(holder.Id == 0 ? "Dealer" : $"Player #{holder.Id}")} got card:");
        }
    }
}
