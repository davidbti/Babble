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

        public List<Model.BabbleEvent> GetEvents(int count)
        {
            var events = (from o in context.BabbleEvents
                          orderby o.Id descending
                          select o).AsEnumerable().Select(o => o.ToModelObject()).Take(count);
            return events.ToList();
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
