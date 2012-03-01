using System;
using System.Linq;
using System.Xml.Linq;
using System.Configuration;

namespace Bti.Babble.Traffic.Model.Entity
{
    class TrafficLogRepository : ITrafficLogRepository
    {
        private readonly BabbleContainer context;

        public TrafficLogRepository()
        {
            string connection = ConfigurationManager.ConnectionStrings["BabbleContainer"].ConnectionString;
            context = new BabbleContainer(connection);
        }

        public void Delete(Model.TrafficLog log)
        {
            var entity = TrafficLog.ToEntityObject(log);
            context.TrafficLogs.DeleteObject(entity);
            context.SaveChanges();
        }

        public Model.TrafficLog GetByDate(DateTime date)
        {
            if (date == null)
            {
                throw new ArgumentNullException("date");
            }
            var query = (from log in context.TrafficLogs
                         where log.Date == date
                         select log).AsEnumerable().Select(o => o.ToModelObject());
            return query.SingleOrDefault();
        }

        public void Save(Model.TrafficLog log)
        {
            var entity = TrafficLog.ToEntityObject(log);
            context.TrafficLogs.AddObject(entity);
            context.SaveChanges();
        }
    }
}