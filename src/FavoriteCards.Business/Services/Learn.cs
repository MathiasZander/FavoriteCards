using System;
using System.Collections.Generic;
using System.Linq;
using FavoriteCards.Business.Model;

namespace FavoriteCards.Business.Services
{
    public class Learn
    {
        private readonly IDateTimeProvider _dateTime;
        private Deck _deck = new Deck();
        private readonly List<List<Card>> _openByLevel = new List<List<Card>>( );

        public Learn(IDateTimeProvider dateTime)
        {
            _dateTime = dateTime;
        }

        public void SetDeck(Deck deck)
        {
            _deck = deck;

            var previousLevel = TimeSpan.MinValue;
            foreach (var level in _deck.Settings.IntervalLevels)
            {
                if (previousLevel != TimeSpan.MinValue)
                {
                    var cards = _deck.Cards
                        .Where(c => c.LastTry + previousLevel > _dateTime.Now)
                        .Where(c => c.LastTry + level < _dateTime.Now)
                        .ToList();
                    _openByLevel.Add(cards);
                }

                previousLevel = level;
            }

            var highestLevel = _deck.Cards
                .Where(c => c.LastTry + _deck.Settings.IntervalLevels.Last() <= _dateTime.Now)
                .ToList();
            _openByLevel.Add(highestLevel);

            var neverLearned = _deck.Cards.Where(c => c.LastTry == DateTime.MinValue).ToList();
            _openByLevel.Add(neverLearned);
        }

        public Card GetNextCard()
        {
            foreach (var level in _openByLevel)
            {
                if (level.Any())
                {
                    var nextCard = level.First();
                    level.Remove(nextCard);
                    return nextCard;
                }
            }

            return Card.Emtpy;
        }

        public void SetResult(string front, bool successful)
        {
            var card = _deck.Cards.FirstOrDefault(c => c.Front == front);
            if (card != null)
            {
                if (successful)
                {
                    card.Successful.Add(_dateTime.Now);
                    if (card.Level < _deck.Settings.IntervalLevels.Count)
                    {
                        card.Level++;
                    }
                }
                else
                {
                    card.Failed.Add(_dateTime.Now);
                    if (card.Level > 0)
                    {
                        card.Level--;
                    }
                }

                card.LastTry = _dateTime.Now;
            }
        }
    }
}