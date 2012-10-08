using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.IO;
using System.Xml;

namespace Bti.Babble.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "xml/babble?viewer={viewer}&comment={commentCount}&story={storyCount}&poll={pollCount}&coupon={couponCount}")]
        [return: MessageParameter(Name = "babble")]
        babble GetBabbleEventsAsXml(string viewer, int commentCount, int storyCount, int pollCount, int couponCount);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "json/babble?viewer={viewer}&comment={commentCount}&story={storyCount}&poll={pollCount}&coupon={couponCount}")]
        babble GetBabbleEventsAsJson(string viewer, int commentCount, int storyCount, int pollCount, int couponCount);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "xml/babble/{viewer}/{id}")]
        [return: MessageParameter(Name = "babble")]
        babble GetBabbleEventsSinceAsXml(string viewer, string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "json/babble/{viewer}/{id}")]
        babble GetBabbleEventsSinceAsJson(string viewer, string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "xml/twitter?rpp={resultsPerPage}&q={query}")]
        [return: MessageParameter(Name = "babble")]
        babble GetTwitterEventsAsXml(int resultsPerPage, string query);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "json/twitter?rpp={resultsPerPage}&q={query}")]
        babble GetTwitterEventsAsJson(int resultsPerPage, string query);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Xml,
            RequestFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "xml/babble/")]
        void PostBabbleEventsAsXml(XmlElement events);

    }
}
