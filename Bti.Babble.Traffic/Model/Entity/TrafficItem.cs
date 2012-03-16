using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace Bti.Babble.Traffic.Model.Entity
{
    partial class TrafficItem
    {
        internal Model.TrafficItem ToModelObject()
        {
            if (this == null) return null;
            return new Model.TrafficItem()
            {
                Id = this.Id,
                BabbleItems = (from o in this.BabbleItems select o.ToModelObject()).ToObservable(),
                Description = this.Description,
                Type = (TrafficItemType)this.Type,
            };
        }

        internal static TrafficItem ToEntityObject(Model.TrafficItem o)
        {
            if (o == null) return null;
            return new TrafficItem()
            {
                Id = o.Id,
                BabbleItems = ToEntityCollection(o.BabbleItems),
                Description = o.Description,
                Type = (int)o.Type
            };
        }

        internal static string ConvertTimespanToTime(TimeSpan timespan)
        {
            return timespan.Hours.ToString("D2") + ":" + timespan.Minutes.ToString("D2") + ":" + timespan.Seconds.ToString("D2");
        }

        internal static EntityCollection<BabbleItem> ToEntityCollection(ObservableCollection<Model.BabbleItem> events)
        {
            var collection = new EntityCollection<BabbleItem>();
            foreach (var evt in events)
            {
                var evtEntity = BabbleItem.ToEntityObject(evt);
                collection.Add(evtEntity);
            }
            return collection;
        }
    }
}
