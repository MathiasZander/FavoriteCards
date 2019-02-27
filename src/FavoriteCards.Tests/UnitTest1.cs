using System.IO;
using FavoriteCards.Business.Services;
using FluentAssertions;
using Xunit;

namespace FavoriteCards.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ImportTest()
        {
            var parser = new CsvParser();
            var lines = File.ReadAllText("TestData/Export.csv");

            var result = parser.Parse(lines);

            result.FrontName.Should().Be("Englisch");
            result.Cards.Should().Contain(c => c.Front == "coincidence");
            result.Cards.Should().Contain(c => c.Front == "vain");
        }

        [Fact]
        public void LearnTest()
        {
            var parser = new CsvParser();
            var lines = File.ReadAllText("TestData/Export.csv");
            var deck = parser.Parse(lines);

            var learn = new Learn();
            learn.SetDeck(deck);


        }
    }
}