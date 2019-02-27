using System;
using System.Collections.Generic;
using System.Text;

namespace FavoriteCards.Business.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
    }
}
