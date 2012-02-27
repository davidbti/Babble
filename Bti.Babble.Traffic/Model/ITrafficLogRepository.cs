using System;

namespace Bti.Babble.Traffic.Model
{
    interface ITrafficLogRepository
    {
        TrafficLog GetByDate(DateTime date);
        void Save(TrafficLog log);
    }
}