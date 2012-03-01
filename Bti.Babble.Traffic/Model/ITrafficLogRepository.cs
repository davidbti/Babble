using System;

namespace Bti.Babble.Traffic.Model
{
    interface ITrafficLogRepository
    {
        void Delete(TrafficLog log);
        TrafficLog GetByDate(DateTime date);
        void Save(TrafficLog log);
    }
}