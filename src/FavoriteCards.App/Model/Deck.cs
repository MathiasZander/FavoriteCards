using System;
using System.Collections.Generic;
using System.Text;

namespace FavoriteCards.App.Model
{
    public class Deck
    {
        public List<Card> Cards { get; set; } = new List<Card>();
        public string FrontName { get; set; }
        public string BackName { get; set; }
    }
}
