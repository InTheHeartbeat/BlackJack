using BlackJack.Game.Entities.Card.Interfaces;
using BlackJack.Game.Entities.House.Interfaces;
using BlackJack.Game.Enums;

namespace BlackJack.Game.Logic.Interfaces
{
    public interface IPlayer : ICardHolder
    {
        IReadOnlyTable Table { get; set; }
        double Bankroll { get; set; }
        bool Lose { get; set; }        
        double MakeBet();
        PlayerAction? DoAction();
    }
}
