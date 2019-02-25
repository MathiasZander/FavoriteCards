using System.Linq;
using FavoriteCards.Business.Model;

namespace FavoriteCards.Business.Services
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