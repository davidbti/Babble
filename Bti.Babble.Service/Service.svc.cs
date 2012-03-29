using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using System.IO;
using Bti.Babble.Model;

namespace Bti.Babble.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    public class Service : IService
    {
        private babble GetBabbleEvents(string viewerId)
        {
            var events = new babble();
            var e1 = new CommentEvent()
            {
                Id = 1,
                PubDate = DateTime.Now,
                Type = "comment",
                User = "TPBGirl2011",
                Message = "@drhoagie @wkrn Scary part is, the people who search you at the airport may be meth addicts or have the chemicals on them. Not good. #TSA",
                Image = "http://prod.bti.tv/F5F4DC42-1E5A-4FE3-B866-5EAEFCB4CC5B/TPBGirl2011TPB_normal.jpg"
            };
            events.Add(e1);
            var e2 = new StoryEvent()
            {
                Id = 2,
                PubDate = DateTime.Now,
                Type = "story",
                User = "Local News Alert",
                Message = "Man arrested after threatening to blow up school bus",
                Image = "http://prod.bti.tv/95758C95-5085-4421-B356-D2BB4435301B/wkrn.jpg",
                Title = "Man arrested after threatening to blow up school bus",
                Description = "Authorities in Henry County arrested Steven Decker, 27, Wednesday morning after he threatened to blow up a school bus with students onboard.",
                StoryImage = "http://WKRN.images.worldnow.com/images/17274405_SS.jpg",
                Link = "http://www.wkrn.com/story/17274405/adult-threatened-to-blow-up-school-bus-in-paris"
            };
            events.Add(e2);
            var e3 = new CouponEvent()
            {
                Id = 3,
                PubDate = DateTime.Now,
                Type = "coupon",
                User = "Diapers.com",
                Message = "Earn 20% cash back on your first order on Diapers.com with purchase of diapers",
                Image = "http://prod.bti.tv/95758C95-5085-4421-B356-D2BB4435301B/diapers_com.jpg",
                Store = "Diapers.com",
                Coupon = "Earn 20% cash back on your first order on Diapers.com with purchase of diapers",
                Code = "TRYUS2",
                Link = "http://www.diapers.com/?src=lp_aff_060911"
            };
            events.Add(e3);
            var r1 = new PollResponse()
            {
                Text = "Yes",
                Votes = 75
            };
            var r2 = new PollResponse()
            {
                Text = "No",
                Votes = 75
            };
            var responses = new List<PollResponse>();
            responses.Add(r1);
            responses.Add(r2);
            var e4 = new PollEvent()
            {
                Id = 4,
                PubDate = DateTime.Now,
                Type = "poll",
                User = "Let Us Know What You Think",
                Message = "Should TSA agents be required to have a college degree in law enforcement?",
                Image = "http://prod.bti.tv/95758C95-5085-4421-B356-D2BB4435301B/poll.jpg",
                Question = "Should TSA agents be required to have a college degree in law enforcement?",
                Votes = 100,
                Responses = responses
    
            };
            events.Add(e4);
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
            var iid = int.Parse(id);
            var query = (from e in GetBabbleEvents(viewerId)
                         where e.Id > iid
                         select e).AsEnumerable();
            foreach (var r in query) { events.Add(r); }
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
