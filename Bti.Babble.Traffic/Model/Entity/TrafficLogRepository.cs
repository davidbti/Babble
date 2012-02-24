using System;
using System.Xml.Linq;

namespace Bti.Babble.Traffic.Model.Entity
{
    class TrafficLogRepository : ITrafficLogRepository
    {
        public Model.TrafficLog GetByDate(DateTime date)
        {
            var log = new TrafficLog().ToModelObject();
            return log;
        }
    }
}