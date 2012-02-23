using System;
using System.Xml;

namespace Bti.Babble.Traffic.Model
{
    public class TrafficEvent : ObservableObject
    {
        private TimeSpan time;
        private TimeSpan length;
        private string description;
        private TrafficEventType type;
        private string barcode;

        public TimeSpan Time
        {
            get { return this.time; }
            set
            {
                this.time = value;
                RaisePropertyChanged("Time");
            }
        }

        public TimeSpan Length
        {
            get { return this.length; }
            set
            {
                this.length = value;
                RaisePropertyChanged("Length");
            }
        }

        public string Description
        {
            get { return this.description; }
            set
            {
                this.description = value;
                RaisePropertyChanged("Description");
            }
        }

        public TrafficEventType Type
        {
            get { return this.type; }
            set
            {
                this.type = value;
                RaisePropertyChanged("Type");
            }
        }

        public string Barcode
        {
            get { return this.barcode; }
            set
            {
                this.barcode = value;
                RaisePropertyChanged("Barcode");
            }
        }

        public void Write(XmlWriter writer)
        {
            writer.WriteStartElement("Event");
            writer.WriteStartElement("Time");
            writer.WriteValue(Time.Hours.ToString("00") + ":" + Time.Minutes.ToString("00") + ":" + Time.Seconds.ToString("00"));
            writer.WriteEndElement();
            writer.WriteStartElement("Length");
            writer.WriteValue(Length.Hours.ToString("00") + ":" + Length.Minutes.ToString("00") + ":" + Length.Seconds.ToString("00"));
            writer.WriteEndElement();
            writer.WriteStartElement("Description");
            writer.WriteValue(Description);
            writer.WriteEndElement();
            writer.WriteStartElement("Type");
            string type = Enum.GetName(typeof(TrafficEventType), Type);
            writer.WriteValue(type);
            writer.WriteEndElement();
            writer.WriteStartElement("Barcode");
            writer.WriteValue(Barcode);
            writer.WriteEndElement();
            writer.WriteEndElement(); //Event
        }
    }
}

