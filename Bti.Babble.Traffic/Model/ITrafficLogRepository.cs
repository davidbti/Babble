using System;

namespace Bti.Babble.Traffic
{
    interface ITrafficLogRepository
    {
        TrafficLog GetByDate(DateTime date);
    }
}