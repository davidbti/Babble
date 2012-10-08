using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bti.Babble.Model.Entity
{
    public class BabbleEventRepository : IBabbleEventRepository
    {
        private readonly BabbleContainer context;

        public BabbleEventRepository(BabbleContainer context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.context = context;
        }

        public void DeleteOldEvents()
        {
            var old = DateTime.Now.Subtract(new TimeSpan(0, 10, 0));
            var events = (from o in context.BabbleEvents
                          where o.PubDate < old
                          select o).ToList();
            foreach (var evt in events)
            {
                context.BabbleEvents.DeleteObject(evt);
                context.SaveChanges();
            }
        }

        public List<Model.BabbleEvent> GetEvents(int commentCount, int storyCount, int pollCount, int couponCount)
        {
            var events = new List<Model.BabbleEvent>();
            var comments = (from o in context.BabbleEvents
                            where o.Type == "comment"
                            orderby o.Id descending
                            select o).AsEnumerable().Select(o => o.ToModelObject()).Take(commentCount);
            foreach (var evt in comments) { events.Add(evt); }
            var stories = (from o in context.BabbleEvents
                            where o.Type == "story"
                            orderby o.Id descending
                            select o).AsEnumerable().Select(o => o.ToModelObject()).Take(storyCount);
            foreach (var evt in stories) { events.Add(evt); }
            var polls = (from o in context.BabbleEvents
                           where o.Type == "poll"
                           orderby o.Id descending
                           select o).AsEnumerable().Select(o => o.ToModelObject()).Take(pollCount);
            foreach (var evt in polls) { events.Add(evt); }
            var coupons = (from o in context.BabbleEvents
                         where o.Type == "coupon"
                         orderby o.Id descending
                         select o).AsEnumerable().Select(o => o.ToModelObject()).Take(couponCount);
            foreach (var evt in coupons) { events.Add(evt); }
            return (from o in events
                    orderby o.Id ascending
                    select o).ToList();
        }

        public List<Model.BabbleEvent> GetEventsSince(int id)
        {
            var events = (from o in context.BabbleEvents
                          where o.Id > id
                          select o).AsEnumerable().Select(o => o.ToModelObject());
            return events.ToList();
        }

        public void Save(Model.BabbleEvent evt)
        {
            evt.PubDate = DateTime.Now;
            var comment = evt as Model.CommentEvent;
            if (comment != null) 
            {
                var entity = CommentEvent.ToEntityObject(comment);
                context.BabbleEvents.AddObject(entity);
                context.SaveChanges();
                return;
            }
            var coupon = evt as Model.CouponEvent;
            if (coupon != null)
            {
                var entity = CouponEvent.ToEntityObject(coupon);
                context.BabbleEvents.AddObject(entity);
                context.SaveChanges();
                return;
            }
            var info = evt as Model.InfoEvent;
            if (info != null)
            {
                var entity = InfoEvent.ToEntityObject(info);
                context.BabbleEvents.AddObject(entity);
                context.SaveChanges();
                return;
            }
            var poll = evt as Model.PollEvent;
            if (poll != null)
            {
                var entity = PollEvent.ToEntityObject(poll);
                context.BabbleEvents.AddObject(entity);
                context.SaveChanges();
                return;
            }
            var story = evt as Model.StoryEvent;
            if (story != null)
            {
                var entity = StoryEvent.ToEntityObject(story);
                context.BabbleEvents.AddObject(entity);
                context.SaveChanges();
                return;
            }
        }
    }
}
