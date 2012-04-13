using Bti.Babble.Dashboard.Data;

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
using Bti.Babble.Dashboard.Model;
using System.Xml;
using System.Text;
using System.Net.Http;

// The Item Detail Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234232

namespace Bti.Babble.Dashboard
{
    /// <summary>
    /// A page that displays details for a single item within a group while allowing gestures to
    /// flip through other items belonging to the same group.
    /// </summary>
    public sealed partial class ItemDetailPage : Bti.Babble.Dashboard.Common.LayoutAwarePage
    {
        public ItemDetailPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property provides the initial item to be displayed.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var item = (SampleDataItem)e.Parameter;
            this.DefaultViewModel["Group"] = item.Group;
            this.DefaultViewModel["Items"] = item.Group.Items;
            item.LoadBabbleEvents();
            ItemGridView.ItemsSource = item.BabbleEvents;
        }

        protected override void GoBack(object sender, RoutedEventArgs e)
        {
            foreach (BabbleEvent item in ItemGridView.SelectedItems)
            {
                SendComment(item);
            }
            base.GoBack(sender, e);
        }

        private async void SendComment(BabbleEvent evt)
        {
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
