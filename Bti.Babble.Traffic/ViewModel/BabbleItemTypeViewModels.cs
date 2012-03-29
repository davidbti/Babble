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
            var infoName = Enum.GetName(typeof(BabbleItemType), BabbleItemType.Info);
            var infoUri = @"pack://application:,,,/Bti.Babble.Traffic;component/Images/info.png";
            var infoImage = new ImageSourceConverter().ConvertFromString(infoUri) as ImageSource;
            Items.Add(new BabbleItemTypeViewModel(infoName, infoImage));
            var pollName = Enum.GetName(typeof(BabbleItemType), BabbleItemType.Poll);
            var pollUri = @"pack://application:,,,/Bti.Babble.Traffic;component/Images/poll.png";
            var pollImage = new ImageSourceConverter().ConvertFromString(pollUri) as ImageSource;
            Items.Add(new BabbleItemTypeViewModel(pollName, pollImage));
            var rssName = Enum.GetName(typeof(BabbleItemType), BabbleItemType.Rss);
            var rssUri = @"pack://application:,,,/Bti.Babble.Traffic;component/Images/rss.png";
            var rssImage = new ImageSourceConverter().ConvertFromString(rssUri) as ImageSource;
            Items.Add(new BabbleItemTypeViewModel(rssName, rssImage));
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
