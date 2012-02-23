using System;
using System.Collections.Generic;

namespace Bti.Babble.Traffic.Model
{
    public interface IBabbleEventRepository
    {
        IEnumerable<BabbleEvent> GetForTrafficEvent(TrafficEvent evt);
    }
}
