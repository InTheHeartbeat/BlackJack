using BlackJack.Entities.Card.Interfaces;
using BlackJack.Enums;

namespace BlackJack.Logic.Interfaces
{
    public interface IPlayer : ICardHolder
    {        
        double Bankroll { get; set; }
        bool Lost { get; set; }        
        double MakeBet();
        PlayerAction? DoAction();
    }
}
