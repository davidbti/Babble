using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Media;
using Bti.Babble.Traffic.Model;

namespace Bti.Babble.Traffic
{
    public class BabbleEventTypeViewModels : ObservableCollection<BabbleEventTypeViewModel>
    {
        public BabbleEventTypeViewModels()
        {
            var noneName = Enum.GetName(typeof(BabbleEventType), BabbleEventType.None);
            var noneUri = @"pack://application:,,,/Bti.Babble.Traffic;component/Images/none.png";
            var noneImage = new ImageSourceConverter().ConvertFromString(noneUri) as ImageSource;
            Items.Add(new BabbleEventTypeViewModel(noneName, noneImage));
            var commentName = Enum.GetName(typeof(BabbleEventType), BabbleEventType.Comment);
            var commentUri = @"pack://application:,,,/Bti.Babble.Traffic;component/Images/comment.png";
            var commentImage = new ImageSourceConverter().ConvertFromString(commentUri) as ImageSource;
            Items.Add(new BabbleEventTypeViewModel(commentName, commentImage));
            var facebookName = Enum.GetName(typeof(BabbleEventType), BabbleEventType.Facebook);
            var facebookUri = @"pack://application:,,,/Bti.Babble.Traffic;component/Images/facebook.png";
            var facebookImage = new ImageSourceConverter().ConvertFromString(facebookUri) as ImageSource;
            Items.Add(new BabbleEventTypeViewModel(facebookName, facebookImage));
            var pollName = Enum.GetName(typeof(BabbleEventType), BabbleEventType.Poll);
            var pollUri = @"pack://application:,,,/Bti.Babble.Traffic;component/Images/poll.png";
            var pollImage = new ImageSourceConverter().ConvertFromString(pollUri) as ImageSource;
            Items.Add(new BabbleEventTypeViewModel(pollName, pollImage));
            var ratingName = Enum.GetName(typeof(BabbleEventType), BabbleEventType.Rating);
            var ratingUri = @"pack://application:,,,/Bti.Babble.Traffic;component/Images/rating.png";
            var ratingImage = new ImageSourceConverter().ConvertFromString(ratingUri) as ImageSource;
            Items.Add(new BabbleEventTypeViewModel(ratingName, ratingImage));
            var rssName = Enum.GetName(typeof(BabbleEventType), BabbleEventType.Rss);
            var rssUri = @"pack://application:,,,/Bti.Babble.Traffic;component/Images/rss.png";
            var rssImage = new ImageSourceConverter().ConvertFromString(rssUri) as ImageSource;
            Items.Add(new BabbleEventTypeViewModel(rssName, rssImage));
            var teaseName = Enum.GetName(typeof(BabbleEventType), BabbleEventType.Tease);
            var teaseUri = @"pack://application:,,,/Bti.Babble.Traffic;component/Images/tease.png";
            var teaseImage = new ImageSourceConverter().ConvertFromString(teaseUri) as ImageSource;
            Items.Add(new BabbleEventTypeViewModel(teaseName, teaseImage));
            var twitterName = Enum.GetName(typeof(BabbleEventType), BabbleEventType.Twitter);
            var twitterUri = @"pack://application:,,,/Bti.Babble.Traffic;component/Images/twitter.png";
            var twitterImage = new ImageSourceConverter().ConvertFromString(twitterUri) as ImageSource;
            Items.Add(new BabbleEventTypeViewModel(twitterName, twitterImage));
        }

        public BabbleEventTypeViewModel GetImageForType(BabbleEventType type)
        {
            return Items[(int)type];
        }
    }
}
