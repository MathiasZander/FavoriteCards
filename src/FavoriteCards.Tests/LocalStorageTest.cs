using System.Threading.Tasks;
using FavoriteCards.Business.Model;
using FavoriteCards.Business.Services;
using FluentAssertions;
using Microsoft.JSInterop;
using Moq;
using Xunit;

namespace FavoriteCards.Tests
{
    public class LocalStorageTest
    {
        public LocalStorageTest()
        {
            var mock = new Mock<IJSRuntime>();
            mock.Setup(jsRuntime => jsRuntime.InvokeAsync<string>(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult((string) null));
            JSRuntime.SetCurrentJSRuntime(mock.Object);
        }

        [Fact]
        public async void GetItem_Should()
        {
            var localStorage = new LocalStorage();

            var settings = await localStorage.GetItem<Settings>("Test");

            settings.Should().NotBeNull();
        }
    }
}