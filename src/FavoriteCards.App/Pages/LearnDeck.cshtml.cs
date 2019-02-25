using System;
using System.Runtime.Serialization;
using FavoriteCards.App.Model;
using FavoriteCards.App.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace FavoriteCards.App.Pages
{
    public class LearnDeckModel : ComponentBase
    {
        [Inject]
        public Learn Learn { get; set; }

        public string Word { get; set; }

        private Card _card;
        private bool front = true;

        public void Toggle()
        {
            if (front)
            {
                Word = _card.Front;
            }
            else
            {
                Word = _card.Back;
            }

            StateHasChanged();

            front = !front;

        }

        protected override void OnInit()
        {
            _card = Learn.GetNextCard();
        }
    }
}