using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using Bti.Databridge.Feeds.Domain;

namespace Bti.Databridge.RestService
{
    public class NewsUpdateService : INewsUpdateService
    {
        private List<Customer> GetCustomers(string user)
        {
            var service = Global.container.Resolve<ICustomerService>();
            var customer = service.GetCustomerForUserId(user);
            if (customer == null)
            {
                throw new FaultException("customer not found id:" + user);
            }
            var dto = new Customer()
            {
                Id = customer.Id,
                UserId = customer.UserId
            };
            var customers = new List<Customer>();
            customers.Add(dto);
            return customers;
        }

        public List<Customer> GetCustomersAsXml(string user)
        {
            return GetCustomers(user);
        }

        public List<Customer> GetCustomersAsJson(string user)
        {
            return GetCustomers(user);
        }

        private List<NewsType> GetNewsTypes(string customerId)
        {
            var customer = new Feeds.Domain.Customer();
            customer.Id = int.Parse(customerId);
            var ctService = Global.container.Resolve<ICustomerTypeService>();
            var ntService = Global.container.Resolve<INewsTypeService>();
            var newsTypes = new List<NewsType>();
            ctService.RemoveMessagesForCustomer(customer);
            foreach (var ct in ctService.GetCustomerTypesForCustomer(customer))
            {
                var nt = NewsType.FromCustomerTypeObject(ct);
                newsTypes.Add(nt);
            }
            return newsTypes;
        }

        public List<NewsType> GetNewsTypesAsXml(string customerId)
        {
            return GetNewsTypes(customerId);
        }

        public List<NewsType> GetNewsTypesAsJson(string customerId)
        {
            return GetNewsTypes(customerId);
        }

        private List<NewsType> GetNewsTypesSince(string customerId, string id)
        {
            var customer = new Feeds.Domain.Customer();
            customer.Id = int.Parse(customerId);
            var ctService = Global.container.Resolve<ICustomerTypeService>();
            var ntService = Global.container.Resolve<INewsTypeService>();
            var newsTypes = new List<NewsType>();
            var batch = ctService.GetMessagesForCustomerSince(customer, Int32.Parse(id));
            foreach (var ctm in batch.GetLatestMessages())
            {
                var ct = ctService.GetCustomerType(ctm.CustomerTypeId);
                if (ct == null)
                {
                    var nt = NewsType.FromCustomerTypeMessageObject(ctm);
                    newsTypes.Add(nt);
                }
                else
                {
                    var nt = NewsType.FromCustomerTypeMessageAndCustomerTypeObject(ctm, ct);
                    newsTypes.Add(nt);
                }
            }
            return newsTypes;
        }

        public List<NewsType> GetNewsTypesSinceAsXml(string customerId, string id)
        {
            return GetNewsTypesSince(customerId, id);
        }

        public List<NewsType> GetNewsTypesSinceAsJson(string customerId, string id)
        {
            return GetNewsTypesSince(customerId, id);
        }

        private List<NewsFeed> GetNewsFeeds(string customerId)
        {
            var customer = new Feeds.Domain.Customer();
            customer.Id = int.Parse(customerId);
            var nfService = Global.container.Resolve<ICustomerFeedService>();
            var newsFeeds = new List<NewsFeed>();
            foreach (var feed in nfService.GetCustomerFeedsForCustomer(customer))
            {
                var nf = NewsFeed.FromDomainObject(feed);
                newsFeeds.Add(nf);
            }
            return newsFeeds.ToList();
        }

        public List<NewsFeed> GetNewsFeedsAsXml(string customerId)
        {
            return GetNewsFeeds(customerId);
        }

        public List<NewsFeed> GetNewsFeedsAsJson(string customerId)
        {
            return GetNewsFeeds(customerId);
        }

        private List<NewsFeed> GetNewsFeedsSince(string customerId, string id)
        {
            var customer = new Feeds.Domain.Customer();
            customer.Id = int.Parse(customerId);
            var nfService = Global.container.Resolve<ICustomerFeedService>();
            var newsFeeds = new List<NewsFeed>();
            foreach (var feed in nfService.GetCustomerFeedsForCustomerSince(customer, Int32.Parse(id)))
            {
                var nf = NewsFeed.FromDomainObject(feed);
                newsFeeds.Add(nf);
            }
            return newsFeeds;
        }

        public List<NewsFeed> GetNewsFeedsSinceAsXml(string customerId, string id)
        {
            return GetNewsFeedsSince(customerId, id);
        }

        public List<NewsFeed> GetNewsFeedsSinceAsJson(string customerId, string id)
        {
            return GetNewsFeedsSince(customerId, id);
        }
    }
}
