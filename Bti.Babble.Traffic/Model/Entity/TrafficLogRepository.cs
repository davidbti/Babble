using System;
using System.Linq;
using System.Xml.Linq;
using System.Data;

namespace Bti.Babble.Traffic.Model.Entity
{
    class TrafficLogRepository : ITrafficLogRepository
    {
        private readonly BabbleContainer context;
        private readonly TrafficItemRepository repository;

        public TrafficLogRepository(BabbleContainer context, TrafficItemRepository repository)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.context = context;
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }
            this.repository = repository;
        }

        public void Delete(Model.TrafficLog log)
        {
            var exists = (from o in context.TrafficLogs
                          where o.Id == log.Id
                          select o).SingleOrDefault();
            if (exists == null) throw new ArgumentException("log does not exist for log.Id " + log.Id);
            context.TrafficLogs.DeleteObject(exists);
            context.SaveChanges();
        }

        public Model.TrafficLog GetByDate(DateTime date)
        {
            if (date == null)
            {
                throw new ArgumentNullException("date");
            }
            repository.ClearCache();
            var query = (from log in context.TrafficLogs
                         where log.Date == date
                         select log).AsEnumerable().Select(o => o.ToModelObject(repository));
            return query.SingleOrDefault();
        }

        public void Save(Model.TrafficLog log)
        {
            var entity = TrafficLog.ToEntityObject(log);
            if (entity.Id == 0) { context.TrafficLogs.AddObject(entity); }
            context.SaveChanges();
        }
    }
}