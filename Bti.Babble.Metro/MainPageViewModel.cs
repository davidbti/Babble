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
        private ObservableCollection<BabbleEvent> commentEvents;
        private BabbleEvent lastEvent;
        private ShareEventCollection shareEvents;
        private BabbleEvent selectedEvent;

        public ObservableCollection<BabbleEvent> CommentEvents
        {
            get { return this.commentEvents; }
            set
            {
                this.commentEvents = value;
                OnPropertyChanged("CommentEvents");
            }
        }

        public ShareEventCollection ShareEvents
        {
            get { return this.shareEvents; }
            set
            {
                this.shareEvents = value;
                OnPropertyChanged("ShareEvents");
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
            this.CommentEvents = new ObservableCollection<BabbleEvent>();
            this.ShareEvents = new ShareEventCollection()
            {
                LiveCount = 9,
                StoryCount = 5,
                PollCount = 3,
                CouponCount = 6
            };
            var client = new HttpClient();
            var uri = "http://prod.bti.tv/babble/service.svc/xml/babble?viewer=amit&" +
                                                 "comment=10&" +
                                                 "story=" + ShareEvents.StoryCount + "&" +
                                                 "poll=" + ShareEvents.PollCount + "&" +
                                                 "coupon=" + ShareEvents.CouponCount;
            var response = await client.GetAsync(uri);
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
                                if (evt.Type == "comment")
                                {
                                    CommentEvents.Add(evt);
                                }
                                else
                                {
                                    ShareEvents.AddEvent(evt);
                                }
                                this.lastEvent = evt;
                            }
                        }
                    }
                }
                LoadBabbleEventsSince();
            }
        }

        private async void LoadBabbleEventsSince()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://prod.bti.tv/babble/service.svc/xml/babble/amit/" + this.lastEvent.Id.ToString());
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
                                if (evt.Type == "comment")
                                {
                                    if (CommentEvents.Count >= 10)
                                    {
                                        CommentEvents.Insert(0, evt);
                                        CommentEvents.RemoveAt(CommentEvents.Count - 1);
                                    }
                                    else
                                    {
                                        CommentEvents.Insert(0, evt);
                                    }
                                }
                                else
                                {
                                    ShareEvents.AddEvent(evt);
                                }
                                this.lastEvent = evt;
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

        private void LoadInfoEventImage(InfoEvent evt)
        {
            var uri = new Uri(evt.InfoImage);
            evt.InfoImageSource = LoadBitmapFromRemote(uri);
        }

        private void LoadPollEventImage(PollEvent evt)
        {
            var uri = new Uri(evt.PollImage);
            evt.PollImageSource = LoadBitmapFromRemote(uri);
        }

        private void LoadStoryEventImage(StoryEvent evt)
        {
            var uri = new Uri(evt.StoryImage);
            evt.StoryImageSource = LoadBitmapFromRemote(uri);
        }
    }
}
