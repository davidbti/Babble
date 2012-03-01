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
        private string description;
        private TrafficEventType type;
        private string barcode;
        private string isci;
        private ObservableCollection<BabbleEvent> babbleEvents;

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

        public string Isci
        {
            get { return this.isci; }
            set
            {
                this.isci = value;
                RaisePropertyChanged("Isci");
            }
        }

        public ObservableCollection<BabbleEvent> BabbleEvents
        {
            get { return this.babbleEvents; }
            set
            {
                this.babbleEvents = value;
                RaisePropertyChanged("BabbleEvents");
            }
        }

        public TrafficEvent()
        {
            this.Id = 0;
            this.Barcode = "";
            this.Description = "";
            this.Isci = "";
            this.Length = new TimeSpan(0, 0, 0);
            this.Time = new TimeSpan(0, 0, 0);
            this.Type = TrafficEventType.None;
            this.BabbleEvents = new ObservableCollection<BabbleEvent>();
        }
    }
}

