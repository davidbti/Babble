using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Bti.Babble.Model;
using TweetSharp;

namespace Bti.Babble.Service
{
    class TwitterRequest
    {
        private string query;
        private int resultsPerPage;
        
        public TwitterRequest(int resultsPerPage, string query)
        {
            this.resultsPerPage = resultsPerPage;
            this.query = query;
        }

        public IEnumerable<CommentEvent> Download()
        {
            try
            {
                return DownloadSearchPhrase();
            }
            catch (WebException ex)
            {
                return new List<CommentEvent>();
            }
        }

        private IEnumerable<CommentEvent> DownloadSearchPhrase()
        {
            var items = new List<CommentEvent>();

            var service = new TwitterService(); 
            var results = service.Search(this.query, this.resultsPerPage);
            foreach (TwitterStatus tweet in results.Statuses)
            {
                var item = new CommentEvent()
                {
                    Id = 0,
                    Image = tweet.User.ProfileImageUrl,
                    Message = System.Web.HttpUtility.HtmlDecode(tweet.Text).Trim(),
                    PubDate = tweet.CreatedDate,
                    Type = "comment",
                    User = tweet.User.ScreenName
                };
                items.Add(item);
            }
            return items.OrderBy(f => f.PubDate);
        }
    }
}
