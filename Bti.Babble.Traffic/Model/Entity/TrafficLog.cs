using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace Bti.Babble.Traffic.Model.Entity
{
    partial class TrafficLog
    {
        internal Model.TrafficLog ToModelObject(TrafficItemRepository repository)
        {
            if (this == null) return null;
            return new Model.TrafficLog()
            {
                Id = this.Id,
                Date = this.Date,
                Events = (from o in this.TrafficEvents select o.ToModelObject(repository)).ToObservable(),
                ParseDate = this.ParseDate,
                Station = this.StationName
            };
        }

        internal static TrafficLog ToEntityObject(Model.TrafficLog o)
        {
            if (o == null) return null;
            return new TrafficLog()
            {
                Id = o.Id,
                Date = o.Date,
                TrafficEvents = ToEntityCollection(o.Events),
                ParseDate = o.ParseDate,
                StationName = o.Station,
            };
        }

        internal static EntityCollection<TrafficEvent> ToEntityCollection(ObservableCollection<Model.TrafficEvent> events)
        {
            var collection = new EntityCollection<TrafficEvent>();
            foreach (var evt in events)
            {
                var evtEntity = TrafficEvent.ToEntityObject(evt);
                collection.Add(evtEntity);
            }
            return collection;
        }
    }
}
