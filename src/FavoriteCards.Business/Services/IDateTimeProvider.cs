using System;

namespace FavoriteCards.Business.Services
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}