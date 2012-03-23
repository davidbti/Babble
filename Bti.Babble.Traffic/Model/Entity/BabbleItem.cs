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
                Message = this.Message,
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
                Message = o.Message,
                Link = o.Link,
                Type = (int)o.Type
            };
        }

        internal static void UpdateEntityObject(Model.BabbleItem o, BabbleItem e)
        {
            e.Message = o.Message;
            e.Link = o.Link;
            e.Type = (int)o.Type;
        }
    }
}
