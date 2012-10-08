using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using System.IO;
using Bti.Babble.Model;
using Bti.Babble.Model.Entity;
using System.Xml;
using System.Text;

namespace Bti.Babble.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    public class Service : IService
    {
        private babble GetBabbleEvents(string viewer, int commentCount, int storyCount, int pollCount, int couponCount)
        {
            var events = new babble();
            using (var context = new BabbleContainer())
            {
                var repository = new BabbleEventRepository(context);
                foreach (var evt in repository.GetEvents(commentCount, storyCount, pollCount, couponCount))
                {
                    events.Add(evt);
                }
            }
            return events;
        }

        public babble GetBabbleEventsAsXml(string viewer, int commentCount, int storyCount, int pollCount, int couponCount)
        {
            return GetBabbleEvents(viewer, commentCount, storyCount, pollCount, couponCount);
        }

        public babble GetBabbleEventsAsJson(string viewer, int commentCount, int storyCount, int pollCount, int couponCount)
        {
            return GetBabbleEvents(viewer, commentCount, storyCount, pollCount, couponCount);
        }

        private babble GetBabbleEventsSince(string viewerId, string id)
        {
            var events = new babble();
            using (var context = new BabbleContainer())
            {
                var repository = new BabbleEventRepository(context);
                foreach (var evt in repository.GetEventsSince(int.Parse(id)))
                {
                    events.Add(evt);
                }
            }
            return events;
        }

        public babble GetBabbleEventsSinceAsXml(string viewerId, string id)
        {
            return GetBabbleEventsSince(viewerId, id);
        }

        public babble GetBabbleEventsSinceAsJson(string viewerId, string id)
        {
            return GetBabbleEventsSince(viewerId, id);
        }

        private babble GetTwitterEvents(int resultsPerPage, string query)
        {
            var events = new babble();
            var request = new TwitterRequest(resultsPerPage, query);
            foreach (var evt in request.Download())
            {
                events.Add(evt);
            }
            return events;
        }

        public babble GetTwitterEventsAsXml(int resultsPerPage, string query)
        {
            return GetTwitterEvents(resultsPerPage, query);
        }

        public babble GetTwitterEventsAsJson(int resultsPerPage, string query)
        {
            return GetTwitterEvents(resultsPerPage, query);
        }

        private void PostBabbleEvents(XmlElement events)
        {
            var response = new babble();
            var buffer = Encoding.UTF8.GetBytes(events.OuterXml);
            using (var stream = new MemoryStream(buffer))
            {
                using (var reader = XmlReader.Create(stream))
                {
                    response.ReadXml(reader);
                }
            }
            using (var context = new BabbleContainer())
            {
                var repository = new BabbleEventRepository(context);
                foreach (var evt in response)
                {
                    repository.Save(evt);
                }
            }
        }

        public void PostBabbleEventsAsXml(XmlElement events)
        {
            PostBabbleEvents(events);
        }
    }
}
