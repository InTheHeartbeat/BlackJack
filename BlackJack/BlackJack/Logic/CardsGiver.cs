using BlackJack.ConsoleOperations;
using BlackJack.Entities.Card;
using BlackJack.Entities.Card.Interfaces;
using BlackJack.Entities.House;


namespace BlackJack.Logic
{
    internal static class CardsGiver
    {
        internal static void GiveCard(ICardHolder holder, Table table, ConsoleGameInformingOperations informingOperations)
        {
            if (holder is Dealer && holder.Hand.Cards.Count == 1)
            {
                holder.Hand.Cards.Add(PullHoleCard(table, informingOperations));
                return;
            }

            holder.Hand.Cards.Add(PullCard(table, informingOperations));
        }

        internal static Card PullCard(Table table, ConsoleGameInformingOperations informingOperations)
        {
            Card pullCard = table.Deck.GetCard();
            informingOperations.OnPullCard(pullCard);
            return pullCard;
        }

        internal static Card PullHoleCard(Table table, ConsoleGameInformingOperations informingOperations)
        {
            Card pullCard = table.Deck.GetCard();
            informingOperations.OnPullHoleCard();
            return pullCard;
        }
    }
}
