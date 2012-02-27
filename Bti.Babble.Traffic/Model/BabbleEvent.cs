using System;

namespace Bti.Babble.Traffic.Model
{
    public class BabbleEvent : ObservableObject
    {
        private string body;
        private BabbleEventType type;
        private string link;

        public string Body
        {
            get { return this.body; }
            set
            {
                this.body = value;
                RaisePropertyChanged("Body");
            }
        }

        public BabbleEventType Type
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

        public BabbleEvent()
        {
            this.Body = "";
            this.Link = "";
            this.Type = BabbleEventType.None;
        }
    }
}

