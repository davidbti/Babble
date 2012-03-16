using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace Bti.Babble.Traffic.Model.Entity
{
    partial class TrafficEvent
    {
        internal Model.TrafficEvent ToModelObject()
        {
            if (this == null) return null;
            return new Model.TrafficEvent()
            {
                Id = this.Id,
                Barcode = this.Barcode,
                Item = this.TrafficItem.ToModelObject(),
                Isci = this.Isci,
                Length = ConvertTimeToTimespan(this.Length),
                Segment = this.Segment,
                Time = ConvertTimeToTimespan(this.Time),
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
                TrafficItem = TrafficItem.ToEntityObject(o.Item),
                Barcode = o.Barcode,
                Length = ConvertTimespanToTime(o.Length),
                Isci = o.Isci,
                Segment = o.Segment,
                Time = ConvertTimespanToTime(o.Time),
            };
        }

        internal static string ConvertTimespanToTime(TimeSpan timespan)
        {
            return timespan.Hours.ToString("D2") + ":" + timespan.Minutes.ToString("D2") + ":" + timespan.Seconds.ToString("D2");
        }
    }
}
