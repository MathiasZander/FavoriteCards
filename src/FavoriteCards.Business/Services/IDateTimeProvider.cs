using System;
using System.Collections.Generic;
using System.Text;

namespace FavoriteCards.Business.Services
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}
