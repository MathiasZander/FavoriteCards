using System.Collections.Generic;

namespace FavoriteCards.Business.Model
{
    public class Deck
    {
        public List<Card> Cards { get; set; } = new List<Card>();
        public string FrontName { get; set; } = string.Empty;
        public string BackName { get; set; } = string.Empty;
    }
}