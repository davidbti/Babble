using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bti.Babble.Model.Mock
{
    public class BabbleEventRepository : IBabbleEventRepository
    {
        public List<BabbleEvent> GetEvents(int count)
        {
            return new List<BabbleEvent>();
        }

        public List<BabbleEvent> GetEventsSince(int id)
        {
            return new List<BabbleEvent>();
        }

        public void DeleteOldEvents()
        {
        }

        public void Save(BabbleEvent evt)
        {
        }
    }
}
