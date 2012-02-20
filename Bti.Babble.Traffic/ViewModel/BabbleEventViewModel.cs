using System;
using System.Xml;
using System.Windows.Media;

namespace Bti.Babble.Traffic
{
    public class BabbleEventViewModel : ObservableObject
    {
        private BabbleEvent babbleEvent;
        private ImageSource imageSource;
        
        public string Body
        {
            get { return this.babbleEvent.Body; }
            set
            {
                this.babbleEvent.Body = value;
                RaisePropertyChanged("Body");
            }
        }

        public BabbleEventClassification Classification
        {
            get { return this.babbleEvent.Classification; }
            set
            {
                this.babbleEvent.Classification = value;
                RaisePropertyChanged("Classification");
            }
        }

        public ImageSource ClassificationImage
        {
            get 
            {
                return imageSource; 
            }
        }

        public string ClassificationName
        {
            get
            {
                return Enum.GetName(typeof(BabbleEventClassification), Classification);
            }
            set
            {
                Classification = (BabbleEventClassification)Enum.Parse(typeof(BabbleEventClassification), value);
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

        public string Name
        {
            get { return this.babbleEvent.Name; }
            set
            {
                this.babbleEvent.Name = value;
                RaisePropertyChanged("Name");
            }
        }

        public BabbleEventViewModel(BabbleEvent babbleEvent, BabbleEventClassificationImages images)
        {
            this.babbleEvent = babbleEvent;
            this.imageSource = images.Images[babbleEvent.Classification];
        }
    }
}

