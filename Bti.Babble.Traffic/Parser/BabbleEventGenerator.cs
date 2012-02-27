using System;
using Bti.Babble.Traffic.Model;
using System.Collections.Generic;
using Bing;

namespace Bti.Babble.Traffic.Parser
{
    public interface IBabbleEventGenerator
    {
        IEnumerable<BabbleEvent> Generate(TrafficLog log, TrafficEvent evt);
    }

    public class CommercialBabbleEventGenerator : IBabbleEventGenerator
    {
        private readonly string apikey;
        public CommercialBabbleEventGenerator(string apikey) { this.apikey = apikey; }

        public IEnumerable<BabbleEvent> Generate(TrafficLog log, TrafficEvent evt)
        {
            var events = new List<BabbleEvent>();
            SearchRequest searchRequest = new SearchRequest { AppId = apikey, Query = log.Station, Market = "en-US" };
            WebRequest webRequest = new WebRequest();
            webRequest.Count = 1;
            WebResponse webResponse = API.Web(searchRequest, webRequest);
            foreach (var result in webResponse.Results)
            {
                var b1 = new BabbleEvent()
                {
                    Body = result.Description,
                    Type = BabbleEventType.Tease,
                    Link = result.Url
                };
                events.Add(b1);
            }
            var b2 = new BabbleEvent()
            {
                Body = "Let " + evt.Description + " know how much you like them. Like them on facebook now.",
                Type = BabbleEventType.Facebook,
                Link = @"",
            };
            events.Add(b2);
            var b3 = new BabbleEvent()
            {
                Body = "What did you think of this " + evt.Description + " commercial?",
                Type = BabbleEventType.Rating,
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

        public IEnumerable<BabbleEvent> Generate(TrafficLog log, TrafficEvent evt)
        {
            var events = new List<BabbleEvent>();
            SearchRequest searchRequest = new SearchRequest { AppId = apikey, Query = log.Station, Market = "en-US" };
            WebRequest webRequest = new WebRequest();
            webRequest.Count = 1;
            WebResponse webResponse = API.Web(searchRequest, webRequest);
            foreach (var result in webResponse.Results)
            {
                var b1 = new BabbleEvent()
                {
                    Body = result.Description,
                    Type = BabbleEventType.Tease,
                    Link = result.Url
                };
                events.Add(b1);
            }
            return events;
        }
    }

    public class NoneBabbleEventGenerator : IBabbleEventGenerator
    {
        public IEnumerable<BabbleEvent> Generate(TrafficLog log, TrafficEvent evt)
        {
            return new List<BabbleEvent>();
        }
    }

    public class ProgramBabbleEventGenerator : IBabbleEventGenerator
    {
        private readonly string apikey;
        public ProgramBabbleEventGenerator(string apikey) { this.apikey = apikey; }

        public IEnumerable<BabbleEvent> Generate(TrafficLog log, TrafficEvent evt)
        {
            var events = new List<BabbleEvent>();
            var b1 = new BabbleEvent()
            {
                Body = "",
                Type = BabbleEventType.Twitter,
                Link = "",
            };
            events.Add(b1);
            var b2 = new BabbleEvent()
            {
                Body = "",
                Type = BabbleEventType.Rss,
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

        public IEnumerable<BabbleEvent> Generate(TrafficLog log, TrafficEvent evt)
        {
            var events = new List<BabbleEvent>();
            var b1 = new BabbleEvent()
            {
                Body = evt.Isci,
                Type = BabbleEventType.Tease,
                Link = "",
            };
            events.Add(b1);
            return events;
        }
    }

    public class BabbleEventGenerator
    {
        protected const string API_KEY = "9174754FDCD3CBAA852676B50CF0E0ED07436958";

        public static IEnumerable<BabbleEvent> Generate(TrafficLog log, TrafficEvent evt)
        {
            switch (evt.Type)
            {
                case TrafficEventType.Commercial :
                    return new CommercialBabbleEventGenerator(API_KEY).Generate(log, evt);
                case TrafficEventType.Id :
                    return new IdBabbleEventGenerator(API_KEY).Generate(log, evt);
                case TrafficEventType.None :
                    return new NoneBabbleEventGenerator().Generate(log, evt);
                case TrafficEventType.Program :
                    return new ProgramBabbleEventGenerator(API_KEY).Generate(log, evt);
                case TrafficEventType.Promo :
                    return new PromoBabbleEventGenerator(API_KEY).Generate(log, evt);
            }
            throw new ArgumentException("Event type not recognized");
        }
    }
}
