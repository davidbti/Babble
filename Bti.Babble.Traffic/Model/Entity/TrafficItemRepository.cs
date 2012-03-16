using System;
using System.Linq;
using System.Xml.Linq;
using System.Configuration;

namespace Bti.Babble.Traffic.Model.Entity
{
    class TrafficItemRepository : ITrafficItemRepository
    {
        private readonly BabbleContainer context;

        public TrafficItemRepository()
        {
            string connection = ConfigurationManager.ConnectionStrings["BabbleContainer"].ConnectionString;
            context = new BabbleContainer(connection);
        }

        public Model.TrafficItem GetByDescriptionAndType(Model.TrafficItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            var query = (from ti in context.TrafficItems
                         where ti.Description == item.Description && ti.Type == (int)item.Type
                         select ti).AsEnumerable().Select(o => o.ToModelObject());
            return query.SingleOrDefault();
        }
    }
}
