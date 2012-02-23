using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bti.Babble.Traffic.Model.Entity
{
    partial class TrafficEvent
    {
        internal Model.TrafficEvent ToModelObject()
        {
            if (this == null) return null;
            return new Model.TrafficEvent()
            {
                Barcode = this.Barcode,
                Description = this.Description,
                Length = ConvertTimeToTimespan(this.Length),
                Time = ConvertTimeToTimespan(this.Time),
                Type = (TrafficEventType)this.Type
            };
        }

        internal TimeSpan ConvertTimeToTimespan(string time)
        {
            var timesplit = time.Split(':');
            return new TimeSpan(int.Parse(timesplit[0]), int.Parse(timesplit[1]), int.Parse(timesplit[2]));
        }

        internal static TrafficEvent ToEntityObject(Model.TrafficEvent o)
        {
            if (o == null) return null;
            return new TrafficEvent()
            {
                Barcode = o.Barcode,
                Description = o.Description,
                Length = ConvertTimespanToTime(o.Length),
                Time = ConvertTimespanToTime(o.Time),
                Type = (int)o.Type
            };
        }

        internal static string ConvertTimespanToTime(TimeSpan timespan)
        {
            return timespan.Hours.ToString("D2") + ":" + timespan.Minutes.ToString("D2") + ":" + timespan.Seconds.ToString("D2");
        }
    }
}
