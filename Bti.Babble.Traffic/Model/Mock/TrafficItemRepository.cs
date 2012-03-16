using System;

namespace Bti.Babble.Traffic.Model.Mock
{
    class TrafficItemRepository : ITrafficItemRepository
    {
        public TrafficItemRepository()
        {
        }

        public Model.TrafficItem GetByDescriptionAndType(TrafficItem item)
        {
            return new Model.TrafficItem();
        }
    }
}
