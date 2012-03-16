using System;
using System.Collections.Generic;

namespace Bti.Babble.Traffic.Model
{
    public interface IBabbleItemRepository
    {
        IEnumerable<BabbleItem> GetForTrafficItem(TrafficItem item);
    }
}
