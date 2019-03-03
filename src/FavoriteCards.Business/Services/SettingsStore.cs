using System.Threading.Tasks;
using FavoriteCards.Business.Model;

namespace FavoriteCards.Business.Services
{
    public class SettingsStore
    {
        private const string Key = "FavoriteCardsSettings";
        private readonly ILocalStorage _localStorage;

        public SettingsStore(ILocalStorage localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task<Settings> Read()
        {
            return await _localStorage.GetItem<Settings>(Key);
        }

        public async void Write(Settings settings)
        {
            await _localStorage.SetItem(Key, settings);
        }
    }
}