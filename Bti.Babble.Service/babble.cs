using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Bti.Babble.Model;

namespace Bti.Babble.Service
{
    public class babble : List<BabbleEvent>, IXmlSerializable
    {
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public virtual void ReadXml(System.Xml.XmlReader reader)
        {
        }

        public virtual void WriteXml(System.Xml.XmlWriter writer)
        {
            foreach (var item in this)
            {
                item.WriteXml(writer);
            }
        }
    }
}