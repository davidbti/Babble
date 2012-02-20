using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Bti.Babble.Traffic
{
    public class BabbleEventClassificationImages
    {
        private Dictionary<BabbleEventClassification, ImageSource> images;

        public Dictionary<BabbleEventClassification, ImageSource> Images
        {
            get
            {
                return this.images;
            }
        }

        public BabbleEventClassificationImages()
        {
            images = new Dictionary<BabbleEventClassification, ImageSource>();
            var commentUri = @"pack://application:,,,/Bti.Babble.Traffic;component/Images/comment.png";
            images.Add(BabbleEventClassification.Comment, new ImageSourceConverter().ConvertFromString(commentUri) as ImageSource);
            var pollUri = @"pack://application:,,,/Bti.Babble.Traffic;component/Images/poll.png";
            images.Add(BabbleEventClassification.Poll, new ImageSourceConverter().ConvertFromString(pollUri) as ImageSource);
            var ratingUri = @"pack://application:,,,/Bti.Babble.Traffic;component/Images/rating.png";
            images.Add(BabbleEventClassification.Rating, new ImageSourceConverter().ConvertFromString(ratingUri) as ImageSource);
            var rssUri = @"pack://application:,,,/Bti.Babble.Traffic;component/Images/rss.png";
            images.Add(BabbleEventClassification.Rss, new ImageSourceConverter().ConvertFromString(rssUri) as ImageSource);
            var teaseUri = @"pack://application:,,,/Bti.Babble.Traffic;component/Images/tease.png";
            images.Add(BabbleEventClassification.Tease, new ImageSourceConverter().ConvertFromString(teaseUri) as ImageSource);
            var twitterUri = @"pack://application:,,,/Bti.Babble.Traffic;component/Images/twitter.png";
            images.Add(BabbleEventClassification.Twitter, new ImageSourceConverter().ConvertFromString(twitterUri) as ImageSource);
        }
    }
}
