using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Game.Entities.Card.Interfaces;
using BlackJack.Game.Entities.House;
using BlackJack.Game.Entities.House.Interfaces;
using BlackJack.Game.Logic.Interfaces;

namespace BlackJack.Game.Logic
{
    internal static class CardsGiver
    {
        internal static void GiveCard(ICardHolder holder, ITable table, IGameInformingOperations informingOperations)
        {                        
            if (holder is Dealer && holder.Hand.Cards.Count == 1)
                holder.Hand.Cards.Add(PullHoleCard(table,informingOperations));
            else
                holder.Hand.Cards.Add(PullCard(table,informingOperations));
        }

        internal static ICard PullCard(ITable table, IGameInformingOperations informingOperations)
        {
            ICard pullCard = table.Deck.GetCard();
            informingOperations.OnPullCard(pullCard);
            return pullCard;
        }

        internal static ICard PullHoleCard(ITable table, IGameInformingOperations informingOperations)
        {
            ICard pullCard = table.Deck.GetCard();
            informingOperations.OnPullHoleCard(pullCard);
            return pullCard;
        }
    }
}
