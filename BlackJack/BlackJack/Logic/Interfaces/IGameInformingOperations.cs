using BlackJack.Entities.Card;
using BlackJack.Entities.Card.Interfaces;

namespace BlackJack.Logic.Interfaces
{
    public interface IGameInformingOperations
    {
        void OnRequestBet(IPlayer player);
        void OnRequestAction(IPlayer player);
        void OnPullCard(Card pullCard);
        void OnPullHoleCard();        
        void OnHitCard(IPlayer player);
        void OnPlayerStand(IPlayer player);
        void OnGiveCard(ICardHolder holder);
        void OnPlayerLost(IPlayer player);
        void OnPlayerWon(IPlayer player);
        void OnPlayerWonBlackJack(IPlayer player);
        void OnPlayerStandoff(IPlayer player);
        void OnPlayerBankrupt(IPlayer player);

        void ShowPlayerScore(ICardHolder holder);        
        void ShowDealerHoleCard(Card card);        
    }
}
