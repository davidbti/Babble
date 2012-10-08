using System;
using System.Xml;
using System.Xml.Serialization;

namespace Bti.Babble.Model
{
    public class BabbleEvent : IXmlSerializable
    {
        public int Id { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime PubDate { get; set; }
        public string Type { get; set; }
        public string User { get; set; }
        public string Message { get; set; }
        public string Image { get; set; }
        public string Large { get; set; }

        public BabbleEvent() { }

        public BabbleEvent(BabbleEvent evt) 
        {
            Id = evt.Id;
            Time = evt.Time;
            PubDate = evt.PubDate;
            Type = evt.Type;
            User = evt.User;
            Message = evt.Message;
            Image = evt.Image;
            Large = evt.Large;
        }

        public static BabbleEvent CreateFromXmlReader(System.Xml.XmlReader reader)
        {
            var evt = new BabbleEvent();
            evt.ReadXml(reader);
            switch (evt.Type)
            {
                case "comment":
                    var comment = new CommentEvent(evt);
                    comment.ReadXml(reader);
                    return comment;
                case "coupon":
                    var coupon = new CouponEvent(evt);
                    coupon.ReadXml(reader);
                    return coupon;
                case "info":
                    var info = new InfoEvent(evt);
                    info.ReadXml(reader);
                    return info;
                case "poll":
                    var poll = new PollEvent(evt);
                    poll.ReadXml(reader);
                    return poll;
                case "story":
                    var story = new StoryEvent(evt);
                    story.ReadXml(reader);
                    return story;
            }
            return evt;
        }

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public virtual void ReadXml(System.Xml.XmlReader reader)
        {
            reader.ReadToDescendant("header");
            reader.ReadToDescendant("time");
            Time = ConvertTimeToTimespan(reader.ReadElementContentAsString());
            reader.MoveToContent();
            Type = reader.ReadElementContentAsString();
            reader.MoveToContent();
            User = reader.ReadElementContentAsString();
            reader.MoveToContent();
            Message = reader.ReadElementContentAsString();
            reader.MoveToContent();
            Image = reader.ReadElementContentAsString();
            reader.MoveToContent();
            Large = reader.ReadElementContentAsString();
            reader.ReadEndElement();
        }

        internal TimeSpan ConvertTimeToTimespan(string time)
        {
            var timesplit = time.Split(':');
            return new TimeSpan(int.Parse(timesplit[0]), int.Parse(timesplit[1]), int.Parse(timesplit[2]));
        }

        protected void WriteHeader(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("header");
            writer.WriteElementString("id", Id.ToString());
            writer.WriteElementString("pubDate", PubDate.ToUniversalTime().ToString());
            writer.WriteElementString("time", ConvertTimespanToTime(Time));
            writer.WriteElementString("type", Type);
            writer.WriteElementString("user", User);
            writer.WriteElementString("message", Message);
            writer.WriteElementString("image", Image);
            writer.WriteElementString("large", Large);
            writer.WriteEndElement();
        }

        internal static string ConvertTimespanToTime(TimeSpan timespan)
        {
            return timespan.Hours.ToString("D2") + ":" + timespan.Minutes.ToString("D2") + ":" + timespan.Seconds.ToString("D2");
        }

        public virtual void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("event");
            WriteHeader(writer);
            writer.WriteEndElement();
        }
    }
}