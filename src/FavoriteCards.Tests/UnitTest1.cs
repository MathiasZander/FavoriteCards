using FavoriteCards.App.Services;
using System;
using System.IO;
using Xunit;

namespace FavoriteCards.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var parser = new CsvParser();
            var lines = File.ReadAllLines("TestData/Export.csv");


            var result = parser.Parse(lines);

            Assert.Equal("Englisch", result.FrontName);
        }
    }
}
