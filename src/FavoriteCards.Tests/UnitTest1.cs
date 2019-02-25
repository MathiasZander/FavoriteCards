using System.IO;
using FavoriteCards.App.Services;
using FluentAssertions;
using Xunit;

namespace FavoriteCards.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var parser = new CsvParser();
            var lines = File.ReadAllText("TestData/Export.csv");


            var result = parser.Parse(lines);

            result.FrontName.Should().Be("Englisch");
            result.Cards.Should().Contain(c => c.Front == "coincidence");
            result.Cards.Should().Contain(c => c.Front == "vain");
        }
    }
}