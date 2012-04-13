using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Bti.Babble.Model;
using System.Xml;

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
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "event")
                {
                    var evt = BabbleEvent.CreateFromXmlReader(reader);
                    this.Add(evt);
                }
            }
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