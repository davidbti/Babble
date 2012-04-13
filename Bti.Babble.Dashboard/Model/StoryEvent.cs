using System;
using System.Xml.Serialization;
using Windows.UI.Xaml.Media;

namespace Bti.Babble.Dashboard.Model
{
    public class StoryEvent : BabbleEvent
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string StoryImage { get; set; }
        public ImageSource StoryImageSource { get; set; }
        public string StoryText { get; set; }

        public StoryEvent() { }

        public StoryEvent(BabbleEvent evt) : base(evt) { }

        public override void ReadXml(System.Xml.XmlReader reader)
        {
            reader.ReadToDescendant("title");
            Title = reader.ReadElementContentAsString();
            reader.MoveToContent();
            Description = reader.ReadElementContentAsString();
            reader.MoveToContent();
            StoryImage = reader.ReadElementContentAsString();
            reader.MoveToContent();
            Link = reader.ReadElementContentAsString();
            reader.MoveToContent();
            StoryText = reader.ReadElementContentAsString();
            reader.ReadEndElement();
        }

        public override void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("event");
            base.WriteHeader(writer);
            writer.WriteStartElement("body");
            writer.WriteElementString("title", Title);
            writer.WriteElementString("description", Description);
            writer.WriteElementString("image", StoryImage);
            writer.WriteElementString("link", Link);
            writer.WriteStartElement("text");
            writer.WriteCData(StoryText);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}