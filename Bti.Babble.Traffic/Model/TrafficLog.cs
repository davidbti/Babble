using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Bti.Babble.Traffic.Model
{
    public class TrafficLog
    {
        public DateTime Date { get; set; }
        public DateTime ParseDate { get; set; }
        public string Station { get; set; }
        public List<TrafficEvent> Events { get; set; }

        public TrafficLog ToInitializedObject()
        {
            if (this == null) return null;
            return new TrafficLog()
            {
                Date = new DateTime(2000, 1, 1),
                ParseDate = new DateTime(2000, 1, 1),
                Station = "",
                Events = new List<TrafficEvent>()
            };
        }

        public void Write(string location)
        {
            XDocument doc = new XDocument();
            using (var writer = doc.CreateWriter())
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Log");
                writer.WriteStartElement("Date");
                writer.WriteValue(Date);
                writer.WriteEndElement();
                writer.WriteStartElement("ReadDate");
                writer.WriteValue(ParseDate);
                writer.WriteEndElement();
                writer.WriteStartElement("Station");
                writer.WriteValue(Station);
                writer.WriteEndElement();
                writer.WriteStartElement("Events");
                foreach (var trafficevent in Events)
                {
                    trafficevent.Write(writer);
                }
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            var path = Path.Combine(location, Station + 
                                              "_" + 
                                              Date.Year + Date.Month.ToString("00") + Date.Day.ToString("00") + 
                                              "_" +
                                              ParseDate.Year + ParseDate.Month.ToString("00") + ParseDate.Day.ToString("00") +
                                              "_" +
                                              ParseDate.Hour.ToString("00") + ParseDate.Minute.ToString("00") + ParseDate.Second.ToString("00") + 
                                              ".xml");
            doc.Save(path);
        }
    }
}
