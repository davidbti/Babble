using System;
using System.Xml;
using System.Xml.Serialization;

namespace Bti.Babble.Model
{
    public class BabbleEvent : IXmlSerializable
    {
        public int Id { get; set; }
        public DateTime PubDate { get; set; }
        public string Type { get; set; }
        public string User { get; set; }
        public string Message { get; set; }
        public string Image { get; set; }

        public BabbleEvent() { }

        public BabbleEvent(BabbleEvent evt) 
        {
            Id = evt.Id;
            PubDate = evt.PubDate;
            Type = evt.Type;
            User = evt.User;
            Message = evt.Message;
            Image = evt.Image;
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
                case "story":
                    var story = new StoryEvent(evt);
                    story.ReadXml(reader);
                    return story;
                case "coupon":
                    var coupon = new CouponEvent(evt);
                    coupon.ReadXml(reader);
                    return coupon;
                case "poll":
                    var poll = new PollEvent(evt);
                    poll.ReadXml(reader);
                    return poll;
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
            reader.ReadToDescendant("type");
            Type = reader.ReadElementContentAsString();
            reader.MoveToContent();
            User = reader.ReadElementContentAsString();
            reader.MoveToContent();
            Message = reader.ReadElementContentAsString();
            reader.MoveToContent();
            Image = reader.ReadElementContentAsString();
        }

        protected void WriteHeader(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("header");
            writer.WriteElementString("id", Id.ToString());
            writer.WriteElementString("pubDate", PubDate.ToUniversalTime().ToString());
            writer.WriteElementString("type", Type);
            writer.WriteElementString("user", User);
            writer.WriteElementString("message", Message);
            writer.WriteElementString("image", Image);
            writer.WriteEndElement();
        }

        public virtual void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("event");
            WriteHeader(writer);
            writer.WriteEndElement();
        }
    }
}