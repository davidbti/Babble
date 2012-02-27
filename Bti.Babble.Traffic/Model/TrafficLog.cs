using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Collections.ObjectModel;

namespace Bti.Babble.Traffic.Model
{
    public class TrafficLog : ObservableObject
    {
        private DateTime date;
        public DateTime parseDate;
        public string station;
        public ObservableCollection<TrafficEvent> events;

        public DateTime Date
        {
            get { return this.date; }
            set
            {
                this.date = value;
                RaisePropertyChanged("Date");
            }
        }

        public DateTime ParseDate
        {
            get { return this.parseDate; }
            set
            {
                this.parseDate = value;
                RaisePropertyChanged("ParseDate");
            }
        }

        public string Station
        {
            get { return this.station; }
            set
            {
                this.station = value;
                RaisePropertyChanged("Station");
            }
        }

        public ObservableCollection<TrafficEvent> Events
        {
            get { return this.events; }
            set
            {
                this.events = value;
                RaisePropertyChanged("Events");
            }
        }

        public TrafficLog()
        {
            Date = new DateTime(2000, 1, 1);
            ParseDate = new DateTime(2000, 1, 1);
            Station = "";
            Events = new ObservableCollection<TrafficEvent>();
        }
    }
}
