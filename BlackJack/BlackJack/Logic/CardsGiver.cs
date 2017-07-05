using BlackJack.Entities.Card;
using BlackJack.Entities.Card.Interfaces;
using BlackJack.Entities.House;
using BlackJack.Logic.Interfaces;

namespace BlackJack.Logic
{
    internal static class CardsGiver
    {
        internal static void GiveCard(ICardHolder holder, Table table, IGameInformingOperations informingOperations)
        {
            if (holder is Dealer && holder.Hand.Cards.Count == 1)
            {
                holder.Hand.Cards.Add(PullHoleCard(table, informingOperations));
                return;
            }

            holder.Hand.Cards.Add(PullCard(table, informingOperations));
        }

        internal static Card PullCard(Table table, IGameInformingOperations informingOperations)
        {
            Card pullCard = table.Deck.GetCard();
            informingOperations.OnPullCard(pullCard);
            return pullCard;
        }

        internal static Card PullHoleCard(Table table, IGameInformingOperations informingOperations)
        {
            Card pullCard = table.Deck.GetCard();
            informingOperations.OnPullHoleCard();
            return pullCard;
        }
    }
}
