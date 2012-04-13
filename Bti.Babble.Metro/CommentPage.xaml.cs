using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Xml;
using Bti.Babble.Metro.Model;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Bti.Babble.Metro
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CommentPage : Page
    {
        public CommentPage()
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
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            SendComment();
        }

        private async void SendComment()
        {
            var evt = new CommentEvent()
            {
                Id = 0,
                Image = "http://prod.bti.tv/media/users/matthew_doig.jpg",
                Message = RespondTextBox.Text,
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
