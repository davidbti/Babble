using System;
using System.Xml;

namespace Bti.Babble.Traffic
{
    public class TrafficEvent : ObservableObject
    {
        private DateTime date;
        private bool primary;
        private int sequenceId;
        private TimeSpan startTime;
        private TimeSpan duration;
        private string targetDevice;
        private string targetId;
        private string description;
        private TrafficEventClassification classification;

        public DateTime Date
        {
            get { return this.date; }
            set
            {
                this.date = value;
                RaisePropertyChanged("Date");
            }
        }

        public bool Primary
        {
            get { return this.primary; }
            set
            {
                this.primary = value;
                RaisePropertyChanged("Primary");
            }
        }

        public int SequenceId
        {
            get { return this.sequenceId; }
            set
            {
                this.sequenceId = value;
                RaisePropertyChanged("SequenceId");
            }
        }

        public TimeSpan StartTime
        {
            get { return this.startTime; }
            set
            {
                this.startTime = value;
                RaisePropertyChanged("StartTime");
            }
        }

        public TimeSpan Duration
        {
            get { return this.duration; }
            set
            {
                this.duration = value;
                RaisePropertyChanged("Duration");
            }
        }

        public string TargetDevice
        {
            get { return this.targetDevice; }
            set
            {
                this.targetDevice = value;
                RaisePropertyChanged("TargetDevice");
            }
        }

        public string TargetId
        {
            get { return this.targetId; }
            set
            {
                this.targetId = value;
                RaisePropertyChanged("TargetId");
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

        public TrafficEventClassification Classification
        {
            get { return this.classification; }
            set
            {
                this.classification = value;
                RaisePropertyChanged("Classification");
            }
        }

        public void Write(XmlWriter writer)
        {
            writer.WriteStartElement("Event");
            writer.WriteStartElement("Date");
            writer.WriteValue(Date);
            writer.WriteEndElement();
            writer.WriteStartElement("Primary");
            writer.WriteValue(Primary);
            writer.WriteEndElement();
            writer.WriteStartElement("SequenceId");
            writer.WriteValue(SequenceId);
            writer.WriteEndElement();
            writer.WriteStartElement("StartTime");
            writer.WriteValue(StartTime.Hours.ToString("00") + ":" + StartTime.Minutes.ToString("00") + ":" + StartTime.Seconds.ToString("00"));
            writer.WriteEndElement();
            writer.WriteStartElement("Duration");
            writer.WriteValue(Duration.Hours.ToString("00") + ":" + Duration.Minutes.ToString("00") + ":" + Duration.Seconds.ToString("00"));
            writer.WriteEndElement();
            writer.WriteStartElement("TargetDevice");
            writer.WriteValue(TargetDevice);
            writer.WriteEndElement();
            writer.WriteStartElement("TargetId");
            writer.WriteValue(TargetId);
            writer.WriteEndElement();
            writer.WriteStartElement("Description");
            writer.WriteValue(Description);
            writer.WriteEndElement();
            writer.WriteStartElement("Classification");
            string classification = Enum.GetName(typeof(TrafficEventClassification), Classification);
            writer.WriteValue(classification);
            writer.WriteEndElement();
            writer.WriteEndElement(); //Event
        }
    }
}

