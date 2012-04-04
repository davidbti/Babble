using System;
using System.Xml.Serialization;

namespace Bti.Babble.Model
{
    public class InfoEvent : BabbleEvent
    {
        public string Link { get; set; }

        public InfoEvent() { }

        public InfoEvent(BabbleEvent evt) : base(evt) { }

        public override void ReadXml(System.Xml.XmlReader reader)
        {
            reader.ReadToDescendant("link");
            Link = reader.ReadElementContentAsString();
            reader.ReadEndElement();
        }

        public override void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("event");
            base.WriteHeader(writer);
            writer.WriteStartElement("body");
            writer.WriteElementString("link", Link);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}