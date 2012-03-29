using System;
using System.Xml.Serialization;

namespace Bti.Babble.Model
{
    public class CouponEvent : BabbleEvent
    {
        public string Store { get; set; }
        public string Coupon { get; set; }
        public string Code { get; set; }
        public string Link { get; set; }

        public CouponEvent() { }

        public CouponEvent(BabbleEvent evt) : base(evt) { }

        public override void ReadXml(System.Xml.XmlReader reader)
        {
            reader.ReadToDescendant("body");
            reader.ReadToDescendant("store");
            Store = reader.ReadElementContentAsString();
            reader.ReadToDescendant("coupon");
            Coupon = reader.ReadElementContentAsString();
            reader.ReadToDescendant("code");
            Code = reader.ReadElementContentAsString();
            reader.ReadToDescendant("link");
            Link = reader.ReadElementContentAsString();
        }

        public override void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("event");
            base.WriteHeader(writer);
            writer.WriteStartElement("body");
            writer.WriteElementString("store", Store);
            writer.WriteElementString("coupon", Coupon);
            writer.WriteElementString("code", Code);
            writer.WriteElementString("link", Link);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}