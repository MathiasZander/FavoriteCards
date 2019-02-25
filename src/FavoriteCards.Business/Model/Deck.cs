using System.Collections.Generic;

namespace FavoriteCards.App.Model
{
    public class Deck
    {
        public List<Card> Cards { get; set; } = new List<Card>();
        public string FrontName { get; set; }
        public string BackName { get; set; }
    }
}