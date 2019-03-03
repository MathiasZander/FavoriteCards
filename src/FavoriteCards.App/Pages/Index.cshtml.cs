using System.Threading.Tasks;
using FavoriteCards.Business.Model;
using FavoriteCards.Business.Services;
using Microsoft.AspNetCore.Components;

namespace FavoriteCards.App.Pages
{
    public class IndexModel : ComponentBase
    {
        [Inject] public SettingsStore SettingsStore { get; set; }

        protected Settings Settings { get; private set; } = new Settings();

        protected override async Task OnInitAsync()
        {
            Settings = await SettingsStore.Read();
        }
    }
}