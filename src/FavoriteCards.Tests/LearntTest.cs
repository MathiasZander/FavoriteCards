using System;
using System.IO;
using System.Threading;
using FavoriteCards.Business.Model;
using FavoriteCards.Business.Services;
using FluentAssertions;
using Xunit;

namespace FavoriteCards.Tests
{
    public class LearnTest
    {
        private readonly DateTimeProviderStub _dateTime;
        private readonly Learn _learn;
        private readonly Deck _deck;

        public LearnTest()
        {
            _dateTime = new DateTimeProviderStub(DateTime.Now);

            var parser = new CsvParser();
            var lines = File.ReadAllText("TestData/Export.csv");
            _deck = parser.Parse(lines);

            _learn = new Learn(_dateTime);
            _learn.SetDeck(_deck);
        }


        [Fact]
        public void LastTry_ShouldBeRight()
        {
            Learn(true);
            Learn(false);

            var card = Learn(true);

            card.LastTry.Should().Be(_dateTime.Now);
        }

        [Fact]
        public void GetNextCard_ShouldNotGiveSameCardTwice()
        {
            var card1 = _learn.GetNextCard();
            var card2 = _learn.GetNextCard();

            card1.Front.Should().NotBe(card2.Front);
        }

        [Fact]
        public void Successful_ShouldHaveRightCount()
        {
            Learn(true);
            _dateTime.AddDays(365);
            _learn.UpdateLevels();

            var card = Learn(true);

            card.Successful.Should().HaveCount(2);
        }

        private Card Learn(bool successful, int durationInSeconds = 1)
        {
            var card = _learn.GetNextCard();

            _dateTime.AddSeconds(durationInSeconds);
            _learn.SetResult(card.Front, successful);

            return card;
        }
    }
}