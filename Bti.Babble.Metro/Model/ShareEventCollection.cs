using System;
using System.Collections.ObjectModel;

namespace Bti.Babble.Metro.Model
{
    class ShareEventCollection : ObservableCollection<BabbleEventGroup>
    {
        public int LiveCount { get; set; }
        public int StoryCount { get; set; }
        public int PollCount { get; set; }
        public int CouponCount { get; set; }

        public ShareEventCollection()
        {
            var live = new BabbleEventGroup() 
            { 
                Title = "Live", 
                Events = new ObservableCollection<BabbleEvent>() 
            };
            this.Add(live);
            var story = new BabbleEventGroup()
            {
                Title = "Stories",
                Events = new ObservableCollection<BabbleEvent>()
            };
            this.Add(story);
            var poll = new BabbleEventGroup()
            {
                Title = "Polls",
                Events = new ObservableCollection<BabbleEvent>()
            };
            this.Add(poll);
            var coupon = new BabbleEventGroup()
            {
                Title = "Coupons",
                Events = new ObservableCollection<BabbleEvent>()
            };
            this.Add(coupon);
        }

        public void AddEvent(BabbleEvent evt)
        {
            if (evt.Type == "comment") return;
            InsertEventOnCount(evt, Items[0], LiveCount);
            switch (evt.Type)
            {
                case "story":
                    InsertEventOnCount(evt, Items[1], StoryCount);
                    break;
                case "poll":
                    InsertEventOnCount(evt, Items[2], PollCount);
                    break;
                case "coupon":
                    InsertEventOnCount(evt, Items[3], CouponCount);
                    break;
            }
        }

        private void InsertEventOnCount(BabbleEvent evt, BabbleEventGroup group, int count)
        {
            if (group.Events.Count >= count)
            {
                group.Events.Insert(0, evt);
                group.Events.RemoveAt(group.Events.Count - 1);
            }
            else
            {
                group.Events.Insert(0, evt);
            }
        }
    }
}
