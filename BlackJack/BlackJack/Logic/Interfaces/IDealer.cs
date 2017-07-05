using BlackJack.Entities.Card.Interfaces;
using BlackJack.Enums;

namespace BlackJack.Logic.Interfaces
{
    public interface IDealer : ICardHolder
    {        
        void RequestBet(IPlayer player);
        PlayerAction? RequestAction(IPlayer player);
        double GetBetValue(IPlayer player);
    }
}
