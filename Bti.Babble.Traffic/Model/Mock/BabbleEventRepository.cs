using System;
using System.Collections.Generic;
using Bing;

namespace Bti.Babble.Traffic.Model.Mock
{
    public class BabbleEventRepository : IBabbleEventRepository
    {
        private const string API_KEY = "9174754FDCD3CBAA852676B50CF0E0ED07436958";

        public IEnumerable<BabbleEvent> GetForTrafficEvent(TrafficEvent evt)
        {
            switch (evt.Type)
            {
                case TrafficEventType.Id:
                    return GetForIdEvent(evt);
                case TrafficEventType.Program:
                    return GetForProgramEvent(evt);
                case TrafficEventType.Promo:
                    return GetForPromoEvent(evt);
                case TrafficEventType.Commercial:
                    return GetForCommercialEvent(evt);
            }
            return new List<BabbleEvent>();
        }

        public IEnumerable<BabbleEvent> GetForIdEvent(TrafficEvent evt)
        {
            var events = new List<BabbleEvent>();
            var b1 = new BabbleEvent()
            {
                Body = "Thank you for watching News 2. Your local source for late breaking news, sports, weather and traffic",
                Type = BabbleEventType.Tease,
                Link = @"http://www.wkrn.com",
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
                Type = BabbleEventType.Twitter,
                Link = "",
            };
            events.Add(b1);
            var b2 = new BabbleEvent()
            {
                Body = "",
                Type = BabbleEventType.Rss,
                Link = @"http://www.wkrn.com/global/Category.asp?c=126083&clienttype=rss",
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
                Type = BabbleEventType.Tease,
                Link = @"http://www.wkrn.com",
            };
            events.Add(b1);
            return events;
        }

        public IEnumerable<BabbleEvent> GetForCommercialEvent(TrafficEvent evt)
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
                    Type = BabbleEventType.Tease,
                    Link = result.Url,
                };
                events.Add(b1);
            }
            var b2 = new BabbleEvent()
            {
                Body = "Let us know what you think of this " + evt.Description + " commercial",
                Type = BabbleEventType.Rating,
                Link = "",
            };
            events.Add(b2);
            var b3 = new BabbleEvent()
            {
                Body = "Like us on Facebook",
                Type = BabbleEventType.Facebook,
                Link = "",
            };
            events.Add(b3);
            return events;
        }

    }
}
