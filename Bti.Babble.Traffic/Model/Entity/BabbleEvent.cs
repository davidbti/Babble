using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace Bti.Babble.Traffic.Model.Entity
{
    partial class BabbleEvent
    {
        internal Model.BabbleEvent ToModelObject()
        {
            if (this == null) return null;
            return new Model.BabbleEvent()
            {
                Body = this.Body,
                Link = this.Link,
                Type = (BabbleEventType) this.Type
            };
        }

        internal static BabbleEvent ToEntityObject(Model.BabbleEvent o)
        {
            if (o == null) return null;
            return new BabbleEvent()
            {
                Body = o.Body,
                Link = o.Link,
                Type = (int)o.Type
            };
        }
    }
}
