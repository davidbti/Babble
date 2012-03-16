using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace Bti.Babble.Traffic.Model.Entity
{
    partial class BabbleItem
    {
        internal Model.BabbleItem ToModelObject()
        {
            if (this == null) return null;
            return new Model.BabbleItem()
            {
                Id = this.Id,
                TrafficItemId = this.TrafficItemId,
                Body = this.Body,
                Link = this.Link,
                Type = (BabbleItemType) this.Type
            };
        }

        internal static BabbleItem ToEntityObject(Model.BabbleItem o)
        {
            if (o == null) return null;
            return new BabbleItem()
            {
                Id = o.Id,
                TrafficItemId = o.TrafficItemId,
                Body = o.Body,
                Link = o.Link,
                Type = (int)o.Type
            };
        }
    }
}
