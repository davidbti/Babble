using System;
using System.Collections.Generic;
using System.Xml;
using System.Collections.ObjectModel;

namespace Bti.Babble.Traffic.Model
{
    public class TrafficEvent : ObservableObject
    {
        private int id;
        private int trafficLogId;
        private string advertiser;
        private string barcode;
        private TrafficItem item;
        private string isci;
        private TimeSpan length;
        private int programNumber;
        private int segmentNumber;
        private TimeSpan time;
                
        public int Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
                RaisePropertyChanged("Id");
            }
        }

        public int TrafficLogId
        {
            get { return this.trafficLogId; }
            set
            {
                this.trafficLogId = value;
                RaisePropertyChanged("TrafficLogId");
            }
        }

        public string Advertiser
        {
            get { return this.advertiser; }
            set
            {
                this.advertiser = value;
                RaisePropertyChanged("Advertiser");
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

        public TrafficItem Item
        {
            get { return this.item; }
            set
            {
                this.item = value;
                RaisePropertyChanged("Item");
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

        public TimeSpan Length
        {
            get { return this.length; }
            set
            {
                this.length = value;
                RaisePropertyChanged("Length");
            }
        }

        public int ProgramNumber
        {
            get { return this.programNumber; }
            set
            {
                this.programNumber = value;
                RaisePropertyChanged("ProgramNumber");
            }
        }
        
        public int SegmentNumber
        {
            get { return this.segmentNumber; }
            set
            {
                this.segmentNumber = value;
                RaisePropertyChanged("SegmentNumber");
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
        
        public TrafficEvent()
        {
            this.Id = 0;
            this.TrafficLogId = 0;
            this.Advertiser = "";
            this.Barcode = "";
            this.Isci = "";
            this.ProgramNumber = 0;
            this.Item = new TrafficItem();
            this.Length = new TimeSpan(0, 0, 0);
            this.SegmentNumber = 0;
            this.Time = new TimeSpan(0, 0, 0);
        }
    }
}

