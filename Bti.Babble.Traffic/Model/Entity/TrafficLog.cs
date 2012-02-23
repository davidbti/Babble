using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace Bti.Babble.Traffic.Model.Entity
{
    partial class TrafficLog
    {
        internal Model.TrafficLog ToModelObject()
        {
            if (this == null) return null;
            return new Model.TrafficLog()
            {
                Date = this.Date,
                Events = (from o in this.TrafficEvents select o.ToModelObject()).ToList(),
                ParseDate = this.ParseDate,
                Station = this.StationName
            };
        }

        internal static TrafficLog ToEntityObject(Model.TrafficLog o)
        {
            if (o == null) return null;
            return new TrafficLog()
            {
                Date = o.Date,
                TrafficEvents = ToEntityCollection(o.Events),
                ParseDate = o.ParseDate,
                StationName = o.Station,
            };
        }

        internal static EntityCollection<TrafficEvent> ToEntityCollection(List<Model.TrafficEvent> events)
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
