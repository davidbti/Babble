using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Bti.Babble.Metro.Common;
using Bti.Babble.Metro.Model;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.System.Threading;
using Windows.UI.Core;

namespace Bti.Babble.Metro
{
    class MainPageViewModel : BindableBase 
    {
        private ObservableCollection<BabbleEvent> events;
        private BabbleEvent selectedEvent;
        
        public ObservableCollection<BabbleEvent> BabbleEvents
        {
            get { return this.events; }
            set
            {
                this.events = value;
                OnPropertyChanged("BabbleEvents");
            }
        }

        public BabbleEvent SelectedEvent
        {
            get { return this.selectedEvent; }
            set
            {
                this.selectedEvent = value;
                OnPropertyChanged("SelectedEvent");
            }
        }

        public MainPageViewModel()
        {
            LoadBabbleEvents();
        }

        private async void LoadBabbleEvents()
        {
            this.BabbleEvents = new ObservableCollection<BabbleEvent>();
            var client = new HttpClient();
            var response = await client.GetAsync("http://prod.bti.tv/babble/service.svc/xml/babble/amit");
            if (response.IsSuccessStatusCode)
            {
                using (var stream = response.Content.ReadAsStreamAsync().Result)
                {
                    using (var reader = XmlReader.Create(stream))
                    {
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "event")
                            {
                                var evt = BabbleEvent.CreateFromXmlReader(reader);
                                LoadBabbleEventImage(evt);
                                BabbleEvents.Add(evt);
                            }
                        }
                    }
                }
                LoadBabbleEventsSince();
            }
        }

        private async void LoadBabbleEventsSince()
        {
            var lastEvent = BabbleEvents[0];
            var client = new HttpClient();
            var response = await client.GetAsync("http://prod.bti.tv/babble/service.svc/xml/babble/amit/" + lastEvent.Id.ToString());
            if (response.IsSuccessStatusCode)
            {
                using (var stream = response.Content.ReadAsStreamAsync().Result)
                {
                    using (var reader = XmlReader.Create(stream))
                    {
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "event")
                            {
                                var evt = BabbleEvent.CreateFromXmlReader(reader);
                                var story = evt as StoryEvent;
                                if (story != null) { LoadStoryEventImage(story); } 
                                LoadBabbleEventImage(evt);
                                BabbleEvents.Insert(0, evt);
                                BabbleEvents.RemoveAt(BabbleEvents.Count - 1);
                                SelectedEvent = evt;
                            }
                        }
                    }
                }
                LoadBabbleEventsSince();
            }
        }

        private void LoadBabbleEventImage(BabbleEvent evt)
        {
            var uri = new Uri(evt.Image);
            evt.ImageSource = new BitmapImage(uri);
        }

        private void LoadStoryEventImage(StoryEvent evt)
        {
            var uri = new Uri(evt.StoryImage);
            evt.StoryImageSource = new BitmapImage(uri);
        }
    }
}
