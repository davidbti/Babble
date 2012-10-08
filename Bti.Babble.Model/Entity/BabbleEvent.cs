using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace Bti.Babble.Model.Entity
{
    partial class BabbleEvent
    {
        internal virtual Model.BabbleEvent ToModelObject() 
        {
            if (this == null) return null;
            return new Model.BabbleEvent()
            {
                Id = this.Id,
                Image = this.Image,
                Large = this.Large,
                Message = this.Message,
                PubDate = this.PubDate,
                Time = ConvertTimeToTimespan(this.Time),
                Type = this.Type,
                User = this.User
            };
        }

        internal TimeSpan ConvertTimeToTimespan(string time)
        {
            var timesplit = time.Split(':');
            return new TimeSpan(int.Parse(timesplit[0]), int.Parse(timesplit[1]), int.Parse(timesplit[2]));
        }

        internal static string ConvertTimespanToTime(TimeSpan timespan)
        {
            return timespan.Hours.ToString("D2") + ":" + timespan.Minutes.ToString("D2") + ":" + timespan.Seconds.ToString("D2");
        }
    }
}
