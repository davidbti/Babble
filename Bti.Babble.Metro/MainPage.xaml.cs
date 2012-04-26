using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Bti.Babble.Metro.Model;
using System.Xml;
using System.Text;
using System.Net.Http;
using Windows.UI.Xaml.Media.Animation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Bti.Babble.Metro
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            BodyFrame.Navigate(typeof(SharePage), this.DataContext);
        }

        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var story = e.ClickedItem as StoryEvent;
            if (story != null)
            {
                this.Frame.Navigate(typeof(StoryPage), story);
            }
        }

        void Header_Click(object sender, RoutedEventArgs e)
        {
        }

        private void PostButton_Click(object sender, RoutedEventArgs e)
        {
            SendComment();
            CommentTextBox.Text = "";
        }

        private async void SendComment()
        {
            var evt = new CommentEvent()
            {
                Id = 0,
                Image = "http://prod.bti.tv/media/users/matthew_doig.jpg",
                Large = "",
                Message = CommentTextBox.Text,
                PubDate = DateTime.Now,
                Time = new TimeSpan(0, 0, 0),
                Type = "comment",
                User = "Matthew Doig"
            };
            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            var sb = new StringBuilder();
            using (var writer = XmlWriter.Create(sb, settings))
            {
                writer.WriteStartElement("babble");
                evt.WriteXml(writer);
                writer.WriteEndElement();
            }
            var client = new HttpClient();
            var url = "http://prod.bti.tv/babble/Service.svc/xml/babble";
            var response = await client.PostAsync(url, new StringContent(sb.ToString(), System.Text.Encoding.UTF8, "application/xml"));
        }
    }
}
