using System.Collections.Generic;
using System.IO;
using System.Linq;
using FavoriteCards.Business.Model;

namespace FavoriteCards.Business.Services
{
    public class CsvParser
    {
        public Deck Parse(string csv)
        {
            var rows = new List<Row>();

            var stringReader = new StringReader(csv);
            var line = stringReader.ReadLine();

            while (line != null)
            {
                if (string.IsNullOrWhiteSpace(line) == false)
                {
                    var row = ParseLine(line);
                    rows.Add(row);
                }

                line = stringReader.ReadLine();
            }

            var deck = new Deck();
            deck.FrontName = rows.GroupBy(d => d.FrontName).OrderByDescending(d => d.Count()).Select(d => d.Key)
                .First();
            deck.BackName = rows.GroupBy(d => d.BackName).OrderByDescending(d => d.Count()).Select(d => d.Key).First();

            foreach (var row in rows)
            {
                var card = new Card();

                if (row.FrontName == deck.FrontName)
                {
                    card.Front = row.Front;
                    card.Back = row.Back;
                }
                else
                {
                    card.Front = row.Back;
                    card.Back = row.Front;
                }

                deck.Cards.Add(card);
            }

            return deck;
        }

        private static Row ParseLine(string line)
        {
            var cells = line.Split(',');

            var frontName = cells[0];
            var backName = cells[1];

            var front = cells[2];
            var back = cells[3];

            return new Row(frontName, backName, front, back);
        }
    }
}