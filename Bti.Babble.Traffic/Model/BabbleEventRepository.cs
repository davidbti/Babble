using System;
using System.Collections.Generic;
using Bing;

namespace Bti.Babble.Traffic
{
    public class BabbleEventRepository : IBabbleEventRepository
    {
        private const string API_KEY = "9174754FDCD3CBAA852676B50CF0E0ED07436958";

        public IEnumerable<BabbleEvent> GetForTrafficEvent(TrafficEvent evt)
        {
            switch (evt.Classification)
            {
                case TrafficEventClassification.Id:
                    return GetForIdEvent(evt);
                case TrafficEventClassification.Program:
                    return GetForProgramEvent(evt);
                case TrafficEventClassification.Promo:
                    return GetForPromoEvent(evt);
                case TrafficEventClassification.Spot:
                    return GetForSpotEvent(evt);
            }
            return new List<BabbleEvent>();
        }

        public IEnumerable<BabbleEvent> GetForIdEvent(TrafficEvent evt)
        {
            var events = new List<BabbleEvent>();
            var b1 = new BabbleEvent()
            {
                Body = "Thank you for watching News 2. Your local source for late breaking news, sports, weather and traffic",
                Classification = BabbleEventClassification.Tease,
                Link = @"http://www.wkrn.com",
                Name = "Station Id"
            };
            events.Add(b1);
            return events;
        }

        public IEnumerable<BabbleEvent> GetForProgramEvent(TrafficEvent evt)
        {
            var events = new List<BabbleEvent>();
            var b1 = new BabbleEvent()
            {
                Body = "#News2",
                Classification = BabbleEventClassification.Twitter,
                Link = "",
                Name = evt.Description + " Twitter Feed"
            };
            events.Add(b1);
            var b2 = new BabbleEvent()
            {
                Body = "",
                Classification = BabbleEventClassification.Rss,
                Link = @"http://www.wkrn.com/global/Category.asp?c=126083&clienttype=rss",
                Name = evt.Description + " Rss Feed"
            };
            events.Add(b2);
            return events;
        }

        public IEnumerable<BabbleEvent> GetForPromoEvent(TrafficEvent evt)
        {
            var events = new List<BabbleEvent>();
            var b1 = new BabbleEvent()
            {
                Body = "Tragedy strikes the mayor and his family. Tonight @ 6",
                Classification = BabbleEventClassification.Tease,
                Link = @"http://www.wkrn.com",
                Name = "6 pm promo"
            };
            events.Add(b1);
            return events;
        }

        public IEnumerable<BabbleEvent> GetForSpotEvent(TrafficEvent evt)
        {
            var events = new List<BabbleEvent>();

            SearchRequest searchRequest = new SearchRequest { AppId = API_KEY, Query = evt.Description, Market = "en-US" };
            WebRequest webRequest = new WebRequest();
            webRequest.Count = 1;
            WebResponse webResponse = API.Web(searchRequest, webRequest);
            foreach (var result in webResponse.Results)
            {
                var b1 = new BabbleEvent()
                {
                    Body = result.Description,
                    Classification = BabbleEventClassification.Tease,
                    Link = result.Url,
                    Name = evt.Description + " Information"
                };
                events.Add(b1);
            }
            var b2 = new BabbleEvent()
            {
                Body = "Let us know what you think of this " + evt.Description + " commercial",
                Classification = BabbleEventClassification.Rating,
                Link = "",
                Name = evt.Description + " Rating"
            };
            events.Add(b2);
            return events;
        }

    }
}
