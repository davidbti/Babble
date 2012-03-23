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
        internal Model.TrafficEvent ToModelObject(TrafficItemRepository repository)
        {
            if (this == null) return null;
            return new Model.TrafficEvent()
            {
                Id = this.Id,
                TrafficLogId = this.TrafficLogId,
                Advertiser = this.Advertiser,
                Barcode = this.Barcode,
                Item  = repository.GetFromCache(this.TrafficItem),
                Isci = this.Isci,
                Length = ConvertTimeToTimespan(this.Length),
                ProgramNumber = this.ProgramNumber,
                SegmentNumber = this.SegmentNumber,
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
                Id = o.Id,
                TrafficLogId = o.TrafficLogId,
                Advertiser = o.Advertiser,
                Barcode = o.Barcode,
                TrafficItemId = o.Item.Id,
                Isci = o.Isci,
                Length = ConvertTimespanToTime(o.Length),
                ProgramNumber = o.ProgramNumber,
                SegmentNumber = o.SegmentNumber,
                Time = ConvertTimespanToTime(o.Time),
            };
        }

        internal static string ConvertTimespanToTime(TimeSpan timespan)
        {
            return timespan.Hours.ToString("D2") + ":" + timespan.Minutes.ToString("D2") + ":" + timespan.Seconds.ToString("D2");
        }
    }
}
