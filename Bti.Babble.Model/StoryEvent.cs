﻿using System;
using System.Xml.Serialization;

namespace Bti.Babble.Model
{
    public class StoryEvent : BabbleEvent
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string StoryImage { get; set; }

        public StoryEvent() { }

        public StoryEvent(BabbleEvent evt) : base(evt) { }

        public override void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("event");
            base.WriteHeader(writer);
            writer.WriteStartElement("body");
            writer.WriteElementString("title", Title);
            writer.WriteElementString("description", Description);
            writer.WriteElementString("image", StoryImage);
            writer.WriteElementString("link", Link);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}