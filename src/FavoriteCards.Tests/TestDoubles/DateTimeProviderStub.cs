using System;
using System.Collections.Generic;
using System.Text;
using FavoriteCards.Business.Services;

namespace FavoriteCards.Tests
{
    public class DateTimeProviderStub : IDateTimeProvider
    {
        public DateTimeProviderStub(DateTime now)
        {
            Now = now;
        }

        public DateTime Now { get; private set; }

        public void AddSeconds(int seconds)
        {
            Now = Now.AddSeconds(seconds);
        }

        public void AddDays(int days)
        {
            Now = Now.AddDays(days);
        }
    }
}
