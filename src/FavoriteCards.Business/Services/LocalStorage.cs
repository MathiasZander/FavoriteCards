using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace FavoriteCards.Business.Services
{
    public class LocalStorage : ILocalStorage
    {
        public async Task SetItem(string identifier, object data)
        {
            if (string.IsNullOrEmpty(identifier))
                throw new ArgumentNullException(nameof(identifier));

            var serializedData = Json.Serialize(data);
            await JSRuntime.Current.InvokeAsync<bool>("LocalStorage.SetItem", identifier, serializedData);
        }

        public async Task<T> GetItem<T>(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
                throw new ArgumentNullException(nameof(identifier));

            var serializedData = await JSRuntime.Current.InvokeAsync<string>("LocalStorage.GetItem", identifier);
            Console.WriteLine(serializedData);
            if (serializedData == null)
                serializedData = String.Empty;
           
            return Json.Deserialize<T>(serializedData);
        }

        public void RemoveItem(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
                throw new ArgumentNullException(nameof(identifier));

            JSRuntime.Current.InvokeAsync<string>("LocalStorage.RemoveItem", identifier);
        }

        public void Clear()
        {
            JSRuntime.Current.InvokeAsync<bool>("LocalStorage.Clear");
        }

        public Task<int> Length()
        {
            return JSRuntime.Current.InvokeAsync<int>("LocalStorage.Length");
        }

        public Task<string> Key(int index)
        {
            return JSRuntime.Current.InvokeAsync<string>("LocalStorage.Key", index);
        }
    }
}