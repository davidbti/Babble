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

namespace Bti.Babble.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    public class Service : IService
    {
        private babble GetBabbleEvents(string viewerId)
        {
            var events = new babble();
            using (var context = new BabbleContainer())
            {
                var repository = new BabbleEventRepository(context);
                foreach (var evt in repository.GetEvents(10))
                {
                    events.Add(evt);
                }
            }
            return events;
        }

        public babble GetBabbleEventsAsXml(string viewerId)
        {
            return GetBabbleEvents(viewerId);
        }

        public babble GetBabbleEventsAsJson(string viewerId)
        {
            return GetBabbleEvents(viewerId);
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
    }
}
