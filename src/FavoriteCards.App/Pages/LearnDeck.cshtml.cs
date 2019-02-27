using FavoriteCards.Business.Model;
using FavoriteCards.Business.Services;
using Microsoft.AspNetCore.Components;

namespace FavoriteCards.App.Pages
{
    public class LearnDeckModel : ComponentBase
    {
        private Card _card;
        public bool Answer { get; private set; }

        [Inject] public Learn Learn { get; set; }

        public string Word { get; set; }

        public void Toggle()
        {
            Word = Answer ? _card.Back : _card.Front;

            StateHasChanged();

            Answer = !Answer;
        }

        public void Correct()
        {
            Learn.SetResult(_card.Front, true);
            _card = Learn.GetNextCard();
        }

        public void Wrong()
        {
            Learn.SetResult(_card.Front, false);
            _card = Learn.GetNextCard();
        }

        protected override void OnInit()
        {
            _card = Learn.GetNextCard();
        }
    }
}