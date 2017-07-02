using BlackJack.Game.Entities.Card.Interfaces;
using BlackJack.Game.Entities.House.Interfaces;
using BlackJack.Game.Enums;

namespace BlackJack.Game.Logic.Interfaces
{
    public interface IDealer : ICardHolder
    {
        ITable Table { get; set; }
        void RequestBet(IPlayer player);
        PlayerAction? RequestAction(IPlayer player);
        double GetBetValue(IPlayer player);
    }
}
