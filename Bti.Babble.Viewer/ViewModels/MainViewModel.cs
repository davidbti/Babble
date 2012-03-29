using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;


namespace Bti.Babble.Viewer
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            // Sample data; replace with real data
            var uri1 = @"Images/TPBGirl2011.jpg";
            var image1 = new ImageSourceConverter().ConvertFromString(uri1) as ImageSource;
            this.Items.Add(new ItemViewModel() { User = "TPBGirl2011", Message = "@drhoagie @wkrn Scary part is, the people who search you at the airport may be meth addicts or have the chemicals on them. Not good. #TSA", Image = image1 });
            var uri2 = @"Images/news2.jpg";
            var image2 = new ImageSourceConverter().ConvertFromString(uri2) as ImageSource;
            this.Items.Add(new ItemViewModel() { User = "Local News Alert", Message = "Mystery surrounds man's disappearance in Smokies", Image = image2 });
            var uri3 = @"Images/poll.png";
            var image3 = new ImageSourceConverter().ConvertFromString(uri3) as ImageSource;
            this.Items.Add(new ItemViewModel() { User = "Let Us Know What You Think", Message = "Should TSA agents be required to have a college degree in law enforcement?", Image = image3 });
            var uri4 = @"Images/otters.jpg";
            var image4 = new ImageSourceConverter().ConvertFromString(uri4) as ImageSource;
            this.Items.Add(new ItemViewModel() { User = "Deal Alert", Message = "Get 2$ off you next chicken finger basket from otters", Image = image4 });
            var uri5 = @"Images/TonyKemp6.jpg";
            var image5 = new ImageSourceConverter().ConvertFromString(uri5) as ImageSource;
            this.Items.Add(new ItemViewModel() { User = "TonyKemp6", Message = "Wonder what the author of this @WKRN piece was thinking:  http://t.co/ivB7drgj | Who is State Rep. Gary Sodom...? #TNLeg", Image = image5 });
            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}