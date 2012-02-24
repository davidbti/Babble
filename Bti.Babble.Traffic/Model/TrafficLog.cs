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
    }
}
