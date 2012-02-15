using System;
using System.Xml.Linq;

namespace Bti.Babble.Traffic
{
    class TrafficLogRepository : ITrafficLogRepository
    {
        public TrafficLog GetByDate(DateTime date)
        {
            return new TrafficLog();
        }
    }
}