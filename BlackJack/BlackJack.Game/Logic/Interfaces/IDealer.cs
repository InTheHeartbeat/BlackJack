using BlackJack.Game.Entities.Card.Interfaces;
using BlackJack.Game.Entities.House.Interfaces;

namespace BlackJack.Game.Logic.Interfaces
{
    public interface IDealer : ICardHolder
    {
        ITable Table { get; set; }
        void RequestBet(IPlayer player);
        void RequestAction(IPlayer player);
    }
}
