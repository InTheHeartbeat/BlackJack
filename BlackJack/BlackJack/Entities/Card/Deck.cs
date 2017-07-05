using System.Collections.Generic;
using System.Linq;
using BlackJack.Base;
using BlackJack.Enums;

namespace BlackJack.Entities.Card
{
    public class Deck
    {
        private Stack<Card> _cards;

        public Deck()
        {            
            Initialize();            
        }

        public void Initialize()
        {            
            CreateDeck();
            ShuffleDeck();
        }

        public void CreateDeck()
        {
            _cards = new Stack<Card>(from deckIndex in Enumerable.Range(1, ConfigProvider.Provider.CurrentConfig.DecksCount)
                from face in CollectionExtensions.GetEnumValues<Face>()
                from suit in CollectionExtensions.GetEnumValues<Suit>()
                select new Card() { Face = face, Suit = suit });
        }

        public void ShuffleDeck()
        {
            _cards.Shuffle();
        }
        
        public Card GetCard()
        {
            return _cards.Pop();
        }
    }
}
