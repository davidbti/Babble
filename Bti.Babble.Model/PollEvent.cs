using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Bti.Babble.Model
{
    public class PollEvent : BabbleEvent
    {
        public string Question { get; set; }
        public int Votes { get; set; }
        public List<PollResponse> Responses { get; set; }

        public PollEvent() { }

        public PollEvent(BabbleEvent evt) : base(evt) { }

        public override void ReadXml(System.Xml.XmlReader reader)
        {
            reader.ReadToDescendant("body");
            reader.ReadToDescendant("question");
            reader.MoveToAttribute("text");
            Question = reader.Value;
            reader.MoveToAttribute("votes");
            Votes = int.Parse(reader.Value);
            while (reader.ReadToDescendant("response"))
            {
                var response = new PollResponse();
                reader.MoveToAttribute("text");
                response.Text = reader.Value;
                reader.MoveToAttribute("votes");
                response.Votes = int.Parse(reader.Value);
                Responses.Add(response);
            }
        }

        public override void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("event");
            base.WriteHeader(writer);
            writer.WriteStartElement("body");
            writer.WriteStartElement("question");
            writer.WriteAttributeString("text", Question);
            writer.WriteAttributeString("votes", Votes.ToString());
            foreach (var response in Responses)
            {
                writer.WriteStartElement("response");
                writer.WriteAttributeString("text", response.Text);
                writer.WriteAttributeString("votes", response.Votes.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }

    public class PollResponse
    {
        public string Text { get; set; }
        public int Votes { get; set; }
    }
}