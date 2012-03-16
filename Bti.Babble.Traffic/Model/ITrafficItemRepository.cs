using System;

namespace Bti.Babble.Traffic.Model
{
    interface ITrafficItemRepository
    {
        TrafficItem GetByItemProperties(TrafficItem item);
        void Save(TrafficItem item);
    }
}