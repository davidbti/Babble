using System;

namespace Bti.Babble.Traffic.Model
{
    public class BabbleItem : ObservableObject
    {
        private int id;
        private int trafficItemId;
        private string body;
        private BabbleItemType type;
        private string link;

        public int Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
                RaisePropertyChanged("Id");
            }
        }

        public int TrafficItemId
        {
            get { return this.trafficItemId; }
            set
            {
                this.trafficItemId = value;
                RaisePropertyChanged("TrafficItemId");
            }
        }

        public string Body
        {
            get { return this.body; }
            set
            {
                this.body = value;
                RaisePropertyChanged("Body");
            }
        }

        public BabbleItemType Type
        {
            get { return this.type; }
            set
            {
                this.type = value;
                RaisePropertyChanged("Type");
            }
        }

        public string Link
        {
            get { return this.link; }
            set
            {
                this.link = value;
                RaisePropertyChanged("Link");
            }
        }

        public BabbleItem()
        {
            this.Body = "";
            this.Link = "";
            this.Type = BabbleItemType.None;
        }
    }
}

