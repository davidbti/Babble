using System;
using System.Collections.Generic;

namespace Bti.Babble.Traffic
{
    public class BabbleEventRepository : IBabbleEventRepository
    {
        public IEnumerable<BabbleEvent> GetAll()
        {
            var events = new List<BabbleEvent>();
            var e1 = new BabbleEvent()
            {
                Name = "Crown Ford",
                Body = "Visit Crown Ford in the next 10 minutes to receive 1000 dollars off your next ford pickup",
                Classification = BabbleEventClassification.Headline,
                Feed = BabbleEventFeed.None,
                Link = "http://crownford.com/"
            };
            events.Add(e1);
            var e2 = new BabbleEvent()
            {
                Name = "How I Met Your Mother Promo",
                Body = "How I Met Your Mother : Tonight at 6:30",
                Classification = BabbleEventClassification.Comment,
                Feed = BabbleEventFeed.None,
                Link = ""
            };
            events.Add(e2);
            var e3 = new BabbleEvent()
            {
                Name = "Commercial rating",
                Body = "Rate this commercial",
                Classification = BabbleEventClassification.Rating,
                Feed = BabbleEventFeed.None,
                Link = ""
            };
            events.Add(e3);
            var e4 = new BabbleEvent()
            {
                Name = "Question of the day",
                Body = "Should tax payer money be used to keep the Predators in town?",
                Classification = BabbleEventClassification.Poll,
                Feed = BabbleEventFeed.None,
                Link = ""
            };
            events.Add(e4);
            return events;
        }
    }
}
