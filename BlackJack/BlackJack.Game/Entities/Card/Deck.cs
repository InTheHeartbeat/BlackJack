using System;
using System.Collections.Generic;
using BlackJack.Game.Base;
using BlackJack.Game.Entities.Card.Interfaces;
using BlackJack.Game.Enums;

namespace BlackJack.Game.Entities.Card
{
    public class Deck : IDeck
    {
        private Stack<ICard> _cards;

        public Deck()
        {            
            Initialize();            
        }

        public void Initialize()
        {
            _cards = new Stack<ICard>();

            for (int suit = 0; suit < 4; suit++)
            {
                for (int face = 0; face < 13; face++)
                {
                    _cards.Push(new Card() { Suit = (Suit)suit, Face = (Face)face });
                }
            }            

            ShuffleDeck();
        }

        public void ShuffleDeck()
        {
            _cards.Shuffle();
        }
        
        public ICard GetCard()
        {

            return _cards.Pop();
        }
    }
}
