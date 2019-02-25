using System;
using FavoriteCards.Business.Model;
using FavoriteCards.Business.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace FavoriteCards.App.Pages
{
    public class ImportModel : ComponentBase
    {
        [Inject]
        public CsvParser Parser { get; set; }

        [Inject]
        public Learn Learn { get; set; }

        private static ImportModel _instance;

        public ImportModel()
        {
            _instance = this;
        }

        private void Parse(string csv)
        {
            Deck = Parser.Parse(csv);
            Learn.SetDeck(Deck);
            StateHasChanged();
        }

        protected Deck Deck { get; private set; } = new Deck();

        [JSInvokable(nameof(FileChanged))]
        public static void FileChanged(string csv)
        {
            Console.WriteLine($"FileChanged: {csv}");
            _instance.Parse(csv);
        }
    }
}