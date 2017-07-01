using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Game.Base;
using BlackJack.Game.Entities.Card;
using BlackJack.Game.Entities.Card.Interfaces;
using BlackJack.Game.Entities.House;
using BlackJack.Game.Entities.House.Interfaces;
using BlackJack.Game.Logic.Interfaces;

namespace BlackJack.Game.Logic
{
    public class GameLogicController :IGameLogicController
    {
        public ITable Table { get; }
        public int PlayersCount { get; internal set; }

        private IGameOperations _operations;
        


        public GameLogicController(IGameOperations operations)
        {
            _operations = operations;            

            Table = new Table()
            {
                Dealer = new Dealer(operations),
                Deck = new Deck()
            };

        }

        public void RunGame()
        {
            InitializePlayers();   
            RequestPlayersBets();
            PrepareDeck();
            GiveOutCards();
        }
        private void InitializePlayers()
        {
            RequestPlayersCount();
            Table.Players.AddRange(_operations.GetPlayers());
        }
        private void RequestPlayersCount()
        {
            PlayersCount = _operations.RequestPlayersCount();
        }

        private void RequestPlayersBets()
        {
            Table.Players.ForEach(player=>Table.Dealer.RequestBet(player));
        }

        private void PrepareDeck()
        {
            Table.Deck = new Deck();
        }

        private void GiveOutCards()
        {
            for (int i = 0; i < GameConfigSingleton.Config.InitialCardsCount; i++)
            {                  
                Table.Players.ForEach(GiveCard);                
                GiveCard(Table.Dealer);
            }
        }

        private void GiveCard(ICardHolder holder)
        {
            ICard pullCard = Table.Deck.GetCard();
            holder.Hand.Cards.Add(pullCard);            

            if (holder is Dealer && holder.Hand.Cards.Count == 1)            
                _operations.OnPullHoleCard(pullCard);
            else            
                _operations.OnPullCard(pullCard);            
        }
    }
}
