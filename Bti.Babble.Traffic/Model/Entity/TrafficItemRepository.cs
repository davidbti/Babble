using System;
using System.Linq;
using System.Xml.Linq;

namespace Bti.Babble.Traffic.Model.Entity
{
    class TrafficItemRepository : ITrafficItemRepository
    {
        private readonly BabbleContainer context;

        public TrafficItemRepository(BabbleContainer context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.context = context;
        }

        public Model.TrafficItem GetByItemProperties(Model.TrafficItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            var query = (from ti in context.TrafficItems
                         where ti.Type == (int)item.Type && ti.Description == item.Description
                         select ti).AsEnumerable().Select(o => o.ToModelObject());
            var results = query.ToList();
            return query.SingleOrDefault();
        }

        public void Save(Model.TrafficItem item)
        {
            var entity = TrafficItem.ToEntityObject(item);
            if (entity.Id == 0) { context.TrafficItems.AddObject(entity); }
            context.SaveChanges();
        }
    }
}
