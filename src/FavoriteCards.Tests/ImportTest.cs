using System.IO;
using FavoriteCards.Business.Services;
using FluentAssertions;
using Xunit;

namespace FavoriteCards.Tests
{
    public class ImportTest
    {
        [Fact]
        public void CsvTest()
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