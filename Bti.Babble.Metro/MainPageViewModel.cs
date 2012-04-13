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
using Windows.Storage;

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
                                LoadEventImages(evt);
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
                                LoadEventImages(evt);
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

        private async void LoadBabbleEventImage(BabbleEvent evt)
        {
            var uri = new Uri(evt.Image);
            evt.ImageSource = LoadBitmapFromRemote(uri);
        }

        private async Task<BitmapImage> LoadBitmapFromLocal(Uri uri)
        {
            var localpath = uri.LocalPath.Split('/');
            var b = new BitmapImage();
            var m = await Windows.Storage.KnownFolders.PicturesLibrary.GetFolderAsync(localpath[1]);
            var c = await m.GetFolderAsync(localpath[2]);
            var i = await c.GetFileAsync(localpath[3]);
            b.SetSource(await i.OpenAsync(FileAccessMode.Read));
            return b;
        }

        private BitmapImage LoadBitmapFromRemote(Uri uri)
        {
            return new BitmapImage(uri);
        }

        private void LoadEventImages(BabbleEvent evt)
        {
            var story = evt as StoryEvent;
            if (story != null) { LoadStoryEventImage(story); }
            var info = evt as InfoEvent;
            if (info != null) { LoadInfoEventImage(info); }
            var poll = evt as PollEvent;
            if (poll != null) { LoadPollEventImage(poll); }
            LoadBabbleEventImage(evt);
        }

        private async void LoadInfoEventImage(InfoEvent evt)
        {
            var uri = new Uri(evt.InfoImage);
            evt.InfoImageSource = await LoadBitmapFromLocal(uri);
        }

        private async void LoadPollEventImage(PollEvent evt)
        {
            switch (evt.Question.ToLower())
            {
                case "would you adopt a child with a heart condition?":
                    var uri1 = new Uri("http://prod.bti.tv/media/content/poll_heart.png");
                    evt.PollImageSource = await LoadBitmapFromLocal(uri1);
                    break;
                case "is middle tennessee a good place to raise an adopted child?":
                    var uri2 = new Uri("http://prod.bti.tv/media/content/poll_adopt.png");
                    evt.PollImageSource = await LoadBitmapFromLocal(uri2);
                    break;
                case "have you been enjoying these warmer than usual days?":
                    var uri3 = new Uri("http://prod.bti.tv/media/content/poll_weather.png");
                    evt.PollImageSource = await LoadBitmapFromLocal(uri3);
                    break;
            }
        }

        private async void LoadStoryEventImage(StoryEvent evt)
        {
            var uri = new Uri(evt.StoryImage);
            evt.StoryImageSource = await LoadBitmapFromLocal(uri);
        }
    }
}
