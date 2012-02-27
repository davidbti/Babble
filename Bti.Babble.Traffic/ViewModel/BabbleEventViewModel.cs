using System;
using System.Xml;
using System.Windows.Media;
using System.ComponentModel;
using Bti.Babble.Traffic.Model;

namespace Bti.Babble.Traffic
{
    public class BabbleEventViewModel : ObservableObject
    {
        private BabbleEvent babbleEvent;
        private BabbleEventTypeViewModel babbleType;
        
        public string Body
        {
            get { return this.babbleEvent.Body; }
            set
            {
                this.babbleEvent.Body = value;
                RaisePropertyChanged("Body");
            }
        }

        public string Link
        {
            get { return this.babbleEvent.Link; }
            set
            {
                this.babbleEvent.Link = value;
                RaisePropertyChanged("Link");
            }
        }

        public BabbleEventTypeViewModel Type
        {
            get
            {
                return babbleType;
            }
            set
            {
                this.babbleType = value;
            }
        }

        public BabbleEventViewModel()
            : this(new BabbleEvent(), new BabbleEventTypeViewModel())
        {
        }

        public BabbleEventViewModel(BabbleEvent babbleEvent, BabbleEventTypeViewModel babbleType)
        {
            this.babbleEvent = babbleEvent;
            this.babbleType = babbleType;
        }
    }
}

