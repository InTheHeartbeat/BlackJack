using BlackJack.Game.Logic.Interfaces;

namespace BlackJack.Game.Entities.House.Interfaces
{
    public interface IReadOnlyTable
    {
        IDealer Dealer { get; }
    }
}
