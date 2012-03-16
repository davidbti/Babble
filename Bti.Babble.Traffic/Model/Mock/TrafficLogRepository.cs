using System;

namespace Bti.Babble.Traffic.Model.Mock
{
    class TrafficLogRepository : ITrafficLogRepository
    {
        public TrafficLogRepository()
        {
        }

        public void Delete(Model.TrafficLog log)
        {
        }

        public Model.TrafficLog GetByDate(DateTime date)
        {
            return new Model.TrafficLog();
        }

        public void Save(Model.TrafficLog log)
        {
        }
    }
}