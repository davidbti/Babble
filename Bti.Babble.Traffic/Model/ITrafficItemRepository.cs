using System;

namespace Bti.Babble.Traffic.Model
{
    interface ITrafficItemRepository
    {
        TrafficItem GetByDescriptionAndType(TrafficItem item);
    }
}