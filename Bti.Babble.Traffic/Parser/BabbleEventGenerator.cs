using System;
using Bti.Babble.Traffic.Model;
using System.Collections.Generic;
using Bing;

namespace Bti.Babble.Traffic.Parser
{
    public interface IBabbleEventGenerator
    {
        IEnumerable<BabbleItem> Generate(TrafficLog log, TrafficEvent evt, TrafficItem item);
    }

    public class CommercialBabbleEventGenerator : IBabbleEventGenerator
    {
        private readonly string apikey;
        public CommercialBabbleEventGenerator(string apikey) { this.apikey = apikey; }

        public IEnumerable<BabbleItem> Generate(TrafficLog log, TrafficEvent evt, TrafficItem item)
        {
            var events = new List<BabbleItem>();
            SearchRequest searchRequest = new SearchRequest { AppId = apikey, Query = item.Description, Market = "en-US" };
            WebRequest webRequest = new WebRequest();
            webRequest.Count = 1;
            WebResponse webResponse = API.Web(searchRequest, webRequest);
            foreach (var result in webResponse.Results)
            {
                var b1 = new BabbleItem()
                {
                    Message = result.Description,
                    Type = BabbleItemType.Info,
                    Link = result.Url
                };
                events.Add(b1);
            }
            return events;
        }
    }

    public class NoneBabbleEventGenerator : IBabbleEventGenerator
    {
        public IEnumerable<BabbleItem> Generate(TrafficLog log, TrafficEvent evt, TrafficItem item)
        {
            return new List<BabbleItem>();
        }
    }

    public class ProgramBabbleEventGenerator : IBabbleEventGenerator
    {
        private readonly string apikey;
        public ProgramBabbleEventGenerator(string apikey) { this.apikey = apikey; }

        public IEnumerable<BabbleItem> Generate(TrafficLog log, TrafficEvent evt, TrafficItem item)
        {
            var events = new List<BabbleItem>();
            var b1 = new BabbleItem()
            {
                Message = "#" + item.Description,
                Type = BabbleItemType.Twitter,
                Link = "",
            };
            events.Add(b1);
            var b2 = new BabbleItem()
            {
                Message = "",
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

        public IEnumerable<BabbleItem> Generate(TrafficLog log, TrafficEvent evt, TrafficItem item)
        {
            var events = new List<BabbleItem>();
            var b1 = new BabbleItem()
            {
                Message = evt.Isci,
                Type = BabbleItemType.Info,
                Link = "",
            };
            events.Add(b1);
            return events;
        }
    }

    public class BabbleEventGenerator
    {
        protected const string API_KEY = "9174754FDCD3CBAA852676B50CF0E0ED07436958";

        public static IEnumerable<BabbleItem> Generate(TrafficLog log, TrafficEvent evt, TrafficItem item)
        {
            switch (item.Type)
            {
                case TrafficItemType.Commercial :
                    return new CommercialBabbleEventGenerator(API_KEY).Generate(log, evt, item);
                case TrafficItemType.None:
                    return new NoneBabbleEventGenerator().Generate(log, evt, item);
                case TrafficItemType.Program:
                    return new ProgramBabbleEventGenerator(API_KEY).Generate(log, evt, item);
                case TrafficItemType.Promo:
                    return new PromoBabbleEventGenerator(API_KEY).Generate(log, evt, item);
            }
            throw new ArgumentException("Event type not recognized");
        }
    }
}
