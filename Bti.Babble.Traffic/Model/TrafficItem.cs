using System;
using System.Collections.Generic;
using System.Xml;
using System.Collections.ObjectModel;

namespace Bti.Babble.Traffic.Model
{
    public class TrafficItem : ObservableObject
    {
        private int id;
        private string description;
        private string description2;
        private TrafficItemType type;
        private ObservableCollection<BabbleItem> babbleItems;

        public int Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
                RaisePropertyChanged("Id");
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

        public string Description2
        {
            get { return this.description2; }
            set
            {
                this.description2 = value;
                RaisePropertyChanged("Description2");
            }
        }

        public TrafficItemType Type
        {
            get { return this.type; }
            set
            {
                this.type = value;
                RaisePropertyChanged("Type");
            }
        }

        public ObservableCollection<BabbleItem> BabbleItems
        {
            get { return this.babbleItems; }
            set
            {
                this.babbleItems = value;
                RaisePropertyChanged("BabbleItems");
            }
        }

        public TrafficItem()
        {
            this.Id = 0;
            this.Description = "";
            this.Description2 = "";
            this.Type = TrafficItemType.None;
            this.BabbleItems = new ObservableCollection<BabbleItem>();
        }
    }
}

