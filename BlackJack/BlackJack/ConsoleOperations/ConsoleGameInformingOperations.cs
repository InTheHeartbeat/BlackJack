using System;
using BlackJack.Entities.Card;
using BlackJack.Entities.Card.Interfaces;
using BlackJack.Logic.Interfaces;

namespace BlackJack.ConsoleOperations
{
    public class ConsoleGameInformingOperations : IGameInformingOperations
    {
        public void OnRequestBet(IPlayer player)
        {
            Console.ForegroundColor = ConsoleConfig.Config.DefaultColor;
            Console.WriteLine();
            Console.WriteLine($"Player #{player.Id}, your bankroll {player.Bankroll}, please make a your bet:");
        }
        public void OnRequestAction(IPlayer player)
        {
            Console.ForegroundColor = ConsoleConfig.Config.DefaultColor;
            Console.WriteLine();
            Console.WriteLine($"Player #{player.Id} ({player.Hand.CurrentScore} score), please choose action (S)tand or (H)it:");
        }
        public void OnPullCard(Card pullCard)
        {
            Console.ForegroundColor = ConsoleConfig.Config.PullCardColor;
            Console.WriteLine($"Pulled card it {pullCard.Face} {pullCard.Suit}");
            Console.ForegroundColor = ConsoleConfig.Config.DefaultColor;
            Console.WriteLine();
        }
        public void OnPullHoleCard()
        {
            Console.ForegroundColor = ConsoleConfig.Config.PullCardColor;
            Console.WriteLine($"Pulled card it *hole card*");
            Console.ForegroundColor = ConsoleConfig.Config.DefaultColor;
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
        public void OnPlayerBankrupt(IPlayer player)
        {
            Console.ForegroundColor = ConsoleConfig.Config.LoserColor;
            Console.WriteLine($"Player #{player.Id} went bankrupt and was expelled");
            Console.ForegroundColor = ConsoleConfig.Config.DefaultColor;
        }
        public void ShowPlayerScore(ICardHolder holder)
        {            
            Console.WriteLine($"{(holder.Id == 0 ? "Dealer" : $"Player #{holder.Id}")} has a {holder.Hand.CurrentScore} score");
            if (holder.Hand.CurrentScore == 21 && holder.Hand.Cards.Count == 2)
            {
                Console.ForegroundColor = ConsoleConfig.Config.BlackJackColor;
                Console.WriteLine($"Player #{holder.Id}, won - NATIVE BLACK JACK");
                Console.ForegroundColor = ConsoleConfig.Config.DefaultColor;
            }            
        }
        public void OnPlayerLost(IPlayer player)
        {                        
            Console.ForegroundColor = ConsoleConfig.Config.LoserColor;
            Console.WriteLine($"Player #{player.Id} lost with the score {player.Hand.CurrentScore}, player bankroll: {player.Bankroll}");
            Console.ForegroundColor = ConsoleConfig.Config.DefaultColor;
        }
        public void OnPlayerWon(IPlayer player)
        {
            Console.ForegroundColor = ConsoleConfig.Config.WinnerColor;
            Console.WriteLine($"Player #{player.Id} won with the score {player.Hand.CurrentScore}, player bankroll: {player.Bankroll}");
            Console.ForegroundColor = ConsoleConfig.Config.DefaultColor;
        }
        public void OnPlayerWonBlackJack(IPlayer player)
        {
            Console.ForegroundColor = ConsoleConfig.Config.BlackJackColor;
            Console.WriteLine($"Player #{player.Id} won BLACKJACK, player bankroll: {player.Bankroll}");
            Console.ForegroundColor = ConsoleConfig.Config.DefaultColor;
        }
        public void ShowDealerHoleCard(Card card)
        {
            Console.ForegroundColor = ConsoleConfig.Config.PullCardColor;
            Console.WriteLine();
            Console.WriteLine($"Hole dealer's card it {card.Face} {card.Suit}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleConfig.Config.DefaultColor;
        }
        public void OnPlayerStandoff(IPlayer player)
        {
            Console.ForegroundColor = ConsoleConfig.Config.StandoffColor;
            Console.WriteLine($"Player #{player.Id} standoff");
            Console.ForegroundColor = ConsoleConfig.Config.DefaultColor;
        }
    }
}
