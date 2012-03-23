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
                Description2 = this.Description2,
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
                Description2 = o.Description2,
                Type = (int)o.Type
            };
        }

        internal static void UpdateEntityObject(BabbleContainer context, TrafficItem e, Model.TrafficItem o)
        {
            var todelete = new List<BabbleItem>();
            foreach (var entity in e.BabbleItems)
            {
                var model = (from p in o.BabbleItems
                               where p.Id == entity.Id
                               select p).FirstOrDefault();
                if (model == null)
                {
                    todelete.Add(entity);
                }
                else
                {
                    BabbleItem.UpdateEntityObject(model, entity);
                }
            }
            foreach (var entity in todelete)
            {
                context.DeleteObject(entity);
            }
            foreach (var model in o.BabbleItems)
            {
                var entity = (from p in e.BabbleItems
                             where p.Id == model.Id
                             select p).FirstOrDefault();
                if (entity == null)
                {
                    model.TrafficItemId = e.Id;
                    context.BabbleItems.AddObject(BabbleItem.ToEntityObject(model));
                }
            }
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
