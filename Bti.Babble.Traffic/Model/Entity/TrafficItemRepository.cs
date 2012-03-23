using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Bti.Babble.Traffic.Model.Entity
{
    class TrafficItemRepository : ITrafficItemRepository
    {
        private readonly BabbleContainer context;
        private Dictionary<int, Model.TrafficItem> cache;

        public TrafficItemRepository(BabbleContainer context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.context = context;
            this.cache = new Dictionary<int, Model.TrafficItem>();
        }

        public void ClearCache()
        {
            this.cache.Clear();
        }

        public Model.TrafficItem GetById(int id)
        {
            var query = (from ti in context.TrafficItems
                         where ti.Id == id
                         select ti).AsEnumerable().Select(o => GetFromCache(o));
            return query.SingleOrDefault();
        }

        public Model.TrafficItem GetByItemProperties(Model.TrafficItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            var query = (from ti in context.TrafficItems
                         where ti.Type == (int)item.Type && ti.Description == item.Description && ti.Description2 == item.Description2
                         select ti).AsEnumerable().Select(o => GetFromCache(o));
            return query.SingleOrDefault();
        }

        public Model.TrafficItem GetFromCache(TrafficItem item)
        {
            Model.TrafficItem value;
            if (cache.TryGetValue(item.Id, out value))
            {
                return value;
            }
            else
            {
                value = item.ToModelObject();
                cache.Add(value.Id, value);
                return value;
            }
        }

        public void Save(Model.TrafficItem item)
        {
            var entity = TrafficItem.ToEntityObject(item);
            if (entity.Id == 0)
            {
                context.TrafficItems.AddObject(entity);
            }
            else
            {
                var exists = (from o in context.TrafficItems
                              where o.Id == item.Id
                              select o).SingleOrDefault();
                if (exists == null) throw new ArgumentException("TrafficItem does not exist for item.Id " + item.Id);
                TrafficItem.UpdateEntityObject(context, exists, item);
            }
            context.SaveChanges();
        }
    }
}
