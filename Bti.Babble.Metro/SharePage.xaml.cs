using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bti.Babble.Metro.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Bti.Babble.Metro
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SharePage : Page
    {
        private int horizontalPostion;
        public SharePage()
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
            var viewmodel = (MainPageViewModel)e.Parameter;
            this.DataContext = viewmodel;
        }

        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var story = e.ClickedItem as StoryEvent;
            if (story != null)
            {
                this.Frame.Navigate(typeof(StoryPage), story);
            }
            var coupon = e.ClickedItem as CouponEvent;
            if (coupon != null)
            {
                this.Frame.Navigate(typeof(CouponPage), coupon);
            }
            var poll = e.ClickedItem as PollEvent;
            if (poll != null)
            {
                this.Frame.Navigate(typeof(PollPage), poll);
            }
            var info = e.ClickedItem as InfoEvent;
            if (info != null)
            {
                this.Frame.Navigate(typeof(InfoPage), info);
            }
        }

        void Header_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
