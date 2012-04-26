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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Bti.Babble.Metro
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PollPage : Bti.Babble.Metro.Common.LayoutAwarePage
    {
        public PollPage()
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
            var poll = (PollEvent)e.Parameter;
            this.DataContext = poll;
            if (poll.Responses.Count > 0)
            {
                ButtonA.Visibility = Windows.UI.Xaml.Visibility.Visible;
                TextA.Text = poll.Responses[0].Text;
            }
            else
            {
                ButtonA.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
            if (poll.Responses.Count > 1)
            {
                ButtonB.Visibility = Windows.UI.Xaml.Visibility.Visible;
                TextB.Text = poll.Responses[1].Text;
            }
            else
            {
                ButtonA.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
            if (poll.Responses.Count > 2)
            {
                ButtonC.Visibility = Windows.UI.Xaml.Visibility.Visible;
                TextC.Text = poll.Responses[2].Text;
            }
            else
            {
                ButtonC.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
            if (poll.Responses.Count > 3)
            {
                ButtonD.Visibility = Windows.UI.Xaml.Visibility.Visible;
                TextD.Text = poll.Responses[3].Text;
            }
            else
            {
                ButtonD.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }

        protected override void GoBack(object sender, RoutedEventArgs e)
        {
            base.GoBack(sender, e);
        }

        private void ButtonA_Click(object sender, RoutedEventArgs e)
        {
            PostPoll(sender, e);
        }

        private void ButtonB_Click(object sender, RoutedEventArgs e)
        {
            PostPoll(sender, e);
        }

        private void ButtonC_Click(object sender, RoutedEventArgs e)
        {
            PostPoll(sender, e);
        }

        private void ButtonD_Click(object sender, RoutedEventArgs e)
        {
            PostPoll(sender, e);
        }

        private void PostPoll(object sender, RoutedEventArgs e)
        {
            ContainerCanvas.Clip = new RectangleGeometry()
            {
                Rect = new Rect(0, 0, ContentGrid.RenderSize.Width, ContentGrid.RenderSize.Height)
            };
            var centerx = new DoubleAnimation()
            {
                Duration = new TimeSpan(0, 0, 0),
                To = ContentGrid.RenderSize.Width / 2,
            };
            MyStoryboard.Children.Insert(0, centerx);
            Storyboard.SetTarget(centerx, ContentCanvas);
            Storyboard.SetTargetProperty(centerx, "(Canvas.RenderTransform).(ScaleTransform.CenterX)");
            var centery = new DoubleAnimation()
            {
                Duration = new TimeSpan(0, 0, 0),
                To = ContentGrid.RenderSize.Height / 2,
            };
            MyStoryboard.Children.Insert(0, centery);
            Storyboard.SetTarget(centery, ContentCanvas);
            Storyboard.SetTargetProperty(centery, "(Canvas.RenderTransform).(ScaleTransform.CenterY)");
            MyStoryboard.Begin();
            MyStoryboard.Completed += (s, arg) =>
            {
                this.GoBack(sender, e);
            };
        }
    }
}
