using System;
using System.Xml.Linq;

namespace Bti.Babble.Traffic.Model.Entity
{
    class TrafficLogRepository : ITrafficLogRepository
    {
        private readonly BabbleContainer context;

        public TrafficLogRepository(string connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }
            context = new BabbleContainer(connection);
        }

        public Model.TrafficLog GetByDate(DateTime date)
        {
            var log = new TrafficLog().ToModelObject();
            return log;
        }

        public void Save(Model.TrafficLog log)
        {
            var entity = TrafficLog.ToEntityObject(log);
            context.TrafficLogs.AddObject(entity);
            context.SaveChanges();
        }
    }
}