using FavoriteCards.App.Model;
using FavoriteCards.App.Services;
using Microsoft.AspNetCore.Components;

namespace FavoriteCards.App.Pages
{
    public class LearnDeckModel : ComponentBase
    {
        private Card _card;
        private bool front = true;

        [Inject] public Learn Learn { get; set; }

        public string Word { get; set; }

        public void Toggle()
        {
            if (front)
                Word = _card.Front;
            else
                Word = _card.Back;

            StateHasChanged();

            front = !front;
        }

        protected override void OnInit()
        {
            _card = Learn.GetNextCard();
        }
    }
}