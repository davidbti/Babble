using System;
using System.Xml;
using System.Windows.Media;
using System.ComponentModel;
using Bti.Babble.Traffic.Model;

namespace Bti.Babble.Traffic
{
    public class BabbleItemViewModel : ObservableObject
    {
        private BabbleItem babbleItem;
        private BabbleItemTypeViewModel babbleType;
        
        public string Body
        {
            get { return this.babbleItem.Body; }
            set
            {
                this.babbleItem.Body = value;
                RaisePropertyChanged("Body");
            }
        }

        public string Link
        {
            get { return this.babbleItem.Link; }
            set
            {
                this.babbleItem.Link = value;
                RaisePropertyChanged("Link");
            }
        }

        public BabbleItemTypeViewModel Type
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

        public BabbleItemViewModel()
            : this(new BabbleItem(), new BabbleItemTypeViewModel())
        {
        }

        public BabbleItemViewModel(BabbleItem babbleEvent, BabbleItemTypeViewModel babbleType)
        {
            this.babbleItem = babbleEvent;
            this.babbleType = babbleType;
        }
    }
}

