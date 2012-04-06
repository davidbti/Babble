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
        
        public ObservableCollection<BabbleEvent> BabbleEvents
        {
            get { return this.events; }
            set
            {
                this.events = value;
                OnPropertyChanged("BabbleEvents");
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
                                LoadBabbleEventImageSimple(evt);
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
                                LoadBabbleEventImageSimple(evt);
                                BabbleEvents.Insert(0, evt);
                                BabbleEvents.RemoveAt(BabbleEvents.Count - 1);
                            }
                        }
                    }
                }
                LoadBabbleEventsSince();
            }
        }

        private void LoadBabbleEventImageSimple(BabbleEvent evt)
        {
            var uri = new Uri(evt.Image);
            evt.ImageSource = new BitmapImage(uri);
        }

        private async void LoadBabbleEventImage(BabbleEvent evt)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(evt.Image);
            if (response.IsSuccessStatusCode)
            {
                var ras = new InMemoryRandomAccessStream();
                using (var stream = response.Content.ReadAsStreamAsync().Result)
                {
                    await stream.CopyToAsync(ras.AsStreamForWrite());
                }
                var bmp = new BitmapImage();
                bmp.SetSource(ras);
                evt.ImageSource = bmp;
            }
        }
    }
}
