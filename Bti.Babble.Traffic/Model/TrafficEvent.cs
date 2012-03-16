using System;
using System.Collections.Generic;
using System.Xml;
using System.Collections.ObjectModel;

namespace Bti.Babble.Traffic.Model
{
    public class TrafficEvent : ObservableObject
    {
        private int id;
        private TimeSpan time;
        private TimeSpan length;
        private TrafficItem item;

        public int Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
                RaisePropertyChanged("Id");
            }
        }

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

        public TrafficItem Item
        {
            get { return this.item; }
            set
            {
                this.item = value;
                RaisePropertyChanged("Item");
            }
        }

        public TrafficEvent()
        {
            this.Id = 0;
            this.Item = new TrafficItem();
            this.Length = new TimeSpan(0, 0, 0);
            this.Time = new TimeSpan(0, 0, 0);
        }
    }
}

