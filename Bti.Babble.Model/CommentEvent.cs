using System;
using System.Xml.Serialization;

namespace Bti.Babble.Model
{
    public class CommentEvent : BabbleEvent
    {
        public CommentEvent() { }

        public CommentEvent(BabbleEvent evt) : base(evt) { }

        public override void ReadXml(System.Xml.XmlReader reader)
        {
            reader.ReadToDescendant("body");
        }

        public override void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("event");
            base.WriteHeader(writer);
            writer.WriteElementString("body", "");
            writer.WriteEndElement();
        }
    }
}