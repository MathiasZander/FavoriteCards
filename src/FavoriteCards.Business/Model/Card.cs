using System;
using System.Collections.Generic;

namespace FavoriteCards.Business.Model
{
    public class Card
    {
        public string Front { get; set; } = string.Empty;
        public string Back { get; set; } = string.Empty;
        public SortedSet<DateTime> Successful { get; set; } = new SortedSet<DateTime>();
        public SortedSet<DateTime> Failed { get; set; } = new SortedSet<DateTime>();
        public uint Level { get; set; }
        public DateTime LastTry { get; set; } = DateTime.MinValue;

        public static Card Emtpy { get; } = new Card {Level = UInt32.MaxValue};
    }
}