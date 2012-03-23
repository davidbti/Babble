using System;

namespace Bti.Babble.Traffic.Model
{
    interface ITrafficItemRepository
    {
        TrafficItem GetById(int id);
        TrafficItem GetByItemProperties(TrafficItem item);
        void Save(TrafficItem item);
    }
}