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
        public string PollImage { get; set; }

        public PollEvent()
        {
            Responses = new List<PollResponse>();
        }

        public PollEvent(BabbleEvent evt) : base(evt) 
        {
            Responses = new List<PollResponse>();
        }

        public override void ReadXml(System.Xml.XmlReader reader)
        {
            reader.ReadToDescendant("image");
            PollImage = reader.ReadElementContentAsString();
            reader.MoveToContent();
            reader.MoveToAttribute("text");
            Question = reader.Value;
            reader.MoveToAttribute("votes");
            Votes = int.Parse(reader.Value);
            while (reader.ReadToNextSibling("response"))
            {
                var response = new PollResponse();
                reader.MoveToAttribute("text");
                response.Text = reader.Value;
                reader.MoveToAttribute("votes");
                response.Votes = int.Parse(reader.Value);
                Responses.Add(response);
            }
            reader.ReadEndElement();
        }

        public override void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("event");
            base.WriteHeader(writer);
            writer.WriteStartElement("body");
            writer.WriteElementString("image", PollImage);
            writer.WriteStartElement("question");
            writer.WriteAttributeString("text", Question);
            writer.WriteAttributeString("votes", Votes.ToString());
            writer.WriteEndElement();
            foreach (var response in Responses)
            {
                writer.WriteStartElement("response");
                writer.WriteAttributeString("text", response.Text);
                writer.WriteAttributeString("votes", response.Votes.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }

    public class PollResponse
    {
        public int Id { get; set; }
        public int PollEventId { get; set; }
        public string Text { get; set; }
        public int Votes { get; set; }

        public PollResponse()
        {
            this.Id = 0;
            this.PollEventId = 0;
            this.Text = "";
            this.Votes = 0;
        }
    }
}