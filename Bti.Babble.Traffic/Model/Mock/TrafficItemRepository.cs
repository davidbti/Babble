using System;

namespace Bti.Babble.Traffic.Model.Mock
{
    class TrafficItemRepository : ITrafficItemRepository
    {
        public TrafficItemRepository()
        {
        }

        public void ClearCache()
        {
        }

        public Model.TrafficItem GetById(int id)
        {
            return new Model.TrafficItem();
        }

        public Model.TrafficItem GetByItemProperties(TrafficItem item)
        {
            return new Model.TrafficItem();
        }

        public void Save(TrafficItem item)
        {
        }
    }
}
