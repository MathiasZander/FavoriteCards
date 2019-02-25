using FavoriteCards.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FavoriteCards.App.Services
{
    public class Learn
    {
        private Deck _deck = new Deck();

        public void SetDeck(Deck deck)
        {
            _deck = deck;
        }

        public Card GetNextCard()
        {
            return _deck.Cards.FirstOrDefault();
        }

        public void SetResult(string front, bool successful)
        {

        }
    }
}
