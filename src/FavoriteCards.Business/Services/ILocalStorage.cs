using System.Threading.Tasks;

namespace FavoriteCards.Business.Services 
{
    public interface ILocalStorage 
    {
        Task SetItem(string identifier, object data);
        Task<T> GetItem<T>(string identifier);
        void RemoveItem(string identifier);
        void Clear();
        Task<int> Length();
        Task<string> Key(int index);
    }
}