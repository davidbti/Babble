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
        private string barcode;
        private string isci;
        private int segment;

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

        public string Barcode
        {
            get { return this.barcode; }
            set
            {
                this.barcode = value;
                RaisePropertyChanged("Barcode");
            }
        }

        public string Isci
        {
            get { return this.isci; }
            set
            {
                this.isci = value;
                RaisePropertyChanged("Isci");
            }
        }

        public int Segment
        {
            get { return this.segment; }
            set
            {
                this.segment = value;
                RaisePropertyChanged("Segment");
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
            this.Barcode = "";
            this.Isci = "";
            this.Item = new TrafficItem();
            this.Length = new TimeSpan(0, 0, 0);
            this.Time = new TimeSpan(0, 0, 0);
            this.Segment = 0;
        }
    }
}

