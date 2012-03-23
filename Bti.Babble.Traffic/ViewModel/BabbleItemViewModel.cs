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
            get { return this.babbleItem.Message; }
            set
            {
                this.babbleItem.Message = value;
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
                this.babbleItem.Type = (BabbleItemType)Enum.Parse(typeof(BabbleItemType), this.babbleType.Name);
                RaisePropertyChanged("Type");
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

        public BabbleItem ToBabbleItem()
        {
            return this.babbleItem;
        }
    }
}

