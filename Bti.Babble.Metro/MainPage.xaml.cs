﻿using System;
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
        }

        private void ItemListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var info = e.AddedItems[0] as InfoEvent;
                if (info != null)
                {
                    BodyFrame.DataContext = info;
                    BodyFrame.Navigate(typeof(InfoPage));
                }
                var coupon = e.AddedItems[0] as CouponEvent;
                if (coupon != null)
                {
                    BodyFrame.DataContext = coupon;
                    BodyFrame.Navigate(typeof(CouponPage));
                }
                var comment = e.AddedItems[0] as CommentEvent;
                if (comment != null)
                {
                    BodyFrame.DataContext = comment;
                    BodyFrame.Navigate(typeof(CommentPage));
                }
                var poll = e.AddedItems[0] as PollEvent;
                if (poll != null)
                {
                    BodyFrame.DataContext = poll;
                    BodyFrame.Navigate(typeof(PollPage));
                }
            }
        }
    }
}