using FavoriteCards.Business.Model;
using FavoriteCards.Business.Services;
using Microsoft.AspNetCore.Components;

namespace FavoriteCards.App.Pages
{
    public class LearnDeckModel : ComponentBase
    {
        private Card _card;
        private bool _front = true;

        [Inject] public Learn Learn { get; set; }

        public string Word { get; set; }

        public void Toggle()
        {
            if (_front)
                Word = _card.Front;
            else
                Word = _card.Back;

            StateHasChanged();

            _front = !_front;
        }

        protected override void OnInit()
        {
            _card = Learn.GetNextCard();
        }
    }
}