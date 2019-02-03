using FavoriteCards.App.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FavoriteCards.App.Services
{
    public class CsvParser
    {
        public Deck Parse(string[] lines)
        {
            var deck = new Deck();

            foreach (var line in lines)
            {
                var card = new Card();

                var cells = line.Split(',');

                deck.FrontName = cells[0];
                deck.BackName = cells[1];

                card.Front = cells[2];
                card.Back = cells[3];
                deck.Cards.Add(card);               
            }

            return deck;
        }
    }
}
