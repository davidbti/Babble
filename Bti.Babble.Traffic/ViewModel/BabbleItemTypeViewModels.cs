using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Media;
using Bti.Babble.Traffic.Model;

namespace Bti.Babble.Traffic
{
    public class BabbleItemTypeViewModels : ObservableCollection<BabbleItemTypeViewModel>
    {
        public BabbleItemTypeViewModels()
        {
            var noneName = Enum.GetName(typeof(BabbleItemType), BabbleItemType.None);
            var noneUri = @"pack://application:,,,/Bti.Babble.Traffic;component/Images/none.png";
            var noneImage = new ImageSourceConverter().ConvertFromString(noneUri) as ImageSource;
            Items.Add(new BabbleItemTypeViewModel(noneName, noneImage));
            var commentName = Enum.GetName(typeof(BabbleItemType), BabbleItemType.Comment);
            var commentUri = @"pack://application:,,,/Bti.Babble.Traffic;component/Images/comment.png";
            var commentImage = new ImageSourceConverter().ConvertFromString(commentUri) as ImageSource;
            Items.Add(new BabbleItemTypeViewModel(commentName, commentImage));
            var facebookName = Enum.GetName(typeof(BabbleItemType), BabbleItemType.Facebook);
            var facebookUri = @"pack://application:,,,/Bti.Babble.Traffic;component/Images/facebook.png";
            var facebookImage = new ImageSourceConverter().ConvertFromString(facebookUri) as ImageSource;
            Items.Add(new BabbleItemTypeViewModel(facebookName, facebookImage));
            var pollName = Enum.GetName(typeof(BabbleItemType), BabbleItemType.Poll);
            var pollUri = @"pack://application:,,,/Bti.Babble.Traffic;component/Images/poll.png";
            var pollImage = new ImageSourceConverter().ConvertFromString(pollUri) as ImageSource;
            Items.Add(new BabbleItemTypeViewModel(pollName, pollImage));
            var ratingName = Enum.GetName(typeof(BabbleItemType), BabbleItemType.Rating);
            var ratingUri = @"pack://application:,,,/Bti.Babble.Traffic;component/Images/rating.png";
            var ratingImage = new ImageSourceConverter().ConvertFromString(ratingUri) as ImageSource;
            Items.Add(new BabbleItemTypeViewModel(ratingName, ratingImage));
            var rssName = Enum.GetName(typeof(BabbleItemType), BabbleItemType.Rss);
            var rssUri = @"pack://application:,,,/Bti.Babble.Traffic;component/Images/rss.png";
            var rssImage = new ImageSourceConverter().ConvertFromString(rssUri) as ImageSource;
            Items.Add(new BabbleItemTypeViewModel(rssName, rssImage));
            var teaseName = Enum.GetName(typeof(BabbleItemType), BabbleItemType.Tease);
            var teaseUri = @"pack://application:,,,/Bti.Babble.Traffic;component/Images/tease.png";
            var teaseImage = new ImageSourceConverter().ConvertFromString(teaseUri) as ImageSource;
            Items.Add(new BabbleItemTypeViewModel(teaseName, teaseImage));
            var twitterName = Enum.GetName(typeof(BabbleItemType), BabbleItemType.Twitter);
            var twitterUri = @"pack://application:,,,/Bti.Babble.Traffic;component/Images/twitter.png";
            var twitterImage = new ImageSourceConverter().ConvertFromString(twitterUri) as ImageSource;
            Items.Add(new BabbleItemTypeViewModel(twitterName, twitterImage));
        }

        public BabbleItemTypeViewModel GetImageForType(BabbleItemType type)
        {
            return Items[(int)type];
        }
    }
}
