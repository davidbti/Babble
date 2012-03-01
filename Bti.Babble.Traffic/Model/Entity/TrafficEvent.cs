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
                BabbleEvents = (from o in this.BabbleEvents select o.ToModelObject()).ToObservable(),
                Barcode = this.Barcode,
                Description = this.Description,
                Isci = this.ISCI,
                Length = ConvertTimeToTimespan(this.Length),
                Time = ConvertTimeToTimespan(this.Time),
                Type = (TrafficEventType)this.Type,
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
                BabbleEvents = ToEntityCollection(o.BabbleEvents),
                Barcode = o.Barcode,
                Description = o.Description,
                ISCI = o.Isci,
                Length = ConvertTimespanToTime(o.Length),
                Time = ConvertTimespanToTime(o.Time),
                Type = (int)o.Type
            };
        }

        internal static string ConvertTimespanToTime(TimeSpan timespan)
        {
            return timespan.Hours.ToString("D2") + ":" + timespan.Minutes.ToString("D2") + ":" + timespan.Seconds.ToString("D2");
        }

        internal static EntityCollection<BabbleEvent> ToEntityCollection(ObservableCollection<Model.BabbleEvent> events)
        {
            var collection = new EntityCollection<BabbleEvent>();
            foreach (var evt in events)
            {
                var evtEntity = BabbleEvent.ToEntityObject(evt);
                collection.Add(evtEntity);
            }
            return collection;
        }
    }
}
