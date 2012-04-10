using System;
using System.Xml.Serialization;

namespace Bti.Babble.Model
{
    public class InfoEvent : BabbleEvent
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string InfoImage { get; set; }
        
        public InfoEvent() { }

        public InfoEvent(BabbleEvent evt) : base(evt) { }

        public override void ReadXml(System.Xml.XmlReader reader)
        {
            reader.ReadToDescendant("title");
            Title = reader.ReadElementContentAsString();
            reader.MoveToContent();
            Description = reader.ReadElementContentAsString();
            reader.MoveToContent();
            InfoImage = reader.ReadElementContentAsString();
            reader.MoveToContent();
            Link = reader.ReadElementContentAsString();
            reader.ReadEndElement();
        }

        public override void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("event");
            base.WriteHeader(writer);
            writer.WriteStartElement("body");
            writer.WriteElementString("title", Title);
            writer.WriteElementString("description", Description);
            writer.WriteElementString("image", InfoImage);
            writer.WriteElementString("link", Link);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}