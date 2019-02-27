using System;
using System.Collections.Generic;

namespace FavoriteCards.Business.Model
{
    public class LearnSettings
    {
        public List<TimeSpan> IntervalLevels { get; set; }

        public LearnSettings()
        {
            IntervalLevels = new List<TimeSpan>
            {
                new TimeSpan(1,0,0,0),
                new TimeSpan(7,0,0,0),
                new TimeSpan(21,0,0,0),
                new TimeSpan(90,0,0,0),
                new TimeSpan(182,0,0,0)
            };
        }
    }
}