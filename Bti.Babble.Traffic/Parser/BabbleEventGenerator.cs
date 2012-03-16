using System;
using Bti.Babble.Traffic.Model;
using System.Collections.Generic;
using Bing;

namespace Bti.Babble.Traffic.Parser
{
    public interface IBabbleEventGenerator
    {
        IEnumerable<BabbleItem> Generate(TrafficLog log, TrafficItem evt);
    }

    public class CommercialBabbleEventGenerator : IBabbleEventGenerator
    {
        private readonly string apikey;
        public CommercialBabbleEventGenerator(string apikey) { this.apikey = apikey; }

        public IEnumerable<BabbleItem> Generate(TrafficLog log, TrafficItem evt)
        {
            var events = new List<BabbleItem>();
            SearchRequest searchRequest = new SearchRequest { AppId = apikey, Query = log.Station, Market = "en-US" };
            WebRequest webRequest = new WebRequest();
            webRequest.Count = 1;
            WebResponse webResponse = API.Web(searchRequest, webRequest);
            foreach (var result in webResponse.Results)
            {
                var b1 = new BabbleItem()
                {
                    Body = result.Description,
                    Type = BabbleItemType.Tease,
                    Link = result.Url
                };
                events.Add(b1);
            }
            var b2 = new BabbleItem()
            {
                Body = "Let " + evt.Description + " know how much you like them. Like them on facebook now.",
                Type = BabbleItemType.Facebook,
                Link = @"",
            };
            events.Add(b2);
            var b3 = new BabbleItem()
            {
                Body = "What did you think of this " + evt.Description + " commercial?",
                Type = BabbleItemType.Rating,
                Link = "",
            };
            events.Add(b3);
            return events;
        }
    }

    public class IdBabbleEventGenerator : IBabbleEventGenerator
    {
        private readonly string apikey;
        public IdBabbleEventGenerator(string apikey) { this.apikey = apikey; }

        public IEnumerable<BabbleItem> Generate(TrafficLog log, TrafficItem evt)
        {
            var events = new List<BabbleItem>();
            SearchRequest searchRequest = new SearchRequest { AppId = apikey, Query = log.Station, Market = "en-US" };
            WebRequest webRequest = new WebRequest();
            webRequest.Count = 1;
            WebResponse webResponse = API.Web(searchRequest, webRequest);
            foreach (var result in webResponse.Results)
            {
                var b1 = new BabbleItem()
                {
                    Body = result.Description,
                    Type = BabbleItemType.Tease,
                    Link = result.Url
                };
                events.Add(b1);
            }
            return events;
        }
    }

    public class NoneBabbleEventGenerator : IBabbleEventGenerator
    {
        public IEnumerable<BabbleItem> Generate(TrafficLog log, TrafficItem evt)
        {
            return new List<BabbleItem>();
        }
    }

    public class ProgramBabbleEventGenerator : IBabbleEventGenerator
    {
        private readonly string apikey;
        public ProgramBabbleEventGenerator(string apikey) { this.apikey = apikey; }

        public IEnumerable<BabbleItem> Generate(TrafficLog log, TrafficItem evt)
        {
            var events = new List<BabbleItem>();
            var b1 = new BabbleItem()
            {
                Body = "",
                Type = BabbleItemType.Twitter,
                Link = "",
            };
            events.Add(b1);
            var b2 = new BabbleItem()
            {
                Body = "",
                Type = BabbleItemType.Rss,
                Link = "",
            };
            events.Add(b2);
            return events;
        }
    }

    public class PromoBabbleEventGenerator : IBabbleEventGenerator
    {
        private readonly string apikey;
        public PromoBabbleEventGenerator(string apikey) { this.apikey = apikey; }

        public IEnumerable<BabbleItem> Generate(TrafficLog log, TrafficItem evt)
        {
            var events = new List<BabbleItem>();
            var b1 = new BabbleItem()
            {
                Body = evt.Isci,
                Type = BabbleItemType.Tease,
                Link = "",
            };
            events.Add(b1);
            return events;
        }
    }

    public class BabbleEventGenerator
    {
        protected const string API_KEY = "9174754FDCD3CBAA852676B50CF0E0ED07436958";

        public static IEnumerable<BabbleItem> Generate(TrafficLog log, TrafficItem evt)
        {
            switch (evt.Type)
            {
                case TrafficItemType.Commercial :
                    return new CommercialBabbleEventGenerator(API_KEY).Generate(log, evt);
                case TrafficItemType.Id :
                    return new IdBabbleEventGenerator(API_KEY).Generate(log, evt);
                case TrafficItemType.None :
                    return new NoneBabbleEventGenerator().Generate(log, evt);
                case TrafficItemType.Program :
                    return new ProgramBabbleEventGenerator(API_KEY).Generate(log, evt);
                case TrafficItemType.Promo :
                    return new PromoBabbleEventGenerator(API_KEY).Generate(log, evt);
            }
            throw new ArgumentException("Event type not recognized");
        }
    }
}
