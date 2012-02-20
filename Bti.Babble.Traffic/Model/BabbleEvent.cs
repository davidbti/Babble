using System;
using System.Xml;

namespace Bti.Babble.Traffic
{
    public class BabbleEvent : ObservableObject
    {
        private string body;
        private BabbleEventClassification classification;
        private string link;
        private string name;

        public string Body
        {
            get { return this.body; }
            set
            {
                this.body = value;
                RaisePropertyChanged("Body");
            }
        }

        public BabbleEventClassification Classification
        {
            get { return this.classification; }
            set
            {
                this.classification = value;
                RaisePropertyChanged("Classification");
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

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                RaisePropertyChanged("Name");
            }
        }
    }
}

