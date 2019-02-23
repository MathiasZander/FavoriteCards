using FavoriteCards.App.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FavoriteCards.App.Services
{
    public class CsvParser
    {
        public Deck Parse(string csv)
        {
            List<Row> rows = new List<Row>();

            StringReader stringReader = new StringReader(csv);
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
            deck.FrontName = rows.GroupBy(d => d.frontName).OrderByDescending(d => d.Count()).Select(d => d.Key).First();
            deck.BackName = rows.GroupBy(d => d.backName).OrderByDescending(d => d.Count()).Select(d => d.Key).First();

            foreach (var row in rows)
            {
                Card card = new Card();

                if (row.frontName == deck.FrontName)
                {
                    card.Front = row.front;
                    card.Back = row.back;
                }
                else
                {
                    card.Front = row.back;
                    card.Back = row.front;
                }

                deck.Cards.Add(card);
            }

            return deck;
        }

        private static Row ParseLine(string line)
        {
            var card = new Card();

            var cells = line.Split(',');

            var frontName = cells[0];
            var backName = cells[1];

            var front = cells[2];
            var back = cells[3];

            return new Row(frontName, backName, front, back);
        }
    }

    internal struct Row
    {
        public string frontName;
        public string backName;
        public string front;
        public string back;

        public Row(string frontName, string backName, string front, string back)
        {
            this.frontName = frontName;
            this.backName = backName;
            this.front = front;
            this.back = back;
        }
    }
}
